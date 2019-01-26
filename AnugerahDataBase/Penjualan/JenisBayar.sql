CREATE TABLE [dbo].[JenisBayar]
(
	JenisBayarID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisBayar_JenisBayarID DEFAULT(''),
	JenisBayarName VARCHAR(20) NOT NULL CONSTRAINT DF_JenisBayar_JenisBayarName DEFAULT(''),
	IsMesinEdc BIT NOT NULL CONSTRAINT DF_JenisBayar_IsMesinEdc DEFAULT(0),

	CONSTRAINT PK_JenisBayar_JenisBayarID PRIMARY KEY CLUSTERED(JenisBayarID)
)
