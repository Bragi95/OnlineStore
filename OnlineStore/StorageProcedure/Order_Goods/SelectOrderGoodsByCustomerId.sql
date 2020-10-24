CREATE PROCEDURE [dbo].[SelectOrderGoodsByCustomerId]
 @CustomerId int 
	
AS
select 
	o.id, 
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    C. Id, C.Name, C.LastName, C.Address, c.Phone  ,  
    G.Id, G.Brand, G.Model, G.Price ,
	OG.Id , Og.quantityGoods
   from dbo.[Order_Goods] as OG
join dbo.[Order] as O on O.CustomerId = @CustomerId
join dbo.Goods as G on G.Id = OG.goodsId
left join dbo.Customer as C on C.Id = O.CustomerId
left join dbo.Storage as S on S.Id = O.StorageId
left join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
left join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where OG.OrderId = O.id
