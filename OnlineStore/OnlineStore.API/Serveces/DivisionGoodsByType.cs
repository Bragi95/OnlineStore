using OnlineStore.API.Configuration;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.API.Serveces
{
    public class DivisionGoodsByType
    {
        IGoodsManager _goods;
        public DivisionGoodsByType(IGoodsManager goods)
        {
            _goods = goods;
        }
        public IDataWrapper<GoodsOutputModel> Merge(GoodsInputModel model)
        {
            switch (model.TypeId)
            {
                case (int?)TypeGoods.VacuumCleaner:
                    {
                        var result = _goods.MergeGoods<VacuumCleanerOutputModel>(model);
                        return result;                       
                    }
                case (int?)TypeGoods.Microwave:
                    {
                        var result = _goods.MergeGoods<MicrowaveOutputModel>(model);
                        return result;                        
                    }
                case (int?)TypeGoods.Washer:
                    {
                        var result = _goods.MergeGoods<WasherOutputModel>(model);
                        return result;                        
                    }
                case (int?)TypeGoods.ElectricKettle:
                    {
                        var result = _goods.MergeGoods<ElectricKettleOutputModel>(model);
                        return result;
                    }
                case (int?)TypeGoods.Multicookers:
                    {
                        var result = _goods.MergeGoods<MulticookersOutputModel>(model);
                        return result;
                    }
                default:
                    var defaultResult = _goods.MergeGoods<GoodsOutputModel>(model);
                    return defaultResult;
            }           
        }

        public IDataWrapper<List<GoodsOutputModel>> Search(SearchInputModel model)
        {
            switch (model.TypeId)
            {
                case (int)TypeGoods.VacuumCleaner:
                    {
                        model.VolumeOfTheDustContainer = 0;
                        var result = _goods.SearchGoods(model);
                        return result;
                    }
                case (int)TypeGoods.Microwave:
                    {
                        model.TypeOfHeating = "0";
                        var result = _goods.SearchGoods(model);
                        return result;
                    }
                case (int)TypeGoods.Washer:
                    {
                        model.DryerMode = true;
                        var result = _goods.SearchGoods(model);
                        return result;
                    }
                case (int)TypeGoods.ElectricKettle:
                    {
                        model.TemperatureMaintenance = true;
                        var result = _goods.SearchGoods(model);
                        return result;
                    }
                case (int)TypeGoods.Multicookers:
                    {
                        model.BowlVolume = 0;
                        var result = _goods.SearchGoods(model);
                        return result;
                    }
                default:
                    var defaultResult = _goods.SearchGoods(model);
                    return defaultResult;
            }
        }
    }
}
