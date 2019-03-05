﻿CREATE TABLE [dbo].[BPPurchaseReceipt]
(
	BPPurchaseID VARCHAR(10) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_BPPurchaseID DEFAULT(''),
	BPReceiptID VARCHAR(10) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_BPReceiptID DEFAULT(''),
	BPDetilID VARCHAR(14) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_BPDetilID DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_NoUrut DEFAULT(0),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_Tgl DEFAULT('3000-01-01'),
	Jam VARCHAR(8) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_Jam DEFAULT('00:00:00'),
	Keterangan VARCHAR(128) NOT NULL CONSTRAINT DF_BP_PurchaseReceipt_Keterangan DEFAULT(''),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_BrgID DEFAULT(''),
	QtyPurchase DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_QtyPurchase DEFAULT(0),
	QtyReceipt DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_QtyReceipt DEFAULT(0),
	Harga DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_Harga DEFAULT(0),
	Diskon DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_Diskon DEFAULT(0),
	Tax DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_Tax DEFAULT(0),
	SubTotal DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPPurchaseReceipt_SubTotal DEFAULT(0)
)
GO

CREATE CLUSTERED INDEX IX_BPPurchaseReceipt_BPPurchaseID_BPReceiptID_BPDetilID 
	ON BPPurchaseReceipt (BPPurchaseID, BPReceiptID, BPDetilID)
GO

