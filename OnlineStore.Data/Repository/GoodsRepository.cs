using Dapper;
using OnlineStore.Data.Dto;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public class GoodsRepository : BaseRepository, IGoodsRepositoty
    {
        public DataWrapper<GoodsDto> MergeGoods(GoodsDto dto)
        {
            var data = new DataWrapper<GoodsDto>();
            try
            {
                data.Data = DbConnection.Query<GoodsDto, CountryDto, ColorDto, GoodsDto>(
                  StorageProcedure.MergeGoods,
                   (goods, country, color) =>
                   {
                       goods.Country = country;
                       goods.Color = color;
                       return goods;
                   },
                   new
                   {
                       dto.Id,
                       dto.Brand,
                       dto.Model,
                       CountryId = dto.Country.id,
                       dto.YearOfManufacture,
                       dto.Weight,
                       dto.PowerConsumption,
                       dto.RemoteStart,
                       dto.NumberOfOperatingModes,
                       dto.VolumeOfTheDustContainer,
                       dto.VolumeOfTheLiquidTank,
                       dto.AutomaticCleaning,
                       dto.BodyMaterial,
                       dto.TemperatureMaintenance,
                       dto.ChamberVolume,
                       dto.InnerCoating,
                       dto.BowlVolume,
                       dto.TypeOfHeating,
                       dto.MaxLoading,
                       dto.TheVolumeOfTheDrum,
                       dto.DryerMode,
                       ColorId = dto.Color.Id,
                       dto.Price
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<GoodsDto>> SearchGoods(SearchDto dto)
        {
            var data = new DataWrapper<List<GoodsDto>>();
            try
            {
                data.Data = DbConnection.Query<GoodsDto, CountryDto, ColorDto, GoodsDto>(
                  StorageProcedure.SearchGoods,
                   (goods, country, color) =>
                   {
                       goods.Country = country;
                       goods.Color = color;
                       return goods;
                   },
                   new
                   {
                       dto.Id,                      
                       dto.Brand,
                       dto.Model,
                       dto.CountryId,
                       dto.YearOfManufactureStart,
                       dto.YearOfManufactureEnd,
                       dto.PowerConsumptionStart,
                       dto.PowerConsumptionEnd,
                       dto.RemoteStart,
                       dto.NumberOfOperatingModes,
                       dto.VolumeOfTheDustContainer,
                       dto.VolumeOfTheLiquidTank,
                       dto.AutomaticCleaning,
                       dto.BodyMaterial,
                       dto.TemperatureMaintenance,
                       dto.ChamberVolume,
                       dto.InnerCoating,
                       dto.BowlVolume,
                       dto.TypeOfHeating,
                       dto.MaxLoading,
                       dto.TheVolumeOfTheDrum,
                       dto.DryerMode,
                       dto.ColorId,
                       dto.PriceStart,
                       dto.PriceEnd
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).ToList();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
    }
}
