using AutoMapper;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public class OrderManager
    {
        IOrderRepository repository;
        IOrderGoodsRepository orderGoods;
        IMapper _mapper;
        public OrderManager(IOrderRepository order, IOrderGoodsRepository orderGoods, IMapper mapper)
        {
            repository = order;
            this.orderGoods = orderGoods;
            _mapper = mapper;
        }
        public DataWrapper<OrderOutputModel> Merge(OrderInputModel order)
        {
            var dto = _mapper.Map<OrderDto>(order);
            var orderDto = repository.MergeOrder(dto);
            foreach (var item in orderDto.Data.Goods)
            {
                item.Order = orderDto.Data;
            }

            orderDto.Data.Goods = orderGoods.MergeOrderGoods(orderDto.Data.Goods).Data;
            foreach (var item in orderDto.Data.Goods)
            {
                orderDto.Data.TotalCost += item.Goods.Price * item.QuantityGoods;
            }



            var result = _mapper.Map<OrderOutputModel>(orderDto.Data);            

            return new DataWrapper<OrderOutputModel>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }
    }
}
