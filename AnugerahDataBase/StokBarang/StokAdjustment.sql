CREATE TABLE [dbo].[StokAdjustment]
(
	StokAdjustmentID VARCHAR(10) NOT NULL CONSTRAINT DF_StokAdjustment_StokAdjustmentID DEFAULT(''),
	TglStokAdjustment VARCHAR(10) NOT NULL CONSTRAINT DF_StokAdjustment_TglStokAdjustment DEFAULT('3000-01-01'),
	JamStokAdjustment VARCHAR(8) NOT NULL CONSTRAINT DF_StokAdjustment_JamStokAdjustment DEFAULT('00:00:00'),
	UserrID VARCHAR(30) NOT NULL CONSTRAINT DF_StokAdjustment_UserrID DEFAULT(''),
	Keterangan VARCHAR(255) NOT NULL CONSTRAINT DF_STokAdjustment_Keterangan DEFAULT(''),

	CONSTRAINT PK_StokAdjustment_StokAdjustmentID PRIMARY KEY CLUSTERED(StokAdjustmentID)
)
