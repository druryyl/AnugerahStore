CREATE TABLE [dbo].[LunasPiutang]
(
	LunasPiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutang_LunasPiutangID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutang_Tgl DEFAULT('3000-01-01'),
	Jam VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutang_Jam DEFAULT('00:00:00'),
	PihakKeduaID VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutang_PihakKeduaID DEFAULT(''),
	JenisBayarID VARCHAR(3) NOT NULL CONSTRAINT DF_LunasPiutang_JenisBayarID DEFAULT(''),
	TotalNilaiSisaPiutang DECIMAL(18,2) NOT NULL CONSTRAINT DF_LunasPiutang_TotalNilaiSisaPiutang DEFAULT(0),
	TotalNilaiBayar DECIMAL(18,2) NOT NULL CONSTRAINT DF_LunasPiutang_TotalNilaiBayar DEFAULT(0),

	CONSTRAINT PK_LunasPiutang_LunasPiutangID PRIMARY KEY CLUSTERED (LunasPiutangID)
)