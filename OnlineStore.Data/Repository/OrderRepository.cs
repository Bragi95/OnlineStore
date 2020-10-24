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
                data.Data = DbConnection.Query<OrderDto, StorageDto, PaymentTypeDto, StatusOrderDto, CustomerDto, OrderDto>(
                  StorageProcedure.MergeCustomer,
                  (order, storage, payment, status, customer) =>
                  {
                      order.PaymentType = payment;
                      order.StatusOrder = status;
                      order.Storage = storage;
                      order.Customer = customer;
                      return order;
                  },
                   new
                   {
                       dto.Id,
                       PaymetnTypeId = dto.PaymentType.id,
                       StatusOrderId = dto.StatusOrder.id,
                       StorageID = dto.Storage.id,
                       CustomerId = dto.Customer.Id,
                       dto.DateOrder,
                       dto.TotalCost
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();

            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }


    }
}
