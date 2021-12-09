using Org.BouncyCastle.Asn1.Ess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
#pragma warning  restore 1030 

namespace As2Test
{
    public struct ProxySettings
    {
        public string Name;
        public string Username;
        public string Password;
        public string Domain;
    }
    public static class EncryptionAlgorithm
    {
        public static string DES3 = "3DES";
        public static string RC2 = "RC2";
    }

    public class AS2
    {
        X509Certificate2Collection storeCertifcates = new X509Certificate2Collection();
        const string MESSAGE_SEPARATOR = "\r\n\r\n";

        public AS2(string keyStoreFilename, string keyStorePassword)
        {
            Debug.WriteLine($"keyStore={keyStoreFilename}, password={keyStorePassword}");
            storeCertifcates.Import(keyStoreFilename, keyStorePassword, X509KeyStorageFlags.Exportable);
        }
        public X509Certificate2 getCert(string certificateName)
        {
            foreach (X509Certificate2 c in storeCertifcates)
            {
                Debug.WriteLine($"Subject={c.Subject}\n");
                Dictionary<string, string> kvp = c.Subject.
                              Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToDictionary(str => str.Split(new char[] { '=' })[0], str => str.Split(new char[] { '=' })[1], (StringComparer.CurrentCultureIgnoreCase));
                if (kvp["CN"] == certificateName) return c;

            }
            return null;
        }
        private static HttpStatusCode HandleWebResponse(HttpWebRequest http)
        {
            HttpWebResponse response = null;
            HttpStatusCode r;
            try
            {
                response = (HttpWebResponse)http.GetResponse();
                r = response.StatusCode;
                response.Close();

            }
            catch (Exception ex)
            {
                if (response != null)
                {
                    r = response.StatusCode;
                    Debug.WriteLine($"Exception:{ex.Message}\n {ex.StackTrace}");

                }
                else r = 0;
            }
            return r;
        }
        private static void SendWebRequest(HttpWebRequest http, byte[] fileData)
        {
            Stream oRequestStream = http.GetRequestStream();
            oRequestStream.Write(fileData, 0, fileData.Length);
            oRequestStream.Flush();
            oRequestStream.Close();
        }

        /// <summary>
        /// return a unique MIME style boundary
        /// this needs to be unique enought not to occur within the data
        /// and so is a Guid without - or { } characters.
        /// </summary>
        /// <returns></returns>
        protected static string MIMEBoundary()
        {
            return "_" + Guid.NewGuid().ToString("N") + "_";
        }
        /// <summary>
        /// Creates the a Mime header out of the components listed.
        /// </summary>
        /// <param name="sContentType">Content type</param>
        /// <param name="sEncoding">Encoding method</param>
        /// <param name="sDisposition">Disposition options</param>
        /// <returns>A string containing the three headers.</returns>
        public static string MIMEHeader(string sContentType, string sEncoding, string sDisposition)
        {
            string sOut = "";

            sOut = "Content-Type: " + sContentType + Environment.NewLine;
            if (sEncoding != "")
                sOut += "Content-Transfer-Encoding: " + sEncoding + Environment.NewLine;

            if (sDisposition != "")
                sOut += "Content-Disposition: " + sDisposition + Environment.NewLine;

            sOut = sOut + Environment.NewLine;

            return sOut;
        }


