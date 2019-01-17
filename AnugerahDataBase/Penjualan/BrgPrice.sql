﻿CREATE TABLE [dbo].[BrgPrice]
(
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BrgPrice_BrgID DEFAULT(''),
	Qty DECIMAL(18,0) NOT NULL CONSTRAINT DF_BrgPrice_Qty DEFAULT(0),
	Harga DECIMAL(18,0) NOT NULL CONSTRAINT DF_BrgPrice_Harga DEFAULT(0),
	Diskon DECIMAL(18,0) NOT NULL CONSTRAINT DF_BrgPrice_Diskon DEFAULT(0)
)
GO

CREATE CLUSTERED INDEX IX_BrgPrice_BrgID 
	ON BrgPrice (BrgID)
GO