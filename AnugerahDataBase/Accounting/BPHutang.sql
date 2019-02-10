﻿CREATE TABLE [dbo].[BPHutang]
(
	BPHutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BPHutang_BPHutangID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_BPHutang_Tgl DEFAULT('3000-01-01'),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_BPHutang_Jam DEFAULT('00:00:00'),
	PihakKeduaID VARCHAR(5) NOT NULL CONSTRAINT DF_BPHutang_PihakKeduaID DEFAULT(''),
	Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_BPHutang_Keterangan DEFAULT(''),
	NilaiHutang DECIMAL(18,0)  NOT NULL CONSTRAINT DF_BPHutang_NilaiHutang DEFAULT(0),
	NilaiLunas DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPHutang_NilaiLunas DEFAULT(0),
)