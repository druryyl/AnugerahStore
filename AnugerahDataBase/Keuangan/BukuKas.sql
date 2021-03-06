﻿CREATE TABLE [dbo].[BukuKas]
(
	BukuKasID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuKas_BukuKasID DEFAULT(''),
	TglBuku VARCHAR(10) NOT NULL CONSTRAINT DF_BukuKas_TglBuku DEFAULT('3000-01-01'),
	JamBuku VARCHAR(8) NOT NULL CONSTRAINT DF_BukuKas_JamBuku DEFAULT('00:00:00'),
	UserrID VARCHAR(50) NOT NULL CONSTRAINT DF_BukuKas_UserrID DEFAULT(''),
	
	NilaiKas DECIMAL(18,2) NOT NULL CONSTRAINT DF_BukuKas_NilaiKas DEFAULT(0),
	JenisTrsKasirID VARCHAR(4) NOT NULL CONSTRAINT DF_BukuKas_JenisTrsKasirID DEFAULT(''),

	ReffID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuKas_ReffID DEFAULT(''),
	Keterangan VARCHAR(255) NOT NULL CONSTRAINT DF_BukuKas_Keterangan DEFAULT(''),
	PihakKetigaID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuKas_PihakKetigaID DEFAULT(''), 

    CONSTRAINT PK_BukuKas_BukuKasID PRIMARY KEY CLUSTERED (BukuKasID)
)
