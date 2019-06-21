﻿CREATE TABLE [dbo].[Purchase]
(
	PurchaseID VARCHAR(10) NOT NULL CONSTRAINT DF_Purchase_PurchaseID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_Purchase_Tgl DEFAULT('3000-01-01'),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_Purchase_Jam DEFAULT('00:00:00'),
	SupplierID VARCHAR(5) NOT NULL CONSTRAINT DF_Purchase_SupplierID DEFAULT(''),
	Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_Purchase_Keterangan DEFAULT(''),
	TotalHarga DECIMAL(18,2) NOT NULL CONSTRAINT DF_Purchase_TotalHarga DEFAULT(0),
	Diskon DECIMAL (18,2) NOT NULL CONSTRAINT DF_Purchase_Diskon DEFAULT(0),
	BiayaLain DECIMAL (18,2) NOT NULL CONSTRAINT DF_Purchase_BiayaLain DEFAULT(0),
	GrandTotal DECIMAL (18,2) NOT NULL CONSTRAINT DF_Purchase_GrandTotal DEFAULT(0),
	IsClosed BIT NOT NULL CONSTRAINT DF_Purchase_IsClosed DEFAULT(0), 

    CONSTRAINT PK_Purchase_PurchaseID PRIMARY KEY CLUSTERED(PurchaseID)
)
