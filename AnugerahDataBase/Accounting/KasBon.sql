﻿CREATE TABLE [dbo].[KasBon]
(
	KasBonID VARCHAR(10) NOT NULL CONSTRAINT DF_KasBon_KasBonID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_KasBon_Tgl DEFAULT('3000-01-01'),
	Jam  VARCHAR(10) NOT NULL CONSTRAINT DF_KasBon_Jam DEFAULT('00:00:00'),
	PihakKeduaID  VARCHAR(5) NOT NULL CONSTRAINT DF_KasBon_PihakKeduaID DEFAULT(''),
	Keterangan  VARCHAR(128) NOT NULL CONSTRAINT DF_KasBon_Keterangan DEFAULT(''),
	NilaiKasBon  DECIMAL(18,0) NOT NULL CONSTRAINT DF_KasBon_NilaiKasBon DEFAULT(0),

	CONSTRAINT PK_KasBon_KasBonID PRIMARY KEY CLUSTERED (KasBonID)
)