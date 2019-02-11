CREATE TABLE [dbo].[JenisLunas]
(
	JenisLunasID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisLunas_JenisLunasID DEFAULT(''),
	JenisLunasName VARCHAR(30) NOT NULL CONSTRAINT DF_JenisLunas_JenisLunasName DEFAULT(''),

	CONSTRAINT PK_JenisLunas_JenisLunasID PRIMARY KEY CLUSTERED(JenisLunasID)
)
