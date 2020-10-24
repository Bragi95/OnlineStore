using OnlineStore.Data.Dto;

namespace OnlineStore.Data.Repository
{
    public interface IOrderRepository
    {
        DataWrapper<OrderDto> MergeOrder(OrderDto dto);
    }
}