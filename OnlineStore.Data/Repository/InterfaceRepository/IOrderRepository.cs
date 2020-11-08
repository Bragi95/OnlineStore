using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IOrderRepository
    {
        DataWrapper<OrderDto> MergeOrder(OrderDto dto);
        DataWrapper<OrderDto> SelectOrderById(int id);
        DataWrapper<List<OrderDto>> SelectOrderByUserId(int customerId);
        DataWrapper<List<OrderDto>> SelectOrderByStorageId(int storageId);
        DataWrapper<OrderDto> UpdateStatusOrderByOrderId(int orderId, int statusId);
    }
}