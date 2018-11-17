﻿CREATE TABLE [dbo].[Userr]
(
	[UserrID]		VARCHAR(10) NOT NULL CONSTRAINT DF_Userr_UserrID DEFAULT(''),
	[UserrName]		VARCHAR(30) NOT NULL CONSTRAINT DF_Userr_UserrName DEFAULT(''),
	[Password]		VARCHAR(50) NOT NULL CONSTRAINT DF_Userr_Password DEFAULT(''), 
)
GO

CREATE UNIQUE CLUSTERED INDEX [IX_Userr_UserrID] ON [dbo].[Userr] (UserrID)
GO


