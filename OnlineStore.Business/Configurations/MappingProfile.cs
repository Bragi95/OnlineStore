using AutoMapper;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OnlineStore.Business.Configurations
{
    class MappingProfile : Profile
    {
       
            private const string _shortDateFormat = "dd.MM.yyyy";
            private const string _longDateFormat = "dd.MM.yyyy HH:mm:ss";
            public MappingProfile()
            {
                CreateMap<OrderInputModel, OrderDto>()
                    .ForPath(dest => dest.Customer, o => o.MapFrom(src => src.CustomerId != null ? new CustomerDto() { Id = src.CustomerId } : null))
                    .ForPath(dest => dest.DateOrder, o => o.MapFrom(src => src.DateOrder != null ? (DateTime?)DateTime.ParseExact(src.DateOrder, _longDateFormat, CultureInfo.InvariantCulture) : null))
                    .ForPath(dest => dest.PaymentType, o => o.MapFrom(src => src.PaymentTypeId != null ? new PaymentTypeDto() { id = (int)src.PaymentTypeId } : null)) 
                    .ForPath(dest => dest.StatusOrder, o => o.MapFrom(src => src.StatusOrderId != null ? new StatusOrderDto() { id = (int)src.StatusOrderId } : null)) 
                    .ForPath(dest => dest.Storage, o => o.MapFrom(src => src.StorageId != null ? new StorageDto() { id = (int)src.StorageId } : null)) 
                    .ForPath(dest => dest.Goods, o => o.MapFrom(src => src.OrderGoods != null ? new List<OrderGoodsDto>(): null));

                CreateMap<OrderDto, OrderOutputModel>()
                    .ForPath(dest => dest.Address, o => o.MapFrom(src => src.Customer.Address))
                    .ForPath(dest => dest.Name, o => o.MapFrom(src => src.Customer.Name))
                    .ForPath(dest => dest.LastName, o => o.MapFrom(src => src.Customer.LastName))
                    .ForPath(dest => dest.Phone, o => o.MapFrom(src => src.Customer.Phone))
                    .ForPath(dest => dest.StatusOrder, o => o.MapFrom(src => src.StatusOrder.Name))
                    .ForPath(dest => dest.StorageAddress, o => o.MapFrom(src => src.Storage.Address))
                    .ForPath(dest => dest.StorageName, o => o.MapFrom(src => src.Storage.Name))
                    .ForPath(dest => dest.StoragePhone, o => o.MapFrom(src => src.Storage.Phone))                    
                    .ForPath(dest => dest.DateOrder, o => o.MapFrom(src => src.DateOrder.ToString()))
                    .ForPath(dest => dest.PaymentType, o => o.MapFrom(src => src.PaymentType.Name));

                    
            }
        
    }
}
