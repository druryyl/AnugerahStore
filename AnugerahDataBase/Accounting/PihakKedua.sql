CREATE TABLE [dbo].[PihakKedua]
(
	PihakKeduaID VARCHAR(5) NOT NULL CONSTRAINT DF_PihakKedua_PihakKeduaID DEFAULT(''),
	PihakKeduaName VARCHAR(30) NOT NULL CONSTRAINT DF_PihakKedua_PihakKeduaName DEFAULT(''),

	CONSTRAINT PK_PihakKedua_PihakKeduaID PRIMARY KEY CLUSTERED(PihakKeduaID)
)
