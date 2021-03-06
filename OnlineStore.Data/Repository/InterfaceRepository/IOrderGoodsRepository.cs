﻿using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IOrderGoodsRepository
    {
        DataWrapper<List<OrderGoodsDto>> MergeOrderGoods(List<OrderGoodsDto> dto);
        DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByCustomerId(int id);
        DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByOrderId(int id);
        DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByStorageId(int id);
    }
}