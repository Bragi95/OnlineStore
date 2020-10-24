CREATE PROCEDURE [dbo].[SelectQuantityGoodsByStorageId]
	@id int
	
AS
SELECT G.Id , G.Brand,G.Model, G.Price, CY.Id, CY.Name as City, S.Id, S.Name as StorageName, S.Address,s.Phone,S.Email,GS.Id, GS.QuantityGoods from dbo.Goods_Storage as GS
	join dbo.Goods as G on G.Id = GS.GoodsId	
	join dbo.Storage as S on s.Id = GS.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	where GS.StorageId = @id