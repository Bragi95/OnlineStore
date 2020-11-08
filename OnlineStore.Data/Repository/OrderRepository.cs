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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public DataWrapper<OrderDto> MergeOrder(OrderDto dto)
        {

            var data = new DataWrapper<OrderDto>();
            try
            {
                data.Data = DbConnection.Query<OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, UserDto, OrderDto>(
                  StorageProcedure.MergeOrder,
                  (order, storage, payment, status, user) =>
                  {
                      order.PaymentType = payment;
                      order.StatusOrder = status;
                      order.Storage = storage;
                      order.User = user;
                      return order;
                  },
                   new
                   {
                       dto.Id,
                       PaymentTypeId = dto.PaymentType.id,
                       StatusOrderId = dto.StatusOrder.id,
                       StorageID = dto.Storage.Id,
                       UserId = dto.User.Id,
                       dto.TotalCost
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).FirstOrDefault();

            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<OrderDto> SelectOrderById(int orderId)
        {
            var data = new DataWrapper<OrderDto>();
            var list = new List<OrderGoodsDto>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, UserDto, GoodsDto, OrderDto>(
                     StorageProcedure.SelectOrderById,
                     (orderGoods, order, storage, payment, status, user, goods) =>
                     {

                         order.User = user;
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         orderGoods.Goods = goods;
                         list.Add(orderGoods);
                         return order;
                     },
                     new
                     {
                         orderId
                     },
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                data.Data.OrderGoods = list;
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<OrderDto>> SelectOrderByUserId(int UserId)
        {
            var data = new DataWrapper<List<OrderDto>>();            
            var tmpList = new Dictionary<int, OrderDto>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, UserDto, GoodsDto, OrderDto>(
                     StorageProcedure.SelectOrderByUserId,
                     (orderGoods, order, storage, payment, status, user, goods) =>
                     {
                         OrderDto dto;
                         order.User = user;
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         orderGoods.Goods = goods;
                         orderGoods.OrderId = order.Id;
                         if (!tmpList.TryGetValue(order.Id.Value, out dto))
                         {
                             dto = order;
                             dto.OrderGoods = new List<OrderGoodsDto>() { orderGoods };
                             tmpList.Add(order.Id.Value, dto);
                         }
                         else
                         {
                             dto.OrderGoods.Add(orderGoods);
                         }
                         return dto;
                     },
                     new
                     {
                         UserId
                     },
                     splitOn: "id",
                    commandType: CommandType.StoredProcedure
                    ).Distinct()
                    .ToList();                
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<OrderDto>> SelectOrderByStorageId(int StorageId)
        {
            var data = new DataWrapper<List<OrderDto>>();
            var tmpList = new Dictionary<int, OrderDto>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, UserDto, GoodsDto, OrderDto>(
                     StorageProcedure.SelectOrderByStorageId,
                     (orderGoods, order, storage, payment, status, user, goods) =>
                     {
                         OrderDto dto;
                         order.User = user;
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         orderGoods.Goods = goods;
                         orderGoods.OrderId = order.Id;
                         if (!tmpList.TryGetValue(order.Id.Value, out dto))
                         {
                             dto = order;
                             dto.OrderGoods = new List<OrderGoodsDto>() { orderGoods };
                             tmpList.Add(order.Id.Value, dto);
                         }
                         else
                         {
                             dto.OrderGoods.Add(orderGoods);
                         }
                         return dto;
                     },
                     new
                     {
                         StorageId
                     },
                     splitOn: "id",
                    commandType: CommandType.StoredProcedure
                    ).Distinct()
                    .ToList();                
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<OrderDto> UpdateStatusOrderByOrderId(int orderId, int statusId)
        {
            var data = new DataWrapper<OrderDto>();
            var list = new List<OrderGoodsDto>();
            try
            {
                data.Data = DbConnection.Query<OrderGoodsDto, OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, UserDto, GoodsDto, OrderDto>(
                     StorageProcedure.UpdateStatusOrderByOrderId,
                     (orderGoods, order, storage, payment, status, user, goods) =>
                     {
                         order.User = user;
                         order.PaymentType = payment;
                         order.StatusOrder = status;
                         order.Storage = storage;
                         orderGoods.Goods = goods;
                         list.Add(orderGoods);
                         return order;
                     },
                     new
                     {
                         orderId,
                         statusId
                     },
                    commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                data.Data.OrderGoods = list;
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

    }
}
