﻿CREATE TABLE [dbo].[DepositDetil]
(
	DepositID VARCHAR(10) NOT NULL CONSTRAINT DF_DepositDetil_DepositID DEFAULT(''),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_DepositDetil_BrgID DEFAULT(''),
	Qty DECIMAL(18,2) NOT NULL CONSTRAINT DF_DepositDetil_Qty DEFAULT(0),
	Harga DECIMAL(18,2) NOT NULL CONSTRAINT DF_DepositDetil_Harga DEFAULT(0),
	Diskon DECIMAL(18,2) NOT NULL CONSTRAINT DF_DepositDetil_Diskon DEFAULT(0),
	SubTotal DECIMAL(18,2) NOT NULL CONSTRAINT DF_DepositDetil_SubTotal DEFAULT(0),

)
GO

CREATE CLUSTERED INDEX IX_DepositDetil_DepositID 
	ON DepositDetil (DepositID)
GO