using OnlineStore.Data;
using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace Shop.Data.Repository
{
    public interface IStorageRepository
    {
        DataWrapper<List<StorageDto>> SelectStorageByCityId(int id);
        DataWrapper<List<StorageDto>> SelectStorageByCountryId(int id);
        DataWrapper<StorageDto> SelectStorageById(int id);
        DataWrapper<StorageDto> StorageMerge(StorageDto dto);
    }
}