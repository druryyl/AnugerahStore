CREATE TABLE [dbo].[BukuPiutang]
(
	BukuPiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutang_BukuPiutangID DEFAULT(''),
	TglPiutang VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutang_TglPiutang DEFAULT(''),
	JamPiutang VARCHAR(8) NOT NULL CONSTRAINT DF_BukuPiutang_JamPiutang DEFAULT(''),
	PihakKetiga VARCHAR(10) NOT NULL CONSTRAINT DF_BukuPiutang_PihakKetiga DEFAULT(''),
	NilaiPiutang DECIMAL(18,0) NOT NULL CONSTRAINT DF_BukuPiutang_NilaiPiutang DEFAULT(0),
	SisaTagihan DECIMAL(18,0) NOT NULL CONSTRAINT DF_BukuPiutang_SisaPiutang DEFAULT(0),
	Keterangan VARCHAR(50) NOT NULL CONSTRAINT DF_BukuPiutang_Keterangan DEFAULT(0),

	CONSTRAINT PK_BukuPiutang_BukuPiutangID PRIMARY KEY CLUSTERED (BukuPiutangID)
)