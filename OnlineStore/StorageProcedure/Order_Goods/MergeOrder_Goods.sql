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
on(OG.orderId = sourse.orderId)
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

	exec SelectOrderGoodsByOrderId @orderId