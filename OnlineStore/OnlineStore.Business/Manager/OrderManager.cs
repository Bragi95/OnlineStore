using AutoMapper;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Business.Manager
{
    public class OrderManager : IOrderManager
    {
        IOrderRepository _repository;
        IOrderGoodsRepository _orderGoods;
        IMapper _mapper;
        IGoodsStorageRepository _goodsStorageRepository;
        public OrderManager(IOrderRepository order, IOrderGoodsRepository orderGoods, IMapper mapper, IGoodsStorageRepository goodsStorageRepository)
        {
            _repository = order;
            _orderGoods = orderGoods;
            _mapper = mapper;
            _goodsStorageRepository = goodsStorageRepository;
        }
        public DataWrapper<OrderOutputModel> MergeOrder(OrderInputModel order)
        {
            var dto = _mapper.Map<OrderDto>(order);
            var orderDto = _repository.MergeOrder(dto);


            orderDto.Data.OrderGoods = dto.OrderGoods;
            foreach (var item in orderDto.Data.OrderGoods)
            {
                item.OrderId = orderDto.Data.Id;
            }

            orderDto.Data.OrderGoods = _orderGoods.MergeOrderGoods(orderDto.Data.OrderGoods).Data;
            orderDto.Data.TotalCost = orderDto.Data.OrderGoods.Sum(x => x.Goods.Price * x.QuantityGoods);

            var changeTotalCost = orderDto.Data;
            _repository.MergeOrder(changeTotalCost);
            
            var result = _mapper.Map<OrderOutputModel>(orderDto.Data);

            return new DataWrapper<OrderOutputModel>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }


        public DataWrapper<OrderOutputModel> UpdateStatusOrderByOrderId(int id ,int statusOrderId)
        {
           var orderDto =  _repository.UpdateStatusOrderByOrderId(id, statusOrderId);

            if (orderDto.Data.StatusOrder.Name == "OrderCollected")
            {
                foreach (var item in orderDto.Data.OrderGoods)
                {
                    _goodsStorageRepository.AddOrUpdate(new GoodsStorageDto()
                    {
                        Goods = item.Goods,
                        QuantityGoods = item.QuantityGoods,
                        Storage = orderDto.Data.Storage,
                        Sale = true
                    });
                }
            }
            else if (orderDto.Data.StatusOrder.Name == "Return")
            {
                foreach (var item in orderDto.Data.OrderGoods)
                {
                    _goodsStorageRepository.AddOrUpdate(new GoodsStorageDto()
                    {
                        Goods = item.Goods,
                        QuantityGoods = item.QuantityGoods,
                        Storage = orderDto.Data.Storage
                    });
                }
            }
            var result = _mapper.Map<OrderOutputModel>(orderDto.Data);

            return new DataWrapper<OrderOutputModel>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }
        public DataWrapper<OrderOutputModel> GetOrderById(int id)
        {
            var orderDto = _repository.SelectOrderById(id);

            var result = _mapper.Map<OrderOutputModel>(orderDto.Data);

            return new DataWrapper<OrderOutputModel>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }

        public DataWrapper<List<OrderOutputModel>> GetOrderByUserId(int id)
        {
            var orderDto = _repository.SelectOrderByUserId(id);

            var result = _mapper.Map<List<OrderOutputModel>>(orderDto.Data);

            return new DataWrapper<List<OrderOutputModel>>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }

        public DataWrapper<List<OrderOutputModel>> GetOrderByStorageId(int id)
        {
            var orderDto = _repository.SelectOrderByStorageId(id);

            var result = _mapper.Map<List<OrderOutputModel>>(orderDto.Data);

            return new DataWrapper<List<OrderOutputModel>>
            {
                Data = result,
                ExceptionMessage = orderDto.ExceptionMessage
            };
        }
    }
}
