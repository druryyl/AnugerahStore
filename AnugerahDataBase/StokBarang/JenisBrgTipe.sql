CREATE TABLE [dbo].[JenisBrgTipe]
(
	[JenisBrgTipeID] VARCHAR(5) NOT NULL CONSTRAINT DF_JenisBrgTipe_JenisBrgTipeID DEFAULT(''),
	JenisBrgTipeName VARCHAR(30) NOT NULL CONSTRAINT DF_JenisBrgTipe_JenisBrgTipeName DEFAULT(''),
	JenisBrgID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisBrgTipe_JenisBrgID DEFAULT('')
)
GO

CREATE UNIQUE CLUSTERED INDEX IX_JenisBrgTipe_JenisBrgTipeID
	ON JenisBrgTipe (JenisBrgTipeID)
GO

