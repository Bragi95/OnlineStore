using Dapper;
using OnlineStore.Data.Dto;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public class OrderGoodsRepository : BaseRepository, IOrderGoodsRepository
    {
        public DataWrapper<List<OrderGoodsDto>> MergeOrderGoods(List<OrderGoodsDto> dto)
        {

            var data = new DataWrapper<List<OrderGoodsDto>>();
            data.Data = new List<OrderGoodsDto>();
            try
            {
                foreach (var item in dto)
                {
                    data.Data.Add(DbConnection.Query< OrderDto, GoodsDto, OrderGoodsDto, OrderGoodsDto>(
                     StorageProcedure.MergeOrderGoods,
                     (  order, goods, orderGoods) =>
                     {
                         orderGoods.OrderId = order.Id;
                         if (goods.Brand != null) orderGoods.Goods = goods;
                         
                         return orderGoods;
                     },
                     new
                     {
                         goodsId = item.Goods.Id,
                         orderId = item.OrderId,
                         item.QuantityGoods
                     },
                     splitOn: "Id",
                        commandType: CommandType.StoredProcedure
                       ).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }     
    }
}