        /// <summary>
        /// Create a Message out of byte arrays (this makes more sense than the above method)
        /// </summary>
        /// <param name="sContentType">Content type ie multipart/report</param>
        /// <param name="sEncoding">The encoding provided...</param>
        /// <param name="sDisposition">The disposition of the message...</param>
        /// <param name="abMessageParts">The byte arrays that make up the components</param>
        /// <returns>The message as a byte array.</returns>
        public static byte[] CreateMessage(string sContentType, string sEncoding, string sDisposition, params byte[][] abMessageParts)
        {
            int iHeaderLength = 0;
            return CreateMessage(sContentType, sEncoding, sDisposition, out iHeaderLength, abMessageParts);
        }
        /// <summary>
        /// Create a Message out of byte arrays (this makes more sense than the above method)
        /// </summary>
        /// <param name="sContentType">Content type ie multipart/report</param>
        /// <param name="sEncoding">The encoding provided...</param>
        /// <param name="sDisposition">The disposition of the message...</param>
        /// <param name="iHeaderLength">The length of the headers.</param>
        /// <param name="abMessageParts">The message parts.</param>
        /// <returns>The message as a byte array.</returns>
        public static byte[] CreateMessage(string sContentType, string sEncoding, string sDisposition, out int iHeaderLength, params byte[][] abMessageParts)
        {
            long lLength = 0;
            long lPosition = 0;

            //Only one part... Add headers only...
            if (abMessageParts.Length == 1)
            {
                byte[] bHeader = ASCIIEncoding.ASCII.GetBytes(MIMEHeader(sContentType, sEncoding, sDisposition));
                iHeaderLength = bHeader.Length;
                return ConcatBytes(bHeader, abMessageParts[0]);
            }
            else
            {
                // get boundary and "static" subparts.
                string sBoundary = MIMEBoundary();
                byte[] bPackageHeader = ASCIIEncoding.ASCII.GetBytes(MIMEHeader(sContentType + "; boundary=\"" + sBoundary + "\"", sEncoding, sDisposition));
                byte[] bBoundary = ASCIIEncoding.ASCII.GetBytes(Environment.NewLine + "--" + sBoundary + Environment.NewLine);
                byte[] bFinalFooter = ASCIIEncoding.ASCII.GetBytes(Environment.NewLine + "--" + sBoundary + "--" + Environment.NewLine);

                //Calculate the total size required.
                iHeaderLength = bPackageHeader.Length;

                foreach (byte[] ar in abMessageParts)
                    lLength += ar.Length;
                lLength += iHeaderLength + bBoundary.Length * abMessageParts.Length +
                    bFinalFooter.Length;

                //Create new byte array to that size.
                byte[] toReturn = new byte[lLength];

                //Copy the headers in.
                bPackageHeader.CopyTo(toReturn, lPosition);
                lPosition += bPackageHeader.Length;

                //Fill the new byte array in by coping the message parts.
                foreach (byte[] ar in abMessageParts)
                {
                    bBoundary.CopyTo(toReturn, lPosition);
                    lPosition += bBoundary.Length;

                    ar.CopyTo(toReturn, lPosition);
                    lPosition += ar.Length;
                }

                //Finally add the footer boundary.
                bFinalFooter.CopyTo(toReturn, lPosition);

                return toReturn;
            }
        }
        public HttpStatusCode SendFile(Uri uri, string filename, byte[] fileData, string from, string to, ProxySettings proxySettings, int timeoutMs)
        {
            if (String.IsNullOrEmpty(filename)) throw new ArgumentNullException("filename");

            if (fileData.Length == 0) throw new ArgumentException("filedata");

            byte[] content = fileData;

            //Initialise the request
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(uri);

            if (!String.IsNullOrEmpty(proxySettings.Name))
            {
                WebProxy proxy = new WebProxy(proxySettings.Name);

                NetworkCredential proxyCredential = new NetworkCredential();
                proxyCredential.Domain = proxySettings.Domain;
                proxyCredential.UserName = proxySettings.Username;
                proxyCredential.Password = proxySettings.Password;

                proxy.Credentials = proxyCredential;

                http.Proxy = proxy;
            }

            //Define the standard request objects
            http.Method = "POST";

            http.AllowAutoRedirect = true;

            http.KeepAlive = true;

            http.PreAuthenticate = false; //Means there will be two requests sent if Authentication required.
            http.SendChunked = false;

            http.UserAgent = "MY SENDING AGENT";

            //These Headers are common to all transactions
            http.Headers.Add("Mime-Version", "1.0");
            http.Headers.Add("AS2-Version", "1.2");

            http.Headers.Add("AS2-From", from);
            http.Headers.Add("AS2-To", to);
            http.Headers.Add("Subject", filename + " transmission.");
            http.Headers.Add("Message-Id", "<AS2_" + DateTime.Now.ToString("hhmmssddd") + ">");

            http.Timeout = timeoutMs;

            //string contentType = (Path.GetExtension(filename) == ".xml") ? "application/xml" : "application/EDIFACT";
            string contentType = (Path.GetExtension(filename) == ".xml") ? "application/xml" : "application/edi-x12";

            bool encrypt = !string.IsNullOrEmpty(to);
            bool sign = !string.IsNullOrEmpty(from);
            /// this is copied from (!sign && !encrypt);
           #warning the folloing line is a test -- should be discarded after tests if not desired
            http.Headers.Add("Content-Transfer-Encoding", "binary");

            if (!sign && !encrypt)
            {
              http.Headers.Add("Content-Transfer-Encoding", "binary");  
                http.Headers.Add("Content-Disposition", "inline; filename=\"" + filename + "\"");

            }
            if (sign)
            {
                // Wrap the file data with a mime header
                content = AS2.CreateMessage(contentType, "binary", "", content);

                //content = Sign(content, signingCertFilename, signingCertPassword, out contentType);
                X509Certificate2 signerCertficiate = getCert(from.ToLower());
                content = Sign(content, signerCertficiate,out contentType);
                http.Headers.Add("EDIINT-Features", "multiple-attachments");
                // http.Headers.Add("Receipt-Delivery-Option", "http://localhost:10081");
                // http.Headers.Add("Disposition-Notification-To", "https://localhost:44326");
                http.Headers.Add("Disposition-Notification-To", "mapeiris@hotmail.com");
            }
            if (encrypt)
            {
                X509Certificate2 receipeintCertificate = getCert(to.ToLower());
                    if ((receipeintCertificate)==null)
                {
                    throw new ArgumentNullException(to.ToLower(), "if encrytionAlgorithm is specified then recipientCertFilename must be specified");
                }

                byte[] signedContentTypeHeader = System.Text.ASCIIEncoding.ASCII.GetBytes("Content-Type: " + contentType + Environment.NewLine);
                byte[] contentWithContentTypeHeaderAdded = ConcatBytes(signedContentTypeHeader, content);

                X509Certificate2 receipientCertificate = getCert(to.ToLower());
                content = AS2.Encrypt(contentWithContentTypeHeaderAdded, receipientCertificate, EncryptionAlgorithm.DES3);


                contentType = "application/pkcs7-mime; smime-type=enveloped-data; name=\"smime.p7m\"";
            }

            http.ContentType = contentType;
            http.ContentLength = content.Length;

            SendWebRequest(http, content);

            return HandleWebResponse(http);
        }
        /// <summary>
        /// Signs a message and returns a MIME encoded array of bytes containing the signature.
        /// </summary>
        /// <param name="arMessage"></param>
        /// <param name="bPackageHeader"></param>
        /// <returns></returns>
        internal static byte[] Encode(byte[] arMessage, X509Certificate2 signerCert)
        {
            
            
            
            ContentInfo contentInfo = new ContentInfo(arMessage);


            SignedCms signedCms = new SignedCms(contentInfo, true); // <- true detaches the signature
            CmsSigner cmsSigner = new CmsSigner(signerCert);

            signedCms.ComputeSignature(cmsSigner);
            byte[] signature = signedCms.Encode();

            return signature;
        }
        /// <summary>
        /// Return a single array of bytes out of all the supplied byte arrays.
        /// </summary>
        /// <param name="arBytes">Byte arrays to add</param>
        /// <returns>The single byte array.</returns>
        public static byte[] ConcatBytes(params byte[][] arBytes)
        {
            long lLength = 0;
            long lPosition = 0;

            //Get total size required.
            foreach (byte[] ar in arBytes)
                lLength += ar.Length;

            //Create new byte array
            byte[] toReturn = new byte[lLength];

            //Fill the new byte array
            foreach (byte[] ar in arBytes)
            {
                ar.CopyTo(toReturn, lPosition);
                lPosition += ar.Length;
            }

            return toReturn;
        }
        public static byte[] Sign(byte[] arMessage, X509Certificate2 signerCertificate, out string sContentType)
        {
            byte[] bInPKCS7 = new byte[0];

            // get a MIME boundary
            string sBoundary = MIMEBoundary();

            // Get the Headers for the entire message.
            sContentType = "multipart/signed; protocol=\"application/pkcs7-signature\"; micalg=\"sha1\"; boundary=\"" + sBoundary + "\"";

            // Define the boundary byte array.
            byte[] bBoundary = ASCIIEncoding.ASCII.GetBytes(Environment.NewLine + "--" + sBoundary + Environment.NewLine);

            // Encode the header for the signature portion.
            byte[] bSignatureHeader = ASCIIEncoding.ASCII.GetBytes(MIMEHeader("application/pkcs7-signature; name=\"smime.p7s\"", "base64", "attachment; filename=smime.p7s"));

            // Get the signature.
            //  byte[] bSignature = Encode(arMessage, signerCert, signerPassword);
            byte[] bSignature = AS2.Encode(arMessage, signerCertificate);
            // convert to base64
            string sig = Convert.ToBase64String(bSignature) + MESSAGE_SEPARATOR;
            bSignature = System.Text.ASCIIEncoding.ASCII.GetBytes(sig);

            // Calculate the final footer elements.
            byte[] bFinalFooter = ASCIIEncoding.ASCII.GetBytes("--" + sBoundary + "--" + Environment.NewLine);

            // Concatenate all the above together to form the message.
            bInPKCS7 = ConcatBytes(bBoundary, arMessage, bBoundary,
                bSignatureHeader, bSignature, bFinalFooter);

            return bInPKCS7;
        }
        internal static byte[] Encrypt(byte[] message, X509Certificate2 recipientCert, string encryptionAlgorithm)
        {
            if (!string.Equals(encryptionAlgorithm, EncryptionAlgorithm.DES3) && !string.Equals(encryptionAlgorithm, EncryptionAlgorithm.RC2))
                throw new ArgumentException("encryptionAlgorithm argument must be 3DES or RC2 - value specified was:" + encryptionAlgorithm);

            

            //  X509Certificate2 cert = new X509Certificate2(recipientCert);
            ContentInfo contentInfo = new ContentInfo(message);

            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo,
                new AlgorithmIdentifier(new System.Security.Cryptography.Oid(encryptionAlgorithm))); // should be 3DES or RC2

            CmsRecipient recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, recipientCert);

            envelopedCms.Encrypt(recipient);

            byte[] encoded = envelopedCms.Encode();

            return encoded;
        }

    }
    
}
