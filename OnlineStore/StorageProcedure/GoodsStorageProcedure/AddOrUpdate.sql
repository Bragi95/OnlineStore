CREATE PROCEDURE [dbo].[AddOrUpdate]
	@GoodsId int ,
	@StorageId int,
	@Quantity int,
	@Sale bit = 0
AS
declare
@result bigint
set @result = @GoodsId
if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and StorageId = @StorageId)
 begin
	if(@Sale = 0)
	begin
	 update dbo.Goods_Storage
	  set 
	   QuantityGoods += @Quantity
	end
	else
	begin
	  update dbo.Goods_Storage
	   set 
	    QuantityGoods -= @Quantity
	end
 end
else
 begin
	insert into dbo.Goods_Storage
	values(@GoodsId,@StorageId,@Quantity)
 if(@result is null)set @result = SCOPE_IDENTITY()
 end

select * from dbo.Goods_Storage as GS
where gs.Id = @result
