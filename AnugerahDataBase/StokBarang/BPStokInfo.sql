﻿CREATE TABLE [dbo].[BPStokInfo]
(
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BPStokInfo_BrgID DEFAULT(''),
	Qty DECIMAL(18,0) NOT NULL CONSTRAINT DF_BPStokInfo_Qty DEFAULT(0),

	CONSTRAINT PK_BrgStokInfo_BrgID PRIMARY KEY CLUSTERED(BrgID)
)
