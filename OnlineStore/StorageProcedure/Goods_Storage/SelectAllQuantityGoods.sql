CREATE PROCEDURE [dbo].[SelectAllQuantityGoods]
AS
select
GS.Id, GS.QuantityGoods, 
G.Id , G.Brand,G.Model, G.Price, 
S.Id, S.Name, S.Address,s.Phone,S.Email,
CY.Id, CY.Name,
C.Id,C.Name
from dbo.Goods_Storage as GS
	join dbo.Goods as G on G.Id = GS.GoodsId	
	join dbo.Storage as S on s.Id = GS.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	left join dbo.Country as C on C.Id = s.CountryId
