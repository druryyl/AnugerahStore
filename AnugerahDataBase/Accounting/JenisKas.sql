﻿CREATE TABLE [dbo].[JenisKas]
(
	JenisKasID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisKas_JenisKasID DEFAULT(''),
	JenisKasName VARCHAR(15) NOT NULL CONSTRAINT DF_JenisKas_JenisKasName DEFAULT(''),
	TipeKas VARCHAR(2) NOT NULL CONSTRAINT DF_JenisKas_TipeKas DEFAULT(''),

	CONSTRAINT PK_JenisKas_JenisKasID PRIMARY KEY CLUSTERED(JenisKasID)
)
