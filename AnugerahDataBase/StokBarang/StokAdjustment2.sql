CREATE TABLE [dbo].[StokAdjustment2]
(
	StokAdjustmentID VARCHAR(10) NOT NULL CONSTRAINT DF_StokAdjustment2_StokAdjustmentID DEFAULT(''),
	StokAdjustmentID2 VARCHAR(14) NOT NULL CONSTRAINT DF_StokAdjustment2_StokAdjustmentID2 DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_StokAdjustment2_NoUrut DEFAULT(0),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_StokAdjustment2_BrgID DEFAULT(''),
	QtyAwal DECIMAL(18,2) NOT NULL CONSTRAINT DF_StokAdjustment2_QtyAwal DEFAULT(0),
	QtyAdjust DECIMAL(18,2) NOT NULL CONSTRAINT DF_StokAdjustment2_QtyAdjust DEFAULT(0),
	QtyAkhir DECIMAL(18,2) NOT NULL CONSTRAINT DF_StokAdjustment2_QtyAkhir DEFAULT(0),
	HppAdjust DECIMAL(18,2) NOT NULL CONSTRAINT DF_StokAdjustment2_HppAdjust DEFAULT(0),

	CONSTRAINT PK_StokAdjustment_StokAdjustmentID2 PRIMARY KEY CLUSTERED(StokAdjustmentID2)
)
GO

CREATE UNIQUE INDEX IX_StokAdjustment2_StokAdjustmentID_BrgID
	ON StokAdjustment2 (StokAdjustmentID, BrgID)
GO
