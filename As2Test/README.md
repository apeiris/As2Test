# As2Test

Windows app to send encrypted / signed Files (EDI) to AS2 server

- The Partner configuration is retrived from the OpenAS2 server service loacation.
As such the the OpenAS2 server must be installed as a Windows service.

- Note that the Partner configuration is reloded by the OpenAS2 server when the config file is modified, The OpenAS2 server must be running error free for it be able to pickup the changes and to propagete the changes to the database.
    
----

- If the Server Message Tracking is enabled on MSSQL Server, changes to partner configuration file persisted as a function named **dbo.fxPatnerships()**
  when the changes are reloaded by OpenAS2 server. - Note. this feature is only enabled on SQLServer implementation.

-------
- partnershipTemplate.xml file act as a base template for creation of Partneship
This file is created and the resulting changes are saved to **config\partnerships.xml**.

|syntax|description|
|------|-----------|

