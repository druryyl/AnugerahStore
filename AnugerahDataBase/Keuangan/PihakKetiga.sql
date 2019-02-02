CREATE TABLE [dbo].[PihakKetiga]
(
	PihakKetigaID VARCHAR(5) NOT NULL CONSTRAINT DF_PihakKetiga_PihakKetigaID DEFAULT(''),
	PihakKetigaName VARCHAR(30) NOT NULL CONSTRAINT DF_PihakKetiga_PihakKetigaName DEFAULT(''),
	
	CONSTRAINT PK_PihakKetiga_PihakKetigaID PRIMARY KEY CLUSTERED(PihakKetigaID)
)
