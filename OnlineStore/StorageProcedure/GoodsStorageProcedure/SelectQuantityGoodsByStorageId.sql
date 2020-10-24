CREATE PROCEDURE [dbo].[SelectQuantityGoodsByStorageId]
	@storageId int 	
AS
	SELECT B.Brand,B.Model, G.Price, S.Name as StorageName, S.Address,s.Phone,S.Email, GS.QuantityGoods from dbo.Goods_Storage as GS
	join dbo.Goods as G on G.Id = GS.GoodsId	
	join dbo.Storage as S on s.Id = GS.StorageId
	join dbo.Brand as B on B.id = G.BrandId
	left join dbo.Country as C on C.Id = s.CountryId
	left join dbo.City as CY on CY.Id = s.CityId
	where GS.StorageId = @storageId


