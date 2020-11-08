using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public interface IStorageManager
    {
        DataWrapper<StorageOutputModel> GetStorageById(int id);
        DataWrapper<List<StorageOutputModel>> GetStorageByCityId(int id);
        DataWrapper<List<StorageOutputModel>> GetStorageByCountryId(int id);
        DataWrapper<StorageOutputModel> MergeStorage(StorageInputModel model);
        DataWrapper<List<TransferGoodsOutputModel>> TransferGoodsBetweenStorages(GoodsStorageTransferInputModel model);
        DataWrapper<List<GoodsStorageOutputModel>> SelectQuantityGoodsByStorageid(int id);
        DataWrapper<List<GoodsStorageOutputModel>> SelectAllQuantityGoods();
    }
}