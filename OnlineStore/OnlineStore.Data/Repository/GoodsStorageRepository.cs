using OnlineStore.Data.Dto;
using System;
using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public class GoodsStorageRepository : BaseRepository, IGoodsStorageRepository
    {
        public DataWrapper<GoodsStorageDto> AddOrUpdate(GoodsStorageDto dto)
        {
            var data = new DataWrapper<GoodsStorageDto>();
            try
            {
                data.Data = DbConnection.Query<GoodsStorageTransferDto, GoodsDto, StorageDto, CityDto, GoodsStorageTransferDto>(
                  StorageProcedure.AddOrUpdate,
                  (goodsStorage, goods, sender, city) =>
                  {
                      sender.City = city;
                      goodsStorage.Storage = sender;
                      goodsStorage.Goods = goods;
                      return goodsStorage;

                  },
                   new
                   {
                       Quantity = dto.QuantityGoods,
                       StorageId = dto.Storage.Id,
                       GoodsId = dto.Goods.Id,
                       dto.Sale
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

        public DataWrapper<List<TransferGoodsDto>> TransferGoods(TransferGoodsDto dto)
        {
            var data = new DataWrapper<List<TransferGoodsDto>>();
            data.Data = new List<TransferGoodsDto>();
            try
            {
                var t = DbConnection.QueryMultiple(
                    StorageProcedure.Transfer,
                    new
                    {
                        sender = dto.SenderId,
                        goodsid = dto.GoodsId,
                        recipiend = dto.RecipiendId,
                        dto.QuantityGoods
                    },
                    commandType: CommandType.StoredProcedure);

                data.Data.Add(t.Read<TransferGoodsDto>().First());
                data.Data.Add(t.Read<TransferGoodsDto>().Last());               
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<GoodsStorageDto>> SelectQuantityGoodsByStorageId(int id)
        {
            var data = new DataWrapper<List<GoodsStorageDto>>();
            try
            {
                data.Data = DbConnection.Query<GoodsStorageDto, GoodsDto, StorageDto, CityDto,CountryDto, GoodsStorageDto>(
                  StorageProcedure.SelectQuantityGooldsByStorageId,
                  (goodsStorage, goods, storage, city, country) =>
                  {
                      storage.City = city;
                      storage.Country = country;                      
                      goodsStorage.Storage = storage;
                      goodsStorage.Goods = goods;

                      return goodsStorage;
                  },
                   new
                   {
                       id
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

        public DataWrapper<List<GoodsStorageDto>> SelectAllQuantityGoodsStorage()
        {
            var data = new DataWrapper<List<GoodsStorageDto>>();
            try
            {
                data.Data = DbConnection.Query<GoodsStorageDto, GoodsDto, StorageDto, CityDto, CountryDto, GoodsStorageDto>(
                 StorageProcedure.SelectAllQuantityGoods,
                 (goodsStorage, goods, storage, city, country) =>
                 {
                     storage.City = city;
                     storage.Country = country;
                     goodsStorage.Storage = storage;
                     goodsStorage.Goods = goods;

                     return goodsStorage;
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
