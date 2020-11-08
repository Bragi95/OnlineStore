CREATE PROCEDURE [dbo].[SelectAllQuantityGoods]
AS
SELECT B.Brand,B.Model, G.Price,CY.Name as City, S.Name as StorageName, S.Address,s.Phone,S.Email, GS.QuantityGoods from dbo.Goods_Storage as GS
	join dbo.Goods as G on G.Id = GS.GoodsId	
	join dbo.Storage as S on s.Id = GS.StorageId
	join dbo.Brand as B on B.id = G.BrandId
	left join dbo.City as CY on CY.Id = s.CityId
	
