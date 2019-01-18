﻿CREATE TABLE [dbo].[StokControl]
(
	StokControlID VARCHAR(13) NOT NULL CONSTRAINT DF_Stok_StokID DEFAULT(''),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_Stok_BrgID DEFAULT(''),
	TglMasuk VARCHAR(10) NOT NULL CONSTRAINT DF_Stok_TglMasuk DEFAULT('3000-01-01'),
	JamMasuk VARCHAR(8) NOT NULL CONSTRAINT DF_Stok_JamMasuk DEFAULT('00:00:00'),
	TrsMasukID VARCHAR(10) NOT NULL CONSTRAINT DF_Stok_TrsMasukID DEFAULT(''),
	TrsDOID VARCHAR(10) NOT NULL CONSTRAINT DF_Stok_TrsDOID DEFAULT(''),
	BatchNo VARCHAR(13) NOT NULL CONSTRAINT DF_Stok_BatchNo DEFAULT(''),
	QtyIn DECIMAL(18,0) NOT NULL CONSTRAINT DF_Stok_QtyIn DEFAULT(0),
	QtySaldo DECIMAL(18,0) NOT NULL CONSTRAINT DF_Stok_QtySaldo DEFAULT(0),
	Hpp DECIMAL NOT NULL CONSTRAINT DF_Stok_Hpp DEFAULT (0), 

    CONSTRAINT PK_Stok_StokID PRIMARY KEY CLUSTERED(StokControlID)
)
GO

CREATE INDEX IX_Stok_BatchNo 
	ON StokControl (BatchNo)
GO

CREATE INDEX IX_Stok_BrgID_TglMasuk_JamMasuk_QtySaldo
	ON StokControl (BrgID, TglMasuk, JamMasuk, QtySaldo)
GO
