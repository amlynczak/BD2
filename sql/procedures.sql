CREATE PROCEDURE SaveXmlDocument
	@XmlDoc XML
AS
BEGIN
	INSERT INTO XML_Documents (Document)
	VALUES (@XmlDoc);
END;
GO

CREATE PROCEDURE DeleteXmlDocument
	@id INT
AS
BEGIN
	DELETE FROM XML_Documents
	WHERE id = @id;
END;
GO

CREATE PROCEDURE QueryXmlDocuments
	@XPath NVARCHAR(MAX)
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX);

	SET @sql = 'SELECT id, Document FROM XML_Documents WHERE Document.exist(''' + @XPath + ''') = 1;';

	EXEC sp_executesql @sql;
END;
GO

CREATE PROCEDURE ModifyXmlDocument
	@id INT,
	@XPath NVARCHAR(MAX),
	@NewVal NVARCHAR(MAX)
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX);

	SET @sql = '
	DECLARE @XMLDoc XML;

	SELECT @XMLDoc = Document FROM XML_Documents WHERE id = @id;

	SET @XMLDoc.modify(''replace value of ('+ @XPath + ')[1] with sql:variable("@NewVal")'');

	UPDATE XML_Documents
	SET Document = @XMLDoc WHERE id = @id;';

	EXEC sp_executesql @sql, N'@id INT, @NewVal NVARCHAR(MAX)', @id, @NewVal;
END;
GO