using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IGoodsRepositoty
    {
        DataWrapper<GoodsDto> MergeGoods(GoodsDto dto);
        DataWrapper<List<GoodsDto>> SearchGoods(SearchDto dto);
    }
}