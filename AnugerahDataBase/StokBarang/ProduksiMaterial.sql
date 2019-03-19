﻿CREATE TABLE [dbo].[ProduksiMaterial]
(
	ProduksiID VARCHAR(10) NOT NULL CONSTRAINT DF_ProduksiMaterial_ProduksiID DEFAULT(''),
	ProduksiID2 VARCHAR(14) NOT NULL CONSTRAINT DF_ProduksiMaterial_ProduksiID2 DEFAULT(''),
	NoUrut DECIMAL(18,0) NOT NULL CONSTRAINT DF_ProduksiMaterial_NoUrut DEFAULT(0),
	BrgID VARCHAR(5) NOT NULL CONSTRAINT DF_ProduksiMaterial_BrgID DEFAULT(''),
	Qty DECIMAL(18,0) NOT NULL CONSTRAINT DF_ProduksiMaterial_Qty DEFAULT(0),
	Hpp DECIMAL(18,0) NOT NULL CONSTRAINT DF_ProduksiMaterial_Hpp DEFAULT(0),
	StokControl VARCHAR(20) NOT NULL CONSTRAINT DF_ProduksiMaterial_StokControl DEFAULT(''),

	CONSTRAINT PK_ProduksiMaterial_ProduksiID2 PRIMARY KEY CLUSTERED(ProduksiID2)
)
