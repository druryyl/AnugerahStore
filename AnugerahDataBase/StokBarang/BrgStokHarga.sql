﻿CREATE TABLE [dbo].[BrgStokHarga]
(
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_BrgStokHarga_BrgID DEFAULT(''),
	Qty DECIMAL(18,2) NOT NULL CONSTRAINT DF_BrgStokHarga_Qty DEFAULT(0),
	Harga DECIMAL(18,2) NOT NULL CONSTRAINT DF_BrgStokHarga_Harga DEFAULT(0)

	CONSTRAINT PK_BrgStokHarga_BrgID PRIMARY KEY CLUSTERED(BrgID)
)
