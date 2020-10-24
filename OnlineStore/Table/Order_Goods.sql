CREATE TABLE [dbo].[Order_Goods]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[orderId] int NULL,
	[goodsId] int NULL,
	[quantityGoods] int
)
