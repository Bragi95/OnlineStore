using OnlineStore.Data.Dto;

namespace Shop.Data.Repository
{
    public interface IStorageRepository
    {
        OrderDto SelectOrderById(int id);
        StorageDto SelectStorageByCityId(int id);
        StorageDto SelectStorageByCountryId(int id);
        StorageDto SelectStorageById(int id);
        StorageDto StorageMerge(StorageDto dto);
    }
}