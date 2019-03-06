CREATE TABLE [dbo].[Pegawai]
(
	PegawaiID VARCHAR(5) NOT NULL CONSTRAINT DF_Pegawai_PegawaiID DEFAULT(''),
	PegawaiName VARCHAR(20) NOT NULL CONSTRAINT DF_Pegawai_PegawaiName DEFAULT('')
)
