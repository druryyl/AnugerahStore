﻿CREATE TABLE [dbo].[BPStokDetil]
(
	BPStokID VARCHAR(15) NOT NULL CONSTRAINT DF_BPStokDetil_BPStokID DEFAULT(''),
	BPStokDetilID VARCHAR(18) NOT NULL CONSTRAINT DF_BPStokD_BPStokDetilID DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokDetil_NoUrut DEFAULT(0),
	ReffID VARCHAR(10) NOT NULL CONSTRAINT DF_BPStokDetil_ReffID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_BPStokDetil_Tgl DEFAULT('3000-01-01'),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_BPStokDetil_Jam DEFAULT('00:00:00'),
	QtyIn DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokDetil_QtyIn DEFAULT(0),
	NilaiHpp DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokDetil_NilaiHpp DEFAULT(0),
	QtyOut DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokDetil_QtyOut DEFAULT(0),
	HargaJual DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokDetil_HargaJual DEFAULT(0),

	CONSTRAINT PK_BPStokDetil_BPStokDetilID PRIMARY KEY CLUSTERED(BPStokDetilID)
)
