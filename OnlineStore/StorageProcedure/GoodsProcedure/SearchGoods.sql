CREATE PROCEDURE [dbo].[SearchGoods]
	@Id INT = null,
	@BrandId nvarchar (30) = null,		
	@CountryId int =  null,	
	@YearOfManufactureStart date = null,
	@YearOfManufactureEnd date = null,	
	@PowerConsumptionStart float = null,
	@PowerConsumptionEnd float = null,
	@RemoteStart bit = null,
	@NumberOfOperatingModes  int = null,
	@VolumeOfTheDustContainer float = null,
	@VolumeOfTheLiquidTank float = null,
	@AutomaticCleaning bit = null,
	@BodyMaterial nvarchar (30) = null,
	@TemperatureMaintenance bit = null,
	@ChamberVolume float = null,
	@InnerCoating nvarchar(30) = null,
	@BowlVolume float = null,
	@TypeOfHeating nvarchar(30) = null,
	@MaxLoading float = null,
	@TheVolumeOfTheDrum float= null,
	@DryerMode bit = null,
	@ColorId nvarchar(30) = null,
	@PriceStart decimal = null,
	@PriceEnd decimal = null
AS
begin
	DECLARE @resultSQL nvarchar (max) = '
	SELECT 
		Co.Id,
		Co.Name as Color,
		C.Id,
		C.name as Manufacture,
		B.Id ,	
		B.Brand ,
		B.Model ,
		G.Id,
		G.YearOfManufacture,
		G.[Weight] ,
		G.PowerConsumption,
		G.RemoteStart ,
		G.NumberOfOperatingModes  ,
		G.VolumeOfTheDustContainer ,
		G.VolumeOfTheLiquidTank ,
		G.AutomaticCleaning,
		G.BodyMaterial ,
		G.TemperatureMaintenance ,
		G.ChamberVolume,
		G.InnerCoating ,
		G.BowlVolume ,
		G.TypeOfHeating ,
		G.MaxLoading ,
		G.TheVolumeOfTheDrum ,
		G.DryerMode ,
		G.Price
    FROM    [dbo].[Goods] as G
	inner JOIN dbo.[Country] as C on G.[CountryId] = C.Id
	join dbo.Color as Co on Co.id = G.ColorId
	join dbo.Brand as B on B.id = G.BrandId
    WHERE   (1=1)'
	
	if( @Id IS NOT NULL)
		begin 
			set @resultSQL += ' and G.[Id] = ' + CONVERT(nvarchar, @Id)
		end
	if( @BrandId IS NOT NULL)
		begin      
      set @resultSQL += ' and G.BrandId LIKE ' + '''%' + CONVERT(nvarchar(50), @BrandId) + '%'''     
    end 
  if( @BodyMaterial IS NOT NULL)
    begin    
      set @resultSQL += ' and G.BodyMaterial LIKE ' + '''%' + CONVERT(nvarchar(50), @BodyMaterial) + '%'''     
    end
	if( @YearOfManufactureStart IS NOT NULL)
		begin
			set @resultSQL += ' and (G.YearOfManufacture BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @YearOfManufactureStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @YearOfManufactureEnd) + ''')'
		end
  if( @InnerCoating IS NOT NULL)
    begin     
      set @resultSQL += ' and G.InnerCoating LIKE ' + '''%' + CONVERT(nvarchar(50), @InnerCoating) + '%'''      
    end
  if( @TypeOfHeating IS NOT NULL)
    begin     
       set @resultSQL += ' and G.TypeOfHeating LIKE ' + '''%' + CONVERT(nvarchar(50), @TypeOfHeating) + '%'''      
    end
	if( @CountryId IS NOT NULL)
		begin
			set @resultSQL += ' and G.CountryId = ' + CONVERT(nvarchar(50), @CountryId)
		end
	if( @RemoteStart IS NOT NULL)
		begin
			set @resultSQL += ' and G.RemoteStart = ' + CONVERT(nvarchar, @RemoteStart)
		end
	if( @NumberOfOperatingModes IS NOT NULL)
		begin
			set @resultSQL += ' and G.NumberOfOperatingModes = ' + CONVERT(nvarchar, @NumberOfOperatingModes)
		end
	if( @PowerConsumptionStart IS NOT NULL)
		begin
			set @resultSQL += ' and (G.PowerConsumption BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @PowerConsumptionStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @PowerConsumptionEnd) + ''')'
		end
	if( @VolumeOfTheDustContainer IS NOT NULL)
		begin
			set @resultSQL += ' and G.VolumeOfTheDustContainer = ' + CONVERT(nvarchar, @VolumeOfTheDustContainer)
		end
	if( @VolumeOfTheLiquidTank IS NOT NULL)
		begin
			set @resultSQL += ' and G.VolumeOfTheLiquidTank = ' + CONVERT(nvarchar, @VolumeOfTheLiquidTank)
		end
	if( @AutomaticCleaning IS NOT NULL)
		begin
			set @resultSQL += ' and G.AutomaticCleaning = ' + CONVERT(nvarchar, @AutomaticCleaning)
		end
	if( @TemperatureMaintenance IS NOT NULL)
		begin
			set @resultSQL += ' and G.TemperatureMaintenance = ' + CONVERT(nvarchar, @TemperatureMaintenance)
		end
	if( @ChamberVolume IS NOT NULL)
		begin
			set @resultSQL += ' and G.ChamberVolume = ' + CONVERT(nvarchar, @ChamberVolume)
		end
	if( @BowlVolume IS NOT NULL)
		begin
			set @resultSQL += ' and G.BowlVolume = ' + CONVERT(nvarchar, @BowlVolume)
		end
	if( @TheVolumeOfTheDrum IS NOT NULL)
		begin
			set @resultSQL += ' and G.TheVolumeOfTheDrum = ' + CONVERT(nvarchar, @TheVolumeOfTheDrum)
		end
	if( @MaxLoading IS NOT NULL)
		begin
			set @resultSQL += ' and G.MaxLoading = ' + CONVERT(nvarchar, @MaxLoading)
		end
	if( @DryerMode IS NOT NULL)
		begin
			set @resultSQL += ' and G.DryerMode = ' + CONVERT(nvarchar, @DryerMode)
		end	
		if( @ColorID IS NOT NULL)
    begin    
      set @resultSQL += ' and G.ColorId LIKE ' + '''%' + CONVERT(nvarchar(50), @ColorId) + '%'''     
    end
	if( @PriceStart IS NOT NULL)
		begin
			set @resultSQL += ' and (G.Price BETWEEN '+ '''' 
			+ CONVERT(nvarchar, @PriceStart) + ''' AND ' + '''' 
			+ CONVERT(nvarchar, @PriceEnd) + ''')'
		end
		set @resultSQL += ' OPTION (RECOMPILE)'
		Print @resultSQL
		exec sp_executesql @resultSQL			
end
