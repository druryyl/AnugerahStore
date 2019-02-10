﻿CREATE TABLE [dbo].[BPPiutang]
(
    BPPiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BPPiutang_BPPiutangID DEFAULT(''),
    Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_BPPiutang_Tgl DEFAULT('3000-01-01'),
    Jam VARCHAR(8) NOT NULL CONSTRAINT DF_BPPiutang_Jam DEFAULT('00:00:00'),
    PihakKeduaID VARCHAR(5) NOT NULL CONSTRAINT DF_BPPiutang_PihakKeduaID DEFAULT(''),
    Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_BPPiutang_KeteranganID DEFAULT(''),
    NilaiPiutang DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPiutang_NilaiPiutang DEFAULT(0),
    NilaiLunas DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPiutang_NilaiLunas DEFAULT(0),

	CONSTRAINT PK_BPPiutang_BPPiutangID PRIMARY KEY CLUSTERED (BPPiutangID)
)