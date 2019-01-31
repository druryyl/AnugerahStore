﻿CREATE TABLE [dbo].[BukuHutang]
(
	BukuHutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutang_BukuHutangID DEFAULT(''),
	TglBuku VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutang_TglBuku DEFAULT(''),
	JamBuku VARCHAR(8) NOT NULL CONSTRAINT DF_BukuHutang_JamBuku DEFAULT(''),
	UserrID VARCHAR(50) NOT NULL CONSTRAINT DF_BukuHutang_UserrID DEFAULT(''),
	PihakKetigaID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutang_PihakKetigaID DEFAULT(''),
	NilaiHutang DECIMAL(18,0) NOT NULL CONSTRAINT DF_BukuHutang_NilaiHutang DEFAULT(0),
	NilaiSisa DECIMAL(18,0) NOT NULL CONSTRAINT DF_BukuHutang_NilaiSisa DEFAULT(0),
	Keterangan VARCHAR(50) NOT NULL CONSTRAINT DF_BukuHutang_Keterangan DEFAULT(0),
	BukuKasID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutang_BukuKasID DEFAULT(''),

	CONSTRAINT PK_BukuHutang_BukuHutangID PRIMARY KEY CLUSTERED (BukuHutangID)
)