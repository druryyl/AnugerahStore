﻿CREATE TABLE [dbo].[PurchaseDetil]
(
	PurchaseID VARCHAR(10) NOT NULL CONSTRAINT DF_PurchaseDetil_PurchaseID DEFAULT(''),
	PurchaseDetilID VARCHAR(13) NOT NULL CONSTRAINT DF_PurchaseDetil_PurchaseDetilID DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_Purchase_NoUrut DEFAULT(0),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_PurchaseDetil_BrgID DEFAULT(''),
	Qty DECIMAL(18,0) NOT NULL CONSTRAINT DF_PurchaseDetil_Qty DEFAULT(0),
	Harga DECIMAL(18,0) NOT NULL CONSTRAINT DF_PurchaseDetil_Harga DEFAULT(0),
	Diskon DECIMAL(18,0) NOT NULL CONSTRAINT DF_PurchaseDetil_Diskon DEFAULT(0),
	TaxProsen DECIMAL(18,2) NOT NULL CONSTRAINT DF_PurchaseDetil_TaxProsen DEFAULT(0),
	TaxRupiah DECIMAL(18,0) NOT NULL CONSTRAINT DF_PurchaseDetil_TaxRupiah DEFAULT(0),
	SubTotal DECIMAL(18,0) NOT NULL CONSTRAINT DF_PurchaseDetil_SubTotal DEFAULT(0),

	CONSTRAINT PK_PurchaseDetil_PurchaseDetilID PRIMARY KEY CLUSTERED(PurchaseDetilID)
)
