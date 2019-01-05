﻿CREATE TABLE [dbo].[KartuStok]
(
	KartuStokID VARCHAR(10) NOT NULL CONSTRAINT DF_KartuStok_KartuStokID DEFAULT(''),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_KartuStok_BrgID DEFAULT(''),
	QtyIn DECIMAL(18,0) NOT NULL CONSTRAINT DF_KartuStok_QtyIn DEFAULT(0),
	QtyOut DECIMAL(18,0) NOT NULL CONSTRAINT DF_KartuStok_QtyOut DEFAULT(0),
	Hpp DECIMAL(18,0) NOT NULL CONSTRAINT DF_KartuStok_Hpp DEFAULT(0),
	JenisMutasiID VARCHAR(5) NOT NULL CONSTRAINT DF_KartuStok DEFAULT(''),
	MutasiID VARCHAR(10) NOT NULL CONSTRAINT DF_KartuStok_MutasiID DEFAULT(''), 
	TglMutasi VARCHAR(10) NOT NULL CONSTRAINT DF_KartuStok_TglMutasi DEFAULT(''),
	JamMutasi VARCHAR(8) NOT NULL CONSTRAINT DF_KartuStok_JamMutasi DEFAULT(''),

    CONSTRAINT PK_KartuStok_KartuStokID PRIMARY KEY CLUSTERED (KartuStokID)
)
GO

CREATE INDEX IX_KartuStok_BrgTglJam
	ON KartuStok (BrgID, TglMutasi, JamMutasi)
GO


