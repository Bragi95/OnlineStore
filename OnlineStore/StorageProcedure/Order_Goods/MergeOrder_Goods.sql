CREATE PROCEDURE [dbo].[MergeOrder_Goods]
	@orderId int = null ,
	@goodsId int = null,
	@quantityGoods int = null
AS
Merge dbo.[Order_Goods] AS OG
using (select	
	@orderId,
	@goodsId,
	@quantityGoods)
As sourse (	
	orderId,
	goodsId,
	quantityGoods)
on(OG.orderId = sourse.orderId and OG.goodsId = @goodsId)
WHEN MATCHED THEN
update set	
	goodsId = sourse.goodsId,
	quantityGoods = sourse.quantityGoods	
WHEN NOT MATCHED THEN
insert (
	orderId,
	goodsId,
	quantityGoods)
values (
	@orderId,
	@goodsId,
	@quantityGoods);
select
	O.Id,
    G.Id, G.Brand, G.Model, G.Price ,
	OG.Id , Og.quantityGoods
from dbo.[Order_Goods] as OG
join dbo.[Order] as O on O.Id = OG.orderId
join dbo.Goods as G on G.Id = OG.goodsId
where OG.orderId = @orderId and OG.goodsId = @goodsId