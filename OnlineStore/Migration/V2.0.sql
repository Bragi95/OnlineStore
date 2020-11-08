USE [OnlineStore.Database]
GO

--create table [dbo].[DbVersion] 
--(
--   [Id] int NOT NULL PRIMARY KEY Identity (1,1),
--    [Created]   datetime2 (0)  constraint DF_DbVersion_Created default sysutcdatetime(), 
--    [Version] decimal(18,2)  not null 
--);

--if (select top(1) Version from dbo.DbVersion) is null 
--insert into dbo.DbVersion values(sysutcdatetime(),1.0)

--declare @dbVersion int 

--Select top(1) @dbVersion = Version 
--from dbo.DbVersion 
--order by Created DESC
--if @dbVersion >=2.0 set noexec on

EXEC sp_rename 'Goods_Storage', 'Storage_Product'
go
EXEC sp_rename 'Order_Goods', 'Order_Product'
go
EXEC sp_rename 'MergeOrder_Goods', 'MergeOrder_Product'
go
EXEC sp_rename 'SelectAllQuantityGoods', 'SelectAllQuantityProduct'
go
EXEC sp_rename 'SelectQuantityGoodsByStorageId', 'SelectQuantityProductByStorageId'
go
EXEC sp_rename 'TransferGoods', 'TransferProduct'
go
EXEC sp_rename 'FeedBack.GoodsId', 'ProductId', 'COLUMN';
go
EXEC sp_rename 'Storage_Product.GoodsId', 'ProductId', 'COLUMN';
go
EXEC sp_rename 'Storage_Product.QuantityGoods', 'Quantity', 'COLUMN';
go
EXEC sp_rename 'Order_Product.GoodsId', 'ProductId', 'COLUMN';
go
EXEC sp_rename 'Order_Product.QuantityGoods', 'Quantity', 'COLUMN';
go

CREATE TABLE [dbo].[TypeGoods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL	
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into dbo.TypeGoods Values('VacuumCleaner'),('Microwave'),('Washer'),('ElectricKettle'),('Multicookers')
GO

CREATE TABLE [dbo].[PropertiesGoods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GoodsId] [int]  null ,
	[Name] [nvarchar](100) NULL,	
	[Value] [nvarchar](100) NULL	
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int]  NOT NULL,
	[Brand] [nvarchar](30) NULL,
	[Model] [nvarchar](30) NULL,
	[CountryId] [int] NULL,
	[YearOfManufacture] [date] NULL,
	[Weight] [float] NULL,	
	[PowerConsumption] [float] null,
	[ColorId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE SelectPropertyById
	@Id int
AS
SELECT 
	PG.Id, PG.Name, PG.Value,
	P.Id, P.Brand, P.Model, P.Price,
	T.Id, T.Name,
	C.Id,C.Name
FROM dbo.PropertiesGoods AS PG
join dbo.Product AS P ON P.Id = PG.GoodsId
join dbo.TypeGoods AS T ON T.Id = P.TypeId
join dbo.Color AS C ON C.Id =.ColorId
WHERE PG.Id = @Id
go

CREATE PROCEDURE SelectPropertyByGoodsId
	@Id int
AS
SELECT 
	PG.Id, PG.Name, PG.Value,
	P.Id, P.Brand, P.Model, P.Price,
	T.Id, T.Name,
	C.Id,C.Name
FROM dbo.PropertiesGoods AS PG
join dbo.Product AS P ON P.Id = PG.GoodsId
join dbo.TypeGoods AS T ON T.Id = P.TypeId
join dbo.Color AS C ON C.Id = P.ColorId
WHERE PG.GoodsId = @Id
go

Create procedure Merge_Properties
	@Id int = null,
	@GoodsId int,
	@Name nvarchar(100),
	@Value nvarchar(100)
AS
DECLARE @result int
set @result = @Id
Merge [dbo].[PropertiesGoods] AS PG
using(select
	@Id ,
	@GoodsId,
	@Name,
	@Value)
As source(
	Id,
	GoodsId,
	Name,
	Value)
on (PG.Id = source.Id)
When MATCHED THEN
Update
set
	GoodsId = source.GoodsId,
	Name = source.Name,
	Value = source.Value
WHEN NOT MATCHED THEN
insert (
	GoodsId,
	Name,
	Value)
values(
	source.GoodsId,
	source.Name,
	source.Value);

if(@result is null) set @result = SCOPE_IDENTITY()

exec SelectPropertyById @result
go

DECLARE @Id int, @productId int
DECLARE my_cur CURSOR FOR 
     SELECT G.Id
     FROM dbo.Goods As G
	 where G.DryerMode = 1

   OPEN my_cur  
   FETCH NEXT FROM my_cur INTO @Id  
   WHILE @@FETCH_STATUS = 0
   BEGIN
    insert into dbo.[Product]
		values
		(  3,
		(select G.Brand from dbo.Goods AS G where G.Id = @Id), 
		(select G.Model from dbo.Goods AS G where G.Id = @Id),
		(select G.CountryId from dbo.Goods AS G where G.Id = @Id),
		(select G.YearOfManufacture from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Weight from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.PowerConsumption from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.ColorId from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Price from dbo.Goods AS G where G.Id = @Id))			
		set @productId = SCOPE_IDENTITY();
	    insert into dbo.PropertiesGoods
		values
		(  @productId,'DryerMode', (select G.DryerMode from dbo.Goods AS G where G.Id = @Id))	,			
		(  @productId,'RemoteStart', (select G.RemoteStart from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'NumberOfOperatingModes', (select G.NumberOfOperatingModes from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'ChamberVolume', (select G.ChamberVolume from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'MaxLoading', (select G.MaxLoading from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'TheVolumeOfTheDrum', (select G.TheVolumeOfTheDrum from dbo.Goods AS G where G.Id = @Id))       
        FETCH NEXT FROM my_cur INTO @Id
   END   
   CLOSE my_cur
   DEALLOCATE my_cur
   GO

DECLARE @Id int, @productId int
DECLARE my_cur CURSOR FOR 
     SELECT G.Id
     FROM dbo.Goods As G
	 where G.VolumeOfTheDustContainer is not null

   OPEN my_cur  
   FETCH NEXT FROM my_cur INTO @Id  
   WHILE @@FETCH_STATUS = 0
   BEGIN
    insert into dbo.[Product]
		values
		(  1,
		(select G.Brand from dbo.Goods AS G where G.Id = @Id), 
		(select G.Model from dbo.Goods AS G where G.Id = @Id),
		(select G.CountryId from dbo.Goods AS G where G.Id = @Id),
		(select G.YearOfManufacture from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Weight from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.PowerConsumption from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.ColorId from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Price from dbo.Goods AS G where G.Id = @Id))			
		set @productId = SCOPE_IDENTITY();
	    insert into dbo.PropertiesGoods
		values
		(  @productId,'VolumeOfTheDustContainer', (select G.VolumeOfTheDustContainer from dbo.Goods AS G where G.Id = @Id))	,				
		(  @productId,'RemoteStart', (select G.RemoteStart from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'NumberOfOperatingModes', (select G.NumberOfOperatingModes from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'VolumeOfTheLiquidTank', (select G.VolumeOfTheLiquidTank from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'AutomaticCleaning', (select G.AutomaticCleaning from dbo.Goods AS G where G.Id = @Id))		       
        FETCH NEXT FROM my_cur INTO @Id
   END   
   CLOSE my_cur
   DEALLOCATE my_cur
   GO

DECLARE @Id int, @productId int
DECLARE my_cur CURSOR FOR 
     SELECT G.Id
     FROM dbo.Goods As G
	 where G.TemperatureMaintenance is not null

   OPEN my_cur  
   FETCH NEXT FROM my_cur INTO @Id  
   WHILE @@FETCH_STATUS = 0
   BEGIN  
    insert into dbo.[Product]
		values
		(  4,
		(select G.Brand from dbo.Goods AS G where G.Id = @Id), 
		(select G.Model from dbo.Goods AS G where G.Id = @Id),
		(select G.CountryId from dbo.Goods AS G where G.Id = @Id),
		(select G.YearOfManufacture from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Weight from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.PowerConsumption from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.ColorId from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Price from dbo.Goods AS G where G.Id = @Id))			
		set @productId = SCOPE_IDENTITY();
	    insert into dbo.PropertiesGoods
		values
		(  @productId,'TemperatureMaintenance', (select G.TemperatureMaintenance from dbo.Goods AS G where G.Id = @Id))	,		
		(  @productId,'RemoteStart', (select G.RemoteStart from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'BodyMaterial', (select G.BodyMaterial from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'InnerCoating', (select G.InnerCoating from dbo.Goods AS G where G.Id = @Id))			       
        FETCH NEXT FROM my_cur INTO @Id
   END   
   CLOSE my_cur
   DEALLOCATE my_cur
   GO

DECLARE @Id int, @productId int
DECLARE my_cur CURSOR FOR 
     SELECT G.Id
     FROM dbo.Goods As G
	 where G.TypeOfHeating is not null

   OPEN my_cur  
   FETCH NEXT FROM my_cur INTO @Id  
   WHILE @@FETCH_STATUS = 0
   BEGIN     
    insert into dbo.[Product]
		values
		(  2,
		(select G.Brand from dbo.Goods AS G where G.Id = @Id), 
		(select G.Model from dbo.Goods AS G where G.Id = @Id),
		(select G.CountryId from dbo.Goods AS G where G.Id = @Id),
		(select G.YearOfManufacture from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Weight from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.PowerConsumption from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.ColorId from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Price from dbo.Goods AS G where G.Id = @Id))			
		set @productId = SCOPE_IDENTITY();
	    insert into dbo.PropertiesGoods
		values
		(  @productId,'TypeOfHeating', (select G.TypeOfHeating from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'NumberOfOperatingModes', (select G.NumberOfOperatingModes from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'RemoteStart', (select G.RemoteStart from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'BodyMaterial', (select G.BodyMaterial from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'ChamberVolume', (select G.ChamberVolume from dbo.Goods AS G where G.Id = @Id))			       
        FETCH NEXT FROM my_cur INTO @Id
   END   
   CLOSE my_cur
   DEALLOCATE my_cur
   GO

DECLARE @Id int, @productId int
DECLARE my_cur CURSOR FOR 
     SELECT G.Id
     FROM dbo.Goods As G
	 where G.BowlVolume is not null

   OPEN my_cur  
   FETCH NEXT FROM my_cur INTO @Id  
   WHILE @@FETCH_STATUS = 0
   BEGIN 
    insert into dbo.[Product]
		values
		(  5,
		(select G.Brand from dbo.Goods AS G where G.Id = @Id), 
		(select G.Model from dbo.Goods AS G where G.Id = @Id),
		(select G.CountryId from dbo.Goods AS G where G.Id = @Id),
		(select G.YearOfManufacture from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Weight from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.PowerConsumption from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.ColorId from dbo.Goods AS G where G.Id = @Id)	,	
		(select G.Price from dbo.Goods AS G where G.Id = @Id))			
		set @productId = SCOPE_IDENTITY();

	    insert into dbo.PropertiesGoods
		values
		(  @productId,'BowlVolume', (select G.TypeOfHeating from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'NumberOfOperatingModes', (select G.NumberOfOperatingModes from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'RemoteStart', (select G.RemoteStart from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'BodyMaterial', (select G.BodyMaterial from dbo.Goods AS G where G.Id = @Id))	,	
		(  @productId,'InnerCoating', (select G.InnerCoating from dbo.Goods AS G where G.Id = @Id))			       
        FETCH NEXT FROM my_cur INTO @Id
   END   
   CLOSE my_cur
   DEALLOCATE my_cur
   GO

CREATE PROCEDURE [dbo].[Merge_Product]
	@Id INT = null,
	@TypeId int = null,
	@Brand nvarchar (30)  = null,	
	@Model nvarchar (100)  = null,	
	@CountryId int =  null,	
	@YearOfManufacture date = null,
	@Weight float = null,
	@PowerConsumption float = null,
	@ColorId nvarchar(30) = null,
	@Price decimal = null
AS
	declare
@result bigint
set @result = @Id
	Merge dbo.[Product] as G
	using (select 
		@TypeId,
		@Brand ,
		@Model,
		@CountryId,	
		@YearOfManufacture,
		@Weight ,
		@PowerConsumption,
		@ColorId,
		@Price )
	As sourse (
		TypeId,
		Brand ,
		Model,
		CountryId,	
		YearOfManufacture,
		[Weight],
		PowerConsumption,
		ColorId,
		Price)
			on	(G.Id = @Id) 
	When MATCHED THEN 
	Update  set		
		TypeId = sourse.TypeId,
		Brand = sourse.Brand ,		
		Model = sourse.Model ,		
		CountryId = sourse.CountryId,	
		YearOfManufacture = sourse.YearOfManufacture,
		[Weight] = sourse.[Weight] ,
		PowerConsumption = sourse.PowerConsumption,
		Price = sourse.Price,
		ColorId = sourse.ColorId		
	WHEN NOT MATCHED THEN	
	insert ( 
		TypeId,
		Brand ,
		Model,
		CountryId,	
		YearOfManufacture,
		[Weight] ,
		PowerConsumption,
		ColorId,
		Price) 
	values (	
		sourse.TypeId,
		sourse.Brand ,			
		sourse.Model ,			
		sourse.CountryId,	
		sourse.YearOfManufacture,
		sourse.[Weight] ,
		sourse.PowerConsumption,
		sourse.ColorId,
		sourse.Price
	);
	If(@result is Null)set @result = SCOPE_IDENTITY()
	exec SearchGoods @result
GO

CREATE PROCEDURE [dbo].[SearchProduct]
	@Id INT = null,
	@TypeId INT = null,
	@PowerConsumptionStart float = null,
	@PowerConsumptionEnd float = null,
	@Brand nvarchar (30) = null,		
	@Model nvarchar (100) = null,		
	@CountryId int =  null,	
	@YearOfManufactureStart date = null,
	@YearOfManufactureEnd date = null,		
	@ColorId nvarchar(30) = null,
	@PriceStart decimal = null,
	@PriceEnd decimal = null
AS
begin
	DECLARE @resultSQL nvarchar (max) = '
	SELECT 		
		P.Id ,			
		P.Brand ,
		P.Model ,		
		P.YearOfManufacture,
		P.[Weight] ,
		P.PowerConsumption,
		P.Price,
		C.Id,C.name,
		Co.Id,Co.Name,
		TG.Id, TG.Name,
		PG.Id, PG.Name, PG.Value
		FROM    [dbo].[Product] as P
	inner JOIN dbo.[Country] as C on P.[CountryId] = C.Id
	join dbo.Color as Co on Co.id = P.ColorId	
	join dbo.TypeGoods as TG on TG.id = P.TypeId	
	left join dbo.PropertiesGoods as PG on PG.goodsId = P.Id	
    WHERE   (1=1)'
	
	if( @Id IS NOT NULL)
		begin 
			set @resultSQL += ' and P.[Id] = ' + CONVERT(nvarchar, @Id)
		end
	if(@TypeId is not null)
		begin
			set @resultSQL += 'and P.[TypeId] = '+ CONVERT(nvarchar, @TypeId)
		end
	if( @Brand IS NOT NULL)
		begin      
			set @resultSQL += ' and P.Brand LIKE ' + '''%' + CONVERT(nvarchar(50), @Brand) + '%'''     
		end 
	if( @Model IS NOT NULL)
		begin      
			set @resultSQL += ' and P.Model LIKE ' + '''%' + CONVERT(nvarchar(50), @Model) + '%'''     
    end    
	if( @YearOfManufactureStart IS NOT NULL)
		begin
			set @resultSQL += ' and (P.YearOfManufacture BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @YearOfManufactureStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @YearOfManufactureEnd) + ''')'
		end 
	if( @PowerConsumptionStart IS NOT NULL)
		begin
			set @resultSQL += ' and (P.PowerConsumption BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @PowerConsumptionStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @PowerConsumptionEnd) + ''')'
		end	
	if( @CountryId IS NOT NULL)
		begin
			set @resultSQL += ' and P.CountryId = ' + CONVERT(nvarchar(50), @CountryId)
		end	
	if( @ColorID IS NOT NULL)
		begin    
			set @resultSQL += ' and P.ColorId LIKE ' + '''%' + CONVERT(nvarchar(50), @ColorId) + '%'''     
		end
	if( @PriceStart IS NOT NULL)
		begin
			set @resultSQL += ' and (P.Price BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @PriceStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @PriceEnd) + ''')'
		end
		set @resultSQL += ' OPTION (RECOMPILE)'
		Print @resultSQL
		exec sp_executesql @resultSQL			
end
GO

ALTER PROCEDURE [dbo].[AddOrUpdate]
	@ProductId int ,
	@StorageId int,
	@Quantity int,
	@Sale bit = null
AS
if exists(  select * from dbo.Storage_Product as SP where SP.ProductId = @ProductId and SP.StorageId = @StorageId)
 begin
	if(@Sale is null)
	begin
	 update dbo.Storage_Product
	  set 
	   QuantityProduct += @Quantity
	   where ProductId = @ProductId and StorageId = @StorageId
	end
	else
	begin
	  update dbo.Storage_Product
	   set 
	    QuantityProduct -= @Quantity
		where ProductId = @ProductId and StorageId = @StorageId
	end
 end
else
 begin
	insert into dbo.Storage_Product
	values(@ProductId,@StorageId,@Quantity)
 end

SELECT 
P.Id , P.Brand,P.Model, P.Price, 
CY.Id, CY.Name as City, 
S.Id, S.Name as StorageName, S.Address,s.Phone,S.Email,
SP.Id, SP.QuantityProduct
from dbo.Storage_Product as SP
	join dbo.Product as P on P.Id = SP.GoodsId	
	join dbo.Storage as S on s.Id = SP.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	where SP.StorageId = @StorageId and  SP.ProductId = @ProductId
go

ALTER PROCEDURE [dbo].[MergeOrder_Goods]
	@orderId int = null ,
	@productId int = null,
	@quantityGoods int = null
AS
Merge dbo.[Order_Product] AS OP
using (select	
	@orderId,
	@productId,
	@quantityGoods)
As sourse (	
	orderId,
	productId,
	quantityProduct)
on(OP.orderId = sourse.orderId and OP.ProductId = @productId)
WHEN MATCHED THEN
update set	
	productId = sourse.productId,
	quantityProduct = sourse.quantityProduct
WHEN NOT MATCHED THEN
insert (
	orderId,
	productId,
	quantityGoods)
values (
	@orderId,
	@productId,
	@quantityGoods);
select
	O.Id,
    P.Id, P.Brand, P.Model, P.Price ,
	OP.Id , OP.quantityGoods
from dbo.[Order_Product] as OP
join dbo.[Order] as O on O.Id = OP.orderId
join dbo.Product as P on P.Id = OP.goodsId
where OP.orderId = @orderId and OP.goodsId = @goodsId

go

ALTER PROCEDURE [dbo].[SelectAllQuantityProduct]
AS
select
sp.Id, sp.QuantityProduct, 
P.Id , P.Brand,P.Model, P.Price, 
S.Id, S.Name, S.Address,s.Phone,S.Email,
CY.Id, CY.Name,
C.Id,C.Name
from dbo.Storage_Product as SP
	join dbo.Product as P on P.Id =SP.GoodsId	
	join dbo.Storage as S on s.Id = SP.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	left join dbo.Country as C on C.Id = s.CountryId


Go

ALTER PROCEDURE [dbo].[SelectOrderById]
@orderId int 	
AS
select 
	OP.Id , OP.quantityGoods,	
	o.id, O.TotalCost, O.DateOrder,
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    U. Id, U.Name, U.LastName, U.Address, U.Phone  ,  
    P.Id, P.Brand, P.Model,P.PowerConsumption,P.Weight,P.YearOfManufacture, P.Price 
 from dbo.[Order] as O
    left join dbo.Order_Product as OP on OP.orderId = O.Id
	left join dbo.Product as P on P.Id = OP.goodsId
	join dbo.[User] as U on U.Id = O.UserId
	join dbo.Storage as S on S.Id = O.StorageId
	join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.Id = @orderId
Go

ALTER PROCEDURE [dbo].[SelectOrderByStorageId]
 @StorageId int 
AS
select 
	OP.Id , OP.quantityGoods,	
	o.id, O.TotalCost, O.DateOrder,
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    U. Id, U.Name, U.LastName, U.Address, U.Phone  ,  
    P.Id, P.Brand, P.Model,P.PowerConsumption,P.Weight,P.YearOfManufacture, P.Price 
 from dbo.[Order] as O
    left join dbo.Order_Product as OP on OP.orderId = O.Id
	left join dbo.Product as P on P.Id = OP.goodsId
	join dbo.[User] as U on U.Id = O.UserId
	join dbo.Storage as S on S.Id = O.StorageId
	join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.StorageId = @StorageId
go

ALTER PROCEDURE [dbo].[SelectOrderByUserId]
 @UserId int	
AS
select 
	OP.Id , OP.quantityGoods,	
	o.id, O.TotalCost, O.DateOrder,
    S.Id, S.Name, S.CityId, S.Address, S.Phone,
    PT.Id,  PT.Name,
    SO.Id,  SO.Name, 
    U. Id, U.Name, U.LastName, U.Address, U.Phone  ,  
    P.Id, P.Brand, P.Model,P.PowerConsumption,P.Weight,P.YearOfManufacture, P.Price 
 from dbo.[Order] as O
    left join dbo.Order_Product as OP on OP.orderId = O.Id
	left join dbo.Product as P on P.Id = OP.goodsId
	join dbo.[User] as U on U.Id = O.UserId
	join dbo.Storage as S on S.Id = O.StorageId
	join dbo.PaymentType as PT on PT.Id = O.PaymentTypeId
	join dbo.StatusOrder as SO on So.Id = O.StatusOrderId
where O.UserId = @UserId
go

ALTER PROCEDURE [dbo].[SelectQuantityProductByStorageId]
	@id int	
AS
SELECT 
sp.Id, sp.QuantityGoods, 
P.Id , P.Brand,P.Model, P.Price, 
S.Id, S.Name, S.Address,s.Phone,S.Email,
CY.Id, CY.Name,
C.Id,C.Name
from dbo.Storage_Product as SP
	join dbo.Product as P on P.Id = SP.GoodsId	
	join dbo.Storage as S on s.Id = SP.StorageId	
	left join dbo.City as CY on CY.Id = s.CityId
	left join dbo.Country as C on C.Id = s.CountryId
where sp.StorageId = @id
go

ALTER PROCEDURE [dbo].[TransferProduct]
		@sender int,
	@ProductId int,
	@recipiend int,
	@quantityProduct int
AS
declare
@sendlerId int,
@recipiendId int
if exists(  select * from dbo.Storage_Product as SP where SP.ProductId = @ProductId and SP.StorageId = @sender and (SP.QuantityProduct - @quantityProduct) > 0)
begin
	Update dbo.Storage_Product
	set
		QuantityProduct -= @quantityProduct,
		@sendlerId = Id
	where ProductId = @ProductId and StorageId = @sender
end
else  THROW 60000, 'The product is not available in this store', 1;  

if exists(  select * from dbo.Goods_Storage as GS where GS.ProductId = @ProductId and SP.StorageId = @recipiend )
begin
	Update dbo.Storage_Product 
	set
		QuantityProduct += @quantityProduct,
		@recipiendId = id
	where ProductId = @ProductId and StorageId = @recipiend
end
else
 begin
	insert into dbo.Storage_Product
	values(@ProductId,@recipiend,@quantityProduct)
 set @recipiendId = SCOPE_IDENTITY()
end


SELECT 
SP.Id, SP.QuantityGoods,SP.GoodsId, SP.StorageId AS SenderId, @recipiend AS RecipiendId
from dbo.Storage_Product as SP	
	where SP.StorageId = @sender and  SP.GoodsId = @ProductId;

SELECT 
SP.Id, SP.QuantityGoods,SP.GoodsId, SP.StorageId AS RecipiendId, @sender AS SenderId
from dbo.Storage_Product as SP	
	where SP.StorageId = @recipiend and  SP.GoodsId = @ProductId;
Go

DROP TABLE dbo.Goods
Go
DROP PROCEDURE dbo.MergeGoods 
go
DROP PROCEDURE dbo.SearchGoods 
go

--insert into dbo.DbVersion values(sysutcdatetime(),2.0)

--set noexec off
