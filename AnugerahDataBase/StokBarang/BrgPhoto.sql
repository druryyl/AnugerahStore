﻿CREATE TABLE [dbo].[BrgPhoto]
(
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BrgPhoto_BrgID DEFAULT(''),
	PhotoFileName VARCHAR(255) NOT NULL CONSTRAINT DF_BrgPhoto_PhotoFileName DEFAULT(''),
)
