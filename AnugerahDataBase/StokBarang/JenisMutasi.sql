CREATE TABLE [dbo].[JenisMutasi]
(
	JenisMutasiID VARCHAR(6) NOT NULL CONSTRAINT DF_JenisMutasi_JenisMutasiID DEFAULT(''),
	JenisMutasiName VARCHAR(20) NOT NULL CONSTRAINT DF_JenisMutasi_JenisMutasiName DEFAULT(''),
	IsBrgMasuk BIT NOT NULL CONSTRAINT DF_JenisMutasi_IsBrgMasuk DEFAULT(0),

	CONSTRAINT PK_JenisMutasi_JenisMutasiID PRIMARY KEY CLUSTERED(JenisMutasiID)
)
