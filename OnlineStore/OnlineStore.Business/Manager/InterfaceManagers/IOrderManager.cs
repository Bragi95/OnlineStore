using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public interface IOrderManager
    {
        DataWrapper<List<OrderOutputModel>> GetOrderByUserId(int id);
        DataWrapper<OrderOutputModel> GetOrderById(int id);
        DataWrapper<List<OrderOutputModel>> GetOrderByStorageId(int id);
        DataWrapper<OrderOutputModel> MergeOrder(OrderInputModel order);
        DataWrapper<OrderOutputModel> UpdateStatusOrderByOrderId(int id, int statusOrderId);
    }
}