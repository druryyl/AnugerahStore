CREATE TABLE [dbo].[LunasKasBonDetil]
(
	LunasKasBonID VARCHAR(10) NOT NULL CONSTRAINT DF_LunasKasBonDetil_LunasKasBonID DEFAULT(''),
	LunasKasBonDetilID VARCHAR(13) NOT NULL CONSTRAINT DF_LunasKasBonDetil_LunasKasBonDetilID DEFAULT(''),
	JenisLunasID VARCHAR(3) NOT NULL CONSTRAINT DF_LunasKasBonDetil_JenisLunasID DEFAULT(''),
	NilaiLunas DECIMAL(18,0) NOT NULL CONSTRAINT DF_LunasKasBonDetil_NilaiLunas DEFAULT(0),
)