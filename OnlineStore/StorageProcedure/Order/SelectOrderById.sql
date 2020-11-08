CREATE PROCEDURE [dbo].[SelectOrderById]
@orderId int 
	
AS
select 
	OG.Id , Og.quantityGoods,	
	o.id, O.TotalCost, O.DateOrder,
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    U. Id, U.Name, U.LastName, U.Address, U.Phone  ,  
    G.Id, G.Brand, G.Model,G.PowerConsumption,G.Weight,G.YearOfManufacture, g.Price 
 from dbo.[Order] as O
    left join dbo.Order_Goods as OG on Og.orderId = O.Id
	left join dbo.Goods as G on G.Id = OG.goodsId
	join dbo.[User] as U on U.Id = O.UserId
	join dbo.Storage as S on S.Id = O.StorageId
	join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.Id = @orderId