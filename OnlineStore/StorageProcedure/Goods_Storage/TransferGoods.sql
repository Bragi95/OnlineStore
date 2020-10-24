CREATE PROCEDURE [dbo].[TransferGoods]
	@sender int,
	@GoodsId int,
	@recipiend int,
	@quantityGoods int
AS
declare
@sendlerId int,
@recipiendId int
if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and StorageId = @sender and (GS.QuantityGoods - @quantityGoods) > 0)
begin
	Update dbo.Goods_Storage
	set
		QuantityGoods -= @quantityGoods,
		@sendlerId = Id
	where GoodsId = @GoodsId and StorageId = @sender
end
else  THROW 404, 'The product is not available in this store', 1;  

if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and StorageId = @recipiend )
begin
	Update dbo.Goods_Storage 
	set
		QuantityGoods += @quantityGoods,
		@recipiendId = id
	where GoodsId = @GoodsId and StorageId = @recipiend
end
else
 begin
	insert into dbo.Goods_Storage
	values(@GoodsId,@recipiend,@quantityGoods)
 set @recipiendId = SCOPE_IDENTITY()
end

select @sendlerId, @recipiendId