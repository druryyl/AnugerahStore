﻿CREATE TABLE [dbo].[JenisKas]
(
	JenisKasID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisKas_JenisKasID DEFAULT(''),
	JenisKasName VARCHAR(10) NOT NULL CONSTRAINT DF_JenisKas_JenisKasName DEFAULT(''),

	CONSTRAINT PK_JenisKas_JenisKasID PRIMARY KEY CLUSTERED(JenisKasID)
)
