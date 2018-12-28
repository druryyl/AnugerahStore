CREATE TABLE [dbo].[PriceTag]
(
	PriceTagID VARCHAR(3) NOT NULL CONSTRAINT DF_PriceGroup_PriceGroupID DEFAULT(''),
	PriceTagName VARCHAR(30) NOT NULL CONSTRAINT DF_PriceGroup_PriceName DEFAULT(''),
)
