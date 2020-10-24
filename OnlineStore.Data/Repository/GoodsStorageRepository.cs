using OnlineStore.Data.Dto;
using System;
using System.Data;
using Dapper;
using System.Linq;

namespace OnlineStore.Data.Repository
{
    public class GoodsStorageRepository :BaseRepository
    {
        public DataWrapper<GoodsStorageDto> AddOrUpdate(GoodsStorageDto dto)
        {
            var data = new DataWrapper<GoodsStorageDto>();
            try
            {
                data.Data = DbConnection.Query<GoodsStorageDto>(
                  StorageProcedure.AddOrUpdate,                  
                   new
                   {                       
                       dto.QuantityGoods,
                       dto.StorageId,
                       dto.GoodsId,
                       dto.Sale
                   },                    
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<GoodsStorageTransferDto> TransferGoods(GoodsStorageTransferDto dto)
        {
            var data = new DataWrapper<GoodsStorageTransferDto>();
            try
            {
                data.Data = DbConnection.Query<GoodsStorageTransferDto>(
                  StorageProcedure.Transfer,
                   new
                   {
                       dto.QuantityGoods,
                       sender = dto.StorageId,
                       dto.GoodsId,
                       dto.RecipiendId
                   },
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
    }
}
