﻿CREATE TABLE [dbo].[Penjualan]
(
	PenjualanID VARCHAR(10) NOT NULL CONSTRAINT DF_Penjualan_PenjualanID DEFAULT(''),
	TglPenjualan VARCHAR(10) NOT NULL CONSTRAINT DF_Penjualan_TgPenjualan DEFAULT('3000-01-01'),
	JamPenjualan VARCHAR(8) NOT NULL CONSTRAINT DF_Penjualan_JamPenjualan DEFAULT('00:00:00'),
	UserrID VARCHAR(50) NOT NULL CONSTRAINT DF_Penjualan_UserrID DEFAULT(''),
	CustomerID VARCHAR(6) NOT NULL CONSTRAINT DF_Penjualan_CustomerID DEFAULT(''),

	BuyerName VARCHAR(30) NOT NULl CONSTRAINT DF_Penjualan_BuyerName DEFAULT(''),
	Alamat VARCHAR(128) NOT NULL CONSTRAINT DF_Penjualan_Alamat DEFAULT(''),
	NoTelp VARCHAR(30) NOT NULL CONSTRAINT DF_Penjualan_NoTelp DEFAULT(''),
	Catatan VARCHAR(255) NOT NULL CONSTRAINT DF_Penjualan_Catatan DEFAULT(''),

    IsBayarDeposit BIT NOT NULL CONSTRAINT DF_Penjualan_IsBayarDeposit DEFAULT(0), 
    DepositID VARCHAR(10) NOT NULL CONSTRAINT DF_Penjualan_DepositID DEFAULT(''),
	NilaiDeposit DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiDeposit DEFAULT(''),

	NilaiBiayaKirim DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiBiayaKirim DEFAULT(0),
	NilaiTotal DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiTotal DEFAULT(0),
	NilaiDiskonLain DECIMAL (18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiDiskonLAin DEFAULT(0),
	NilaiBiayaLain DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiBiayaLain DEFAULT(0),
	NilaiGrandTotal DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiGrandTotal DEFAULT(0),

	NilaiBayar DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiBayar DEFAULT(0),
	NilaiKembali DECIMAL(18,2) NOT NULL CONSTRAINT DF_Penjualan_NilaiKembali DEFAULT(0)

    CONSTRAINT PK_Penjualan_PenjualanID PRIMARY KEY CLUSTERED (PenjualanID)
)
GO

