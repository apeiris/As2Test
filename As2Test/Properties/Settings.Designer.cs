﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace As2Test.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
<<<<<<< HEAD
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
=======
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
>>>>>>> 8386a1a0ba3eddac43332bc4b2e7a79ceca3ca8c
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
<<<<<<< HEAD
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\EDI")]
        public string x12FileName {
            get {
                return ((string)(this["x12FileName"]));
            }
            set {
                this["x12FileName"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OpenAS2Server")]
        public string ServiceName {
            get {
                return ((string)(this["ServiceName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("config\\config.xml")]
        public string configFilename {
            get {
                return ((string)(this["configFilename"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("xxxx")]
        public string keyStoreFile {
            get {
                return ((string)(this["keyStoreFile"]));
            }
            set {
                this["keyStoreFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("server=(local);user id=sa;password=2205;initial catalog=as2")]
        public string sqlSever {
            get {
                return ((string)(this["sqlSever"]));
            }
            set {
                this["sqlSever"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string sender {
            get {
                return ((string)(this["sender"]));
            }
            set {
                this["sender"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string receiver {
            get {
                return ((string)(this["receiver"]));
            }
            set {
                this["receiver"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("testas2")]
        public string CertStorePassword {
            get {
                return ((string)(this["CertStorePassword"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//partner[@name=$\'{txtPartnerName.Text}\']")]
        public string XPathToPartnerByName {
            get {
                return ((string)(this["XPathToPartnerByName"]));
            }
            set {
                this["XPathToPartnerByName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("name")]
        public string partnerNodeSelecter {
            get {
                return ((string)(this["partnerNodeSelecter"]));
            }
            set {
                this["partnerNodeSelecter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("name")]
        public string parntershipNodeSelector {
            get {
                return ((string)(this["parntershipNodeSelector"]));
            }
            set {
                this["parntershipNodeSelector"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string configPath {
            get {
                return ((string)(this["configPath"]));
            }
            set {
                this["configPath"] = value;
=======
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string sendFilePath {
            get {
                return ((string)(this["sendFilePath"]));
            }
            set {
                this["sendFilePath"] = value;
>>>>>>> 8386a1a0ba3eddac43332bc4b2e7a79ceca3ca8c
            }
        }
    }
}
