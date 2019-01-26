CREATE TABLE [dbo].[PenjualanBayar]
(
	PenjualanID VARCHAR(10) NOT NULL CONSTRAINT DF_PenjualanBayar_PenjualanID DEFAULT(''),
	PenjualanID2 VARCHAR(13) NOT NULL CONSTRAINT DF_PenjualanBayar_PenjualanID2 DEFAULT(''),
	JenisBayarID VARCHAR(3) NOT NULL CONSTRAINT DF_PenjualanBayar_JenisBayarID DEFAULT(''),
	NilaiBayar DECIMAL(18,0) NOT NULL CONSTRAINT DF_PenjualanBayar_NilaiBayar DEFAULT(0),
	Catatan VARCHAR(50) NOT NULL CONSTRAINT DF_PenjualanBayar_Catatan DEFAULT(''),

	CONSTRAINT PK_PenjualanBayar_PenjualanID2 PRIMARY KEY CLUSTERED (PenjualanID2)
)
GO

CREATE INDEX IX_PenjualanBayar_PenjualanID 
	ON PenjualanBayar (PenjualanID)
GO
