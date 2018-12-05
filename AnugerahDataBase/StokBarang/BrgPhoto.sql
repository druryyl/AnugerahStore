﻿CREATE TABLE [dbo].[BrgPhoto]
(
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BrgPhoto_BrgID DEFAULT(''),
	PhotoFileName VARCHAR(255) NOT NULL CONSTRAINT DF_BrgPhoto_PhotoFileName DEFAULT(''), 
    [NoUrut] DECIMAL NOT NULL CONSTRAINT DF_BrgPhoto_NoUrut DEFAULT 0,
)
GO

CREATE CLUSTERED INDEX IX_BrgPhoto_BrgID
	ON BrgPhoto (BrgID, NoUrut)
GO

	