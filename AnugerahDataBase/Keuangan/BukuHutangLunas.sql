CREATE TABLE [dbo].[BukuHutangLunas]
(
	BukuHutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutangLunas_BukuHutangID DEFAULT(''),
	BukuHutangLunasID VARCHAR(13) NOT NULL CONSTRAINT DF_BukuHutangLunas_BukuHutangLunasID DEFAULT(''),
	TglLunas VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutangLunas_TglLunas DEFAULT('3000-01-01'),
	JamLunas VARCHAR(8) NOT NULL CONSTRAINT DF_BukuHutangLunas_JamLunas DEFAULT('00:00:00'),
	NilaiLunas DECIMAL(18,2) NOT NULL CONSTRAINT DF_BukuHutangLunas_NilaiLunas DEFAULT(0),
	BukuKasID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuHutangLunas_BukuKasID DEFAULT(0),

	CONSTRAINT PK_BukuHutangLunas_BukuHutangLunasID PRIMARY KEY CLUSTERED (BukuHutangLunasID)
)
