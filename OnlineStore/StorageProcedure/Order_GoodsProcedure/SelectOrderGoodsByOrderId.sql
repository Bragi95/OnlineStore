CREATE PROCEDURE [dbo].[SelectOrderGoodsByOrderId]
	@orderId int 
	
AS
	select 
     B.Id, B.Brand, B.Model,
	G.id, G.Price ,
	OG.Id , Og.quantityGoods
   from dbo.[Order_Goods] as OG
join dbo.[Order] as O on O.Id = @orderId
join dbo.Goods as G on G.Id = OG.goodsId
left join dbo.Brand as B on B.id = G.BrandId
where O.Id = @orderId