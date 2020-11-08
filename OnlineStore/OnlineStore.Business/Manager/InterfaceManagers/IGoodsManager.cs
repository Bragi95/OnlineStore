using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public interface IGoodsManager
    {
        DataWrapper<T> MergeGoods<T>(GoodsInputModel model);
        DataWrapper<List<GoodsOutputModel>> SearchGoods(SearchInputModel model);
    }
}