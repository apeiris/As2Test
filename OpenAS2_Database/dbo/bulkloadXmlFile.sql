CREATE PROCEDURE [dbo].[bulkloadXmlFile]
	
AS
begin
-- Load the XML data into the table
DECLARE @xml AS XML;
BEGIN TRY
SELECT @xml = CAST(bulkcolumn AS XML)
FROM OPENROWSET(BULK 'C:\Users\mapei\eclipse-workspace\OpenAs2App\Server\target\dist\config\partnerships.xml', SINGLE_BLOB) as x;
END TRY
BEGIN CATCH
PRINT 'Error: Unable to load XML file.';
END CATCH;

-- Insert the XML into the table
INSERT INTO partnerships_xml (xml_data)
VALUES (@xml);

end