﻿CREATE TABLE [dbo].[OrderJual2]
(
	OrderJualID VARCHAR(10) NOT NULL CONSTRAINT DF_OrderJual2_OrderJualID DEFAULT(''),
	OrderJualID2 VARCHAR(14) NOT NULL CONSTRAINT DF_OrderJual2_OrderJualID2 DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_OrderJual2_NoUrut DEFAULT(0),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_OrderJual2_BrgID DEFAULT(''),
	BPStokID VARCHAR(15) NOT NULL CONSTRAINT DF_OrderJual2_StokControl DEFAULT(''),
	Qty DECIMAL(18,2) NOT NULL CONSTRAINT DF_OrderJual2_Qty DEFAULT(0),
	Harga DECIMAL(18,2) NOT NULL CONSTRAINT DF_OrderJual2_Harga DEFAULT(0),
	Diskon DECIMAL(18,2) NOT NULL CONSTRAINT DF_OrderJual2_Diskon DEFAULT(0),
	SubTotal DECIMAL(18,2) NOT NULL CONSTRAINT DF_OrderJual2_SubTotal DEFAULT(0),

    CONSTRAINT PK_OrderJual2_PenjualanID2 PRIMARY KEY CLUSTERED (OrderJualID2)
)