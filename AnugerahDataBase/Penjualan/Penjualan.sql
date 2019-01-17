﻿CREATE TABLE [dbo].[Penjualan]
(
	PenjualanID VARCHAR(10) NOT NULL CONSTRAINT DF_Penjualan_PenjualanID DEFAULT(''),
	TglPenjualan VARCHAR(10) NOT NULL CONSTRAINT DF_Penjualan_TgPenjualan DEFAULT('3000-01-01'),
	JamPenjualan VARCHAR(8) NOT NULL CONSTRAINT DF_Penjualan_JamPenjualan DEFAULT('00:00:00'),
	UserrID VARCHAR(50) NOT NULL CONSTRAINT DF_Penjualan_UserrID DEFAULT(''),
	CustomerName VARCHAR(30) NOT NULl CONSTRAINT DF_Penjualan_CustomerName DEFAULT(''),
	CustomerID VARCHAR(5) NOT NULL CONSTRAINT DF_Penjualan_CustomerID DEFAULT(''),
	Alamat VARCHAR(128) NOT NULL CONSTRAINT DF_Penjualan_Alamat DEFAULT(''),
	NoTelp VARCHAR(30) NOT NULL CONSTRAINT DF_Penjualan_NoTelp DEFAULT(''),
	NilaiTotal DECIMAL(18,0) NOT NULL CONSTRAINT DF_Penjualan_NilaiTotal DEFAULT(0),
	NilaiDiskonLain DECIMAL (18,0) NOT NULL CONSTRAINT DF_Penjualan_NilaiDiskonLAin DEFAULT(0),
	NilaiBiayaLain DECIMAL(18,0) NOT NULL CONSTRAINT DF_Penjualan_NilaiBiayaLain DEFAULT(0),
	NilaiGrandTotal DECIMAL(18,0) NOT NULL CONSTRAINT DF_Penjualan_NilaiGrandTotal DEFAULT(0),

	CONSTRAINT PK_Penjualan_PenjualanID PRIMARY KEY CLUSTERED (PenjualanID)
)
GO
