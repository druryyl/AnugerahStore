﻿CREATE TABLE [dbo].[StokAdjustment2]
(
	StokAdjustmentID VARCHAR(10) NOT NULL CONSTRAINT DF_StokAdjustment2_StokAdjustmentID DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_StokAdjustment2_NoUrut DEFAULT(0),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_StokAdjustment2_BrgID DEFAULT(''),
	QtyAdjust DECIMAL(18,0) NOT NULL CONSTRAINT DF_StokAdjustment2_QtyAdjust DEFAULT(0),
	HppAdjust DECIMAL(18,0) NOT NULL CONSTRAINT DF_StokAdjustment2_HppAdjust DEFAULT(0),
)
GO

CREATE UNIQUE CLUSTERED INDEX IX_StokAdjustment2_StokAdjustmentID_BrgID
	ON StokAdjustment2 (StokAdjustmentID, BrgID)
GO
