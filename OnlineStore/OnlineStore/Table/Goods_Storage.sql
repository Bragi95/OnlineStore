CREATE TABLE [dbo].[Goods_Storage]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[GoodsId] int,
	[StorageId] int,
	[QuantityGoods] int
)
