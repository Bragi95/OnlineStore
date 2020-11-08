CREATE PROCEDURE [dbo].[AddOrUpdate]
	@GoodsId int ,
	@StorageId int,
	@Quantity int,
	@Sale bit = null
AS
if exists(  select * from dbo.Goods_Storage as GS where GS.GoodsId = @GoodsId and GS.StorageId = @StorageId)
 begin
	if(@Sale is null)
	begin
	 update dbo.Goods_Storage
	  set 
	   QuantityGoods += @Quantity
	   where GoodsId = @GoodsId and StorageId = @StorageId
	end
	else
	begin
	  update dbo.Goods_Storage
	   set 
	    QuantityGoods -= @Quantity
		where GoodsId = @GoodsId and StorageId = @StorageId
	end
 end
else
 begin
	insert into dbo.Goods_Storage
	values(@GoodsId,@StorageId,@Quantity)
 end

SELECT G.Id , G.Brand,G.Model, G.Price, CY.Id, CY.Name as City, S.Id, S.Name as StorageName, S.Address,s.Phone,S.Email,GS.Id, GS.QuantityGoods from dbo.Goods_Storage as GS
	join dbo.Goods as G on G.Id = GS.GoodsId	
	join dbo.Storage as S on s.Id = GS.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	where GS.StorageId = @StorageId and  GS.GoodsId = @GoodsId
