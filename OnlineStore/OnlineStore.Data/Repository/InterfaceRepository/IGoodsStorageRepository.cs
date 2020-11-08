using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IGoodsStorageRepository
    {
        DataWrapper<GoodsStorageDto> AddOrUpdate(GoodsStorageDto dto);
        DataWrapper<List<GoodsStorageDto>> SelectAllQuantityGoodsStorage();
        DataWrapper<List<GoodsStorageDto>> SelectQuantityGoodsByStorageId(int id);       
        DataWrapper<List<TransferGoodsDto>> TransferGoods(TransferGoodsDto dto);
    }
}