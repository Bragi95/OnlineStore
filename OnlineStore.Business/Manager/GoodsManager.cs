using AutoMapper;
using OnlineStore.Business.Configurations;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Manager
{
    public class GoodsManager : IGoodsManager
    {
        IGoodsRepositoty _goodsRepository;
        IMapper _mapper;     
 
        public GoodsManager(IGoodsRepositoty goodsRepository, IMapper mapper)
        {
            _goodsRepository = goodsRepository;
            _mapper = mapper;           
        } 
        
        public DataWrapper<T> MergeGoods<T>(GoodsInputModel model)
        {
            var dto = _mapper.Map<GoodsDto>(model);
            var result = _goodsRepository.MergeGoods(dto);
            var mapping = _mapper.Map<T>(result.Data); //не передает возращаемое значение
            return new DataWrapper<T>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<GoodsOutputModel>> SearchGoods(SearchInputModel model)
        {
            var dto = _mapper.Map<SearchDto>(model);
            var result = _goodsRepository.SearchGoods(dto);

            var mapping = MappingGoods(result.Data);

            return new DataWrapper<List<GoodsOutputModel>>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        private List<GoodsOutputModel> MappingGoods(List<GoodsDto> dtos)
        {
            var mapping = new List<GoodsOutputModel>();
            foreach (var item in dtos)
            {
                if (item.DryerMode != null)
                {
                    mapping.Add(_mapper.Map<WasherOutputModel>(item));
                }
                else if (item.TypeOfHeating != null)
                {
                    mapping.Add(_mapper.Map<MicrowaveOutputModel>(item));
                }
                else if (item.VolumeOfTheDustContainer != null)
                {
                    mapping.Add(_mapper.Map<VacuumCleanerOutputModel>(item));
                }
                else if (item.TemperatureMaintenance != null)
                {
                    mapping.Add(_mapper.Map<ElectricKettleOutputModel>(item));
                }
                else if (item.BowlVolume != null)
                {
                    mapping.Add(_mapper.Map<MulticookersOutputModel>(item));
                }
                else
                {
                    mapping.Add(_mapper.Map<GoodsOutputModel>(item));
                }
            }
            return mapping;
        }
    }
}
