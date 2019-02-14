CREATE TABLE [dbo].[JenisBiaya]
(
	JenisBiayaID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisBiaya_JenisBiayaID DEFAULT(''),
	JenisBiayaName VARCHAR(15) NOT NULL CONSTRAINT DF_JenisBiaya_JenisBiayaName DEFAULT(''),

	CONSTRAINT PK_JenisBiaya_JenisBiayaID PRIMARY KEY CLUSTERED(JenisBiayaID)
)
