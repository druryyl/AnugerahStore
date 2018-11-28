﻿CREATE TABLE [dbo].[TipeBrg]
(
	[TipeBrgID] VARCHAR(5) NOT NULL CONSTRAINT DF_TipeBrg_TipeBrgID DEFAULT(''),
	TipeBrgName VARCHAR(30) NOT NULL CONSTRAINT DF_TipeBrg_TipeBrgName DEFAULT(''), 
    JenisBrgID VARCHAR(3) NOT NULL CONSTRAINT DF_TipeBrg_JenisBrgID DEFAULT('')
)
GO

CREATE UNIQUE CLUSTERED INDEX IX_TipeBrg_TipeBrgID
	ON TipeBrg (TipeBrgID)
GO