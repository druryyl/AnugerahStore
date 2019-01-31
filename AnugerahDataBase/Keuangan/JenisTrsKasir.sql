CREATE TABLE [dbo].[JenisTrsKasir]
(
	JenisTrsKasirID VARCHAR(3) NOT NULL CONSTRAINT DF_JenisTrsKasir_JenisTrsKasirID DEFAULT(''),
	JenisTrsKasirName VARCHAR(20) NOT NULL CONSTRAINT DF_JenisTrsKasir_JenisTrsKasirName DEFAULT (''),
	IsKasKeluar BIT NOT NULL CONSTRAINT DF_JenisTrsKasir_IsKasKeluar DEFAULT(0),

	CONSTRAINT PK_JenisTrskasir_JenisTrsKasieID PRIMARY KEY CLUSTERED (JenisTrsKasirID)
)
