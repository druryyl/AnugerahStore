﻿CREATE TABLE [dbo].[BPKas]
(
	BPKasID VARCHAR(10) NOT NULL CONSTRAINT DF_BPKas_BPKasID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_BPKas_BPKasTgl DEFAULT('3000-01-01'),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_BPKas_Jam DEFAULT('00:00:00'),
	Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_BPKas_Keterangan DEFAULT(''),
	NilaiTotalKas DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPKas_NilaiTotalKas DEFAULT(0),

	CONSTRAINT PK_BPKas_BPKasID PRIMARY KEY CLUSTERED (BPKasID)
)
