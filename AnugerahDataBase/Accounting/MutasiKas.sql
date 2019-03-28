﻿CREATE TABLE [dbo].[MutasiKas]
(
	MutasiKasID VARCHAR(10) NOT NULL CONSTRAINT DF_MutasiKas_MutasiKasID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_MutasiKas_Tgl DEFAULT(''),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_MutasiKas_Jam DEFAULT(''),
	PegawaiID VARCHAR(5) NOT NULL CONSTRAINT DF_MutasiKas_PegawaiID DEFAULT(''),
	JenisKasIDAsal VARCHAR(3) NOT NULL CONSTRAINT DF_MutasiKas_JenisKasIDAwal DEFAULT(''),
	JenisKasIDTujuan VARCHAR(3) NOT NULL CONSTRAINT DF_MutasiKas_JenisKasIDTujuan DEFAULT(''),
	Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_MutasiKas_Keterangan DEFAULT(''),
	NilaiKas DECIMAL(18,0) NOT NULL CONSTRAINT DF_MutasiKas_NilaiKas DEFAULT(0),

	CONSTRAINT PK_MutasiKas_MutasiKasID PRIMARY KEY CLUSTERED (MutasiKasID)

)
