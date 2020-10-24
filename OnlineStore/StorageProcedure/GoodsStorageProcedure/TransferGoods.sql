CREATE PROCEDURE [dbo].[TransferGoods]
	@sendler int,
	@GoodsId int,
	@recipiend int,
	@Quantity int
AS
declare
@sendlerId int,
@recipiendId int
if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and StorageId = @sendler and (GS.QuantityGoods - @Quantity) > 0)
begin
	Update dbo.Goods_Storage
	set
		QuantityGoods -= @Quantity,
		@sendlerId = Id
	where GoodsId = @GoodsId and StorageId = @sendler
end
else return select 'The product is not available in this store' raiseerror

if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and StorageId = @recipiend )
begin
	Update dbo.Goods_Storage 
	set
		QuantityGoods += @Quantity,
		@recipiendId = id
	where GoodsId = @GoodsId and StorageId = @recipiend
end
else
 begin
	insert into dbo.Goods_Storage
	values(@GoodsId,@recipiend,@Quantity)
 set @recipiendId = SCOPE_IDENTITY()
end

select @sendlerId, @recipiendId