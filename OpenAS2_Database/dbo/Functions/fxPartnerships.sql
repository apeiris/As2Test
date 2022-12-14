﻿CREATE   function [dbo].[fxPartnerships]() returns xml as 
begin   
return '<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<partnerships>
        
    <partner as2_id="iris" email="mapeiris@nowthis.com" name="iris" x509_alias="iris"/>
        
    <partner as2_id="partnera" email="mapeiris@hotmail.com" name="partnera" x509_alias="partnera"/>
        
    <partner as2_id="PartnerB" email="mapeiris@hotmail.com" name="partnerb" x509_alias="partnerb"/>
        
    <partnership name="Iris-to-PartnerA">
                
        <sender name="iris"/>
                
        <receiver name="partnera"/>
                
        <!--  The pollerConfig node defines whether this partnership will receive files to send to the "receiver" partner via a directory poller.
              Remove this node or set enabled="false" if the "sender" partner is not your own organisation or you want to prevent the poller running for this partnership.
              Attributes from the "pollerConfigBase" node above can be overridden by defining them in this node. 
         -->
                
        <pollerConfig enabled="true"/>
                
        <!-- <attribute name="protocol" value="as2"/> -->
                
        <!-- <attribute name="protocol" value="as2"/> -->
                
        <attribute name="content_transfer_encoding" value="binary"/>
                
        <attribute name="compression_type" value="ZLIB"/>
                
        <attribute name="subject" value="File $attributes.filename$ sent from $sender.name$ to $receiver.name$"/>
                
        <attribute name="as2_url" value="http://localhost:10080"/>
                
        <attribute name="as2_mdn_to" value="mapeiris@hotmail.com"/>
                
        <attribute name="as2_mdn_options" value="signed-receipt-protocol=optional, pkcs7-signature; signed-receipt-micalg=optional, $attribute.sign$"/>
                
        <!--
            For an unsigned MDN use this value for as2_mdn_options:       value="none"
        -->
                
        <!--  For enabling ASYNC MDN uncomment this attribute and set this to the URL partner must send MDN back to.
              Example below uses a property from the config.xml to facilitate centralised management of the URL
            <attribute name="as2_receipt_option" value="$properties.as2_async_mdn_url$"/> 
         -->
                
        <attribute name="encrypt" value="3DES"/>
                
        <attribute name="sign" value="SHA256"/>
                
        <attribute name="resend_max_retries" value="3"/>
                
        <attribute name="prevent_canonicalization_for_mic" value="false"/>
                
        <attribute name="rename_digest_to_old_name" value="false"/>
                
        <attribute name="remove_cms_algorithm_protection_attrib" value="false"/>
        		
        <!--
		Example for adding static custom headers to Mime body part and additionally add to HTTP
		<attribute name="custom_mime_headers" value="X-CustomHeader: shift-shape ; X-CustomShape: oblong"/>
		<attribute name="add_custom_mime_headers_to_http" value="true"/>
		-->
        	
		
        <!--
		Example for adding dynamic custom headers to Mime body part using delimiters where filename is of form XXX-YYY-ZZZ or XXX_YYY-ZZZ etc
        <attribute name="custom_mime_header_names_from_filename" value="header.X-CustomRouteId,header.X-CustomCenter, junk.extraStuff"/>
        <attribute name="custom_mime_header_name_delimiters_in_filename" value="-_"/>

		Example for adding dynamic custom headers to Mime body part where filename is of form XXX-YYY.msg 
        <attribute name="custom_mime_header_names_from_filename" value="X-CustomRouteId,X-CustomCenter"/>
        <attribute name="custom_mime_header_names_regex_on_filename" value="([^-]*)-([^.]*).msg"/>

		Example for parsing filename into parameters that can be referenced this is a file name of the form XXXNNNN.edi where X is alphabetic and N are numerics 
        <attribute name="attribute_names_from_filename" value="P-DynamicParm1,P-DynamicParm2"/>
        <attribute name="attribute_values_regex_on_filename" value="([A-Za-z]*)([^.]*).edi"/>
		-->
        		
        <!--
		Example attributes to support splitting files into smaller chunks
        <attribute name="split_file_threshold_size_in_bytes" value="1073741824"/>
        <attribute name="split_file_contains_header_row" value="true"/>
        <attribute name="split_file_name_prefix" value="SF"/>
		-->
            
    </partnership>
        
    <partnership name="PartnerA-to-Iris">
                
        <sender name="partnera"/>
                
        <receiver name="iris"/>
                
        <attribute name="store_received_file_to" value="$properties.storageBaseDir$/inbox/$msg.receiver.as2_id$/inbox/$msg.sender.as2_id$-$rand.12345$-$msg.content-disposition.filename$"/>
            
    </partnership>
        
    <partnership name="Iris-to-PartnerB">
                
        <sender name="iris"/>
                
        <receiver name="partnerb"/>
                
        <pollerConfig enabled="true"/>
                
        <attribute name="protocol" value="as2"/>
                
        <attribute name="content_transfer_encoding" value="8bit"/>
                
        <attribute name="compression_type" value="ZLIB"/>
                
        <attribute name="subject" value="File $attributes.filename$ sent from $sender.name$ to $receiver.name$"/>
                
        <attribute name="as2_url" value="https://as2.partnerb.com:8443"/>
                
        <attribute name="as2_mdn_to" value="mapeiris@hotmail.com"/>
                
        <attribute name="as2_mdn_options" value="signed-receipt-protocol=optional, pkcs7-signature; signed-receipt-micalg=optional, $attribute.sign$"/>
                
        <!--  For enabling ASYNC MDN uncomment this attribute and set this to the URL partner must send MDN back to.
              Example below uses a property from the config.xml to facilitate centralised management of the URL
            <attribute name="as2_receipt_option" value="$properties.as2_async_mdn_url$"/> 
         -->
                
        <attribute name="encrypt" value="3DES"/>
                
        <attribute name="sign" value="SHA1"/>
                
        <attribute name="resend_max_retries" value="3"/>
                
        <attribute name="prevent_canonicalization_for_mic" value="false"/>
                
        <attribute name="rename_digest_to_old_name" value="false"/>
                
        <attribute name="remove_cms_algorithm_protection_attrib" value="false"/>
            
    </partnership>
        
    <partnership name="PartnerB-to-Iris">
                
        <sender name="partnerb"/>
                
        <receiver name="iris"/>
            
    </partnership>
    
</partnerships>
' end;