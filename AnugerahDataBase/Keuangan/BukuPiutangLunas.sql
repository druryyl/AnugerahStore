CREATE TABLE [dbo].[BukuPiutangLunas]
(
	BukuPiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutangLunas_BukuPiutangID DEFAULT(''),
	BukuPiutangLunasID VARCHAR(13) NOT NULL CONSTRAINT DF_BukuPiutangLunas_BukuPiutangLunasID DEFAULT(''),
	TglLunas VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutangLunas_TglLunas DEFAULT('3000-01-01'),
	JamLunas VARCHAR(8) NOT NULL CONSTRAINT DF_BukuPiutangLunas_JamLunas DEFAULT('00:00:00'),
	NilaiLunas DECIMAL(18,0) NOT NULL CONSTRAINT DF_BukuPiutangLunas_NilaiLunas DEFAULT(0),
	BukuKasID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutangLunas_BukuKasID DEFAULT(0),

	CONSTRAINT PK_BukuPiutangLunas_BukuPiutangLunasID PRIMARY KEY CLUSTERED (BukuPiutangLunasID)
)
