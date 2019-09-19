CREATE TABLE [dbo].[LunasPiutangDetil]
(
	LunasPiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutangDetil_LunasPIutangID DEFAULT(''),
	LunasPiutangID2 VARCHAR(13) NOT NULL CONSTRAINT DF_LunasPIutangDetil_LunasPIutangID2 DEFAULT(''),
	PiutangID VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPiutangDetil_PiutangID DEFAULT(''),
	Tgl VARCHAR(10) NOT NULL CONSTRAINT DF_LunasPIutangDetil_Tgl DEFAULT('3000-01-01'),
	NilaiSisaPiutang DECIMAL(18,0) NOT NULL CONSTRAINT DF_LunasPiutangDetil_NilasiSisaPiutang DEFAULT(0),
	NilaiBayar DECIMAL(18,0) NOT NULL CONSTRAINT DF_LunasPiutangDetil_NilaiBayar DEFAULT(0),

	CONSTRAINT PK_LunasPiutangDetil_LunasPiutangID2 PRIMARY KEY CLUSTERED(LunasPiutangID2)
)
