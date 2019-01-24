﻿CREATE TABLE [dbo].[Customer]
(
	CustomerID VARCHAR(6) NOT NULL CONSTRAINT DF_Member_CustomerID DEFAULT(''),
	CustomerName VARCHAR(30) NOT NULL CONSTRAINT DF_Customer_CustomerName DEFAULT(''),
	Alamat1 VARCHAR(50) NOT NULL CONSTRAINT DF_Customer_Alamat1 DEFAULT(''),
	Alamat2 VARCHAR(50) NOT NULL CONSTRAINT DF_Customer_Alamat2 DEFAULT(''),
	NoTelp VARCHAR(50) NOT NULL CONSTRAINT DF_Customer_NoTelp DEFAULT(''),
	ContactPerson VARCHAR(50) NOT NULL CONSTRAINT DF_Customer_ContactPerson DEFAULT(''),

	CONSTRAINT PK_Customer_CustomerID PRIMARY KEY CLUSTERED (CustomerID)
)
