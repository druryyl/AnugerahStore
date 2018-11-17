CREATE TABLE [dbo].[ParameterNo]
(
	[Prefix] VARCHAR(10) NOT NULL CONSTRAINT DF_ParamterNo_Prefix DEFAULT(''),
	[Value] DECIMAL(18,0) NOT NULL CONSTRAINT DF_ParameterNo_Value DEFAULT(0)
)
GO

CREATE UNIQUE CLUSTERED INDEX IX_PrameterNo_Prefix ON ParameterNo (Prefix)
GO

