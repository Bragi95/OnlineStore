using AutoMapper;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Manager
{
    public class StorageManager : IStorageManager
    {
        IMapper _mapper;
        IStorageRepository _storageRepository;
        IGoodsStorageRepository _goodsStorageRepository;

        public StorageManager(IMapper mapper, IStorageRepository storageRepository, IGoodsStorageRepository goodsStorageRepository)
        {
            _mapper = mapper;
            _storageRepository = storageRepository;
            _goodsStorageRepository = goodsStorageRepository;
        }

        public DataWrapper<StorageOutputModel> GetStorageById(int id)
        {
            var result = _storageRepository.SelectStorageById(id);
            var mappingResult = _mapper.Map<StorageOutputModel>(result.Data);

            return new DataWrapper<StorageOutputModel>
            {
                Data = mappingResult,
                ExceptionMessage = result.ExceptionMessage            
            };
        }

        public DataWrapper<List<StorageOutputModel>> GetStorageByCountryId(int id)
        {
            var result = _storageRepository.SelectStorageByCountryId(id);
            var mappingResult = _mapper.Map<List<StorageOutputModel>>(result.Data);

            return new DataWrapper<List<StorageOutputModel>>
            {
                Data = mappingResult,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<StorageOutputModel>> GetStorageByCityId(int id)
        {
            var result = _storageRepository.SelectStorageByCityId(id);
            var mappingResult = _mapper.Map<List<StorageOutputModel>>(result.Data);

            return new DataWrapper<List<StorageOutputModel>>
            {
                Data = mappingResult,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<StorageOutputModel> MergeStorage(StorageInputModel model)
        {
            var dto = _mapper.Map<StorageDto>(model);
            var result = _storageRepository.StorageMerge(dto);
            var mappingResult = _mapper.Map<StorageOutputModel>(result.Data);

            return new DataWrapper<StorageOutputModel>
            {
                Data = mappingResult,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<TransferGoodsOutputModel>> TransferGoodsBetweenStorages(GoodsStorageTransferInputModel model)
        {
            var dto = _mapper.Map<TransferGoodsDto>(model);
            var result = _goodsStorageRepository.TransferGoods(dto);
            var mapping = _mapper.Map<List<TransferGoodsOutputModel>>(result.Data);
            return new DataWrapper<List<TransferGoodsOutputModel>>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<GoodsStorageOutputModel>> SelectQuantityGoodsByStorageid(int id)
        {            
            var result = _goodsStorageRepository.SelectQuantityGoodsByStorageId(id);
            var mapping = _mapper.Map<List<GoodsStorageOutputModel>>(result.Data);
            return new DataWrapper<List<GoodsStorageOutputModel>>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<GoodsStorageOutputModel>> SelectAllQuantityGoods()
        {
            var result = _goodsStorageRepository.SelectAllQuantityGoodsStorage();
            var mapping = _mapper.Map<List<GoodsStorageOutputModel>>(result.Data);
            return new DataWrapper<List<GoodsStorageOutputModel>>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }
    }
}
