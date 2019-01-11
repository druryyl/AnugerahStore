CREATE TABLE [dbo].[JenisMutasi]
(
	JenisMutasiID VARCHAR(5) NOT NULL CONSTRAINT DF_JenisMutasi_JenisMutasiID DEFAULT(''),
	JenisMutasiName VARCHAR(20) NOT NULL CONSTRAINT DF_JenisMutasi_JenisMutasiName DEFAULT(''),

	CONSTRAINT PK_JenisMutasi_JenisMutasiID PRIMARY KEY CLUSTERED(JenisMutasiID)
)
