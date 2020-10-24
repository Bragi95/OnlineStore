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
            try
            {
                foreach (var item in dto)
                {
                    data.Data.Add(DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, CustomerDto, GoodsDto, OrderGoodsDto>(
                     StorageProcedure.MergeCustomer,
                     (orderGoods, order, storage, payment, status, customer, goods) =>
                     {
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         order.Customer = customer;

                         if (goods.Weight != null) orderGoods.Goods = goods;
                         orderGoods.Order = order;
                         return orderGoods;
                     }, 
                     new
                       {
                           goodsId = item.Goods.Id,
                           orderId = item.Order.Id,
                           item.QuantityGoods
                       },
                        commandType: CommandType.StoredProcedure
                       ).SingleOrDefault());                   
                }
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
        public DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByOrderId(int id)
        {

            var data = new DataWrapper<List<OrderGoodsDto>>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, CustomerDto, GoodsDto, OrderGoodsDto>(
                     StorageProcedure.MergeCustomer,
                     (orderGoods, order, storage, payment, status, customer, goods) =>
                     {
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         order.Customer = customer;

                         if (goods.Weight != null) orderGoods.Goods = goods;
                         orderGoods.Order = order;
                         return orderGoods;
                     },
                     new
                    {
                      id
                    },
                    commandType: CommandType.StoredProcedure
                    ).ToList();

            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByCustomerId(int id)
        {

            var data = new DataWrapper<List<OrderGoodsDto>>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, CustomerDto, GoodsDto, OrderGoodsDto>(
                     StorageProcedure.MergeCustomer,
                     (orderGoods, order, storage, payment, status, customer, goods) =>
                     {
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         order.Customer = customer;

                         if (goods.Weight != null) orderGoods.Goods = goods;
                         orderGoods.Order = order;
                         return orderGoods;
                     },
                  new
                  {
                      id
                  },
                    commandType: CommandType.StoredProcedure
                   ).ToList();

            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
        public DataWrapper<List<OrderGoodsDto>> SelectOrderGoodsByStorageId(int id)
        {

            var data = new DataWrapper<List<OrderGoodsDto>>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, CustomerDto, GoodsDto, OrderGoodsDto>(
                     StorageProcedure.MergeCustomer,
                     (orderGoods, order, storage, payment, status, customer, goods) =>
                     {
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         order.Customer = customer;

                         if (goods.Weight != null) orderGoods.Goods = goods;
                         orderGoods.Order = order;
                         return orderGoods;
                     },
                  new
                  {
                      id
                  },
                    commandType: CommandType.StoredProcedure
                   ).ToList();

            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
    }
}
