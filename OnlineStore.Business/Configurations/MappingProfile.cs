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
    public class MappingProfile : Profile
    {

        private const string _shortDateFormat = "dd.MM.yyyy";
        private const string _longDateFormat = "dd.MM.yyyy HH:mm:ss";
        public MappingProfile()
        {
            CreateMap<OrderInputModel, OrderDto>()
                .ForMember(dest => dest.User, o => o.MapFrom(src => src.UserId != null ? new UserDto() { Id = src.UserId } : null))
                .ForMember(dest => dest.PaymentType, o => o.MapFrom(src => src.PaymentTypeId != null ? new PaymentTypeDto() { id = (int)src.PaymentTypeId } : null))
                .ForMember(dest => dest.StatusOrder, o => o.MapFrom(src => src.StatusOrderId != null ? new StatusOrderDto() { id = (int)src.StatusOrderId } : null))
                .ForMember(dest => dest.Storage, o => o.MapFrom(src => src.StorageId != null ? new StorageDto() { Id = (int)src.StorageId } : null));


            CreateMap<OrderDto, OrderOutputModel>()
                    .ForMember(dest => dest.Address, o => o.MapFrom(src => src.User.Address))
                    .ForMember(dest => dest.Name, o => o.MapFrom(src => src.User.Name))
                    .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.User.LastName))
                    .ForMember(dest => dest.Phone, o => o.MapFrom(src => src.User.Phone))
                    .ForMember(dest => dest.StatusOrder, o => o.MapFrom(src => src.StatusOrder.Name))
                    .ForMember(dest => dest.StorageAddress, o => o.MapFrom(src => src.Storage.Address))
                    .ForMember(dest => dest.StorageName, o => o.MapFrom(src => src.Storage.Name))
                    .ForMember(dest => dest.StoragePhone, o => o.MapFrom(src => src.Storage.Phone))
                    .ForMember(dest => dest.DateOrder, o => o.MapFrom(src => src.DateOrder.Value.ToString(_shortDateFormat)))
                    .ForMember(dest => dest.PaymentType, o => o.MapFrom(src => src.PaymentType.Name));

            CreateMap<OrderGoodsInputModel, OrderGoodsDto>()
                    .ForPath(dest => dest.QuantityGoods, o => o.MapFrom(src => src.QuantityGoods))
                    .ForPath(dest => dest.Goods, o => o.MapFrom(src => src.GoodsId != null ? new GoodsDto() { Id = src.GoodsId } : null))
                    .ForPath(dest => dest.OrderId, o => o.MapFrom(src => src.OrderId != null ? src.OrderId : null));

            CreateMap<OrderGoodsDto, OrderGoodsOutputModel>()
                    .ForPath(dest => dest.Quantity, o => o.MapFrom(src => src.QuantityGoods))
                    .ForPath(dest => dest.Goods, o => o.MapFrom(src => src.Goods != null ? src.Goods : null))
                    .ForPath(dest => dest.OrderId, o => o.MapFrom(src => src.OrderId != null ? src.OrderId : null));
           

            CreateMap<StorageDto, StorageOutputModel>();

            CreateMap<StorageInputModel, StorageDto>()
                .ForPath(dest => dest.City, o => o.MapFrom(src => src.CityId != null ? new CityDto() { id = src.CityId } : null))
                .ForPath(dest => dest.Country, o => o.MapFrom(src => src.CountryId != null ? new CountryDto() { id = src.CountryId } : null));

            CreateMap<GoodsInputModel, GoodsDto>()
                .ForPath(dest => dest.Country, o => o.MapFrom(src => src.CountryId != null ? new CountryDto() { id = src.CountryId } : null))
                .ForPath(dest => dest.Color, o => o.MapFrom(src => src.ColorId != null ? new ColorDto() { Id = src.ColorId } : null))
                .ForPath(dest => dest.YearOfManufacture, o => o.MapFrom(src => src.YearOfManufacture != null ? (DateTime?)DateTime.ParseExact(src.YearOfManufacture, _shortDateFormat, CultureInfo.InvariantCulture) : null));

            CreateMap<GoodsDto, GoodsOutputModel>()
                .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null))
                .ForPath(dest => dest.YearOfManufacture, o => o.MapFrom(src => src.YearOfManufacture.Value.ToString(_shortDateFormat)));

            CreateMap<GoodsDto, WasherOutputModel>()
                 .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                 .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null));

            CreateMap<GoodsDto, VacuumCleanerOutputModel>()
                 .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                 .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null));

            CreateMap<GoodsDto, MicrowaveOutputModel>()
                 .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                 .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null));

            CreateMap<GoodsDto, MulticookersOutputModel>()
                 .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                 .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null));

            CreateMap<GoodsDto, ElectricKettleOutputModel>()
                 .ForPath(dest => dest.Country, o => o.MapFrom(src => src.Country != null ? new CountryOutputModel() { Id = src.Country.id, Name = src.Country.Name } : null))
                 .ForPath(dest => dest.Color, o => o.MapFrom(src => src.Color != null ? new ColorOutputModel() { Id = src.Color.Id, Name = src.Color.Name } : null));

            CreateMap<SearchInputModel, SearchDto>()
                 .ForPath(dest => dest.YearOfManufactureEnd, o => o.MapFrom(src => src.YearOfManufactureEnd != null ? (DateTime?)DateTime.ParseExact(src.YearOfManufactureEnd, _shortDateFormat, CultureInfo.InvariantCulture) : null))
                 .ForPath(dest => dest.YearOfManufactureStart, o => o.MapFrom(src => src.YearOfManufactureStart != null ? (DateTime?)DateTime.ParseExact(src.YearOfManufactureStart, _shortDateFormat, CultureInfo.InvariantCulture) : null));


            CreateMap<GoodsStorageTransferInputModel, TransferGoodsDto>();             
            

            CreateMap<TransferGoodsDto, TransferGoodsOutputModel>();

            CreateMap<GoodsStorageDto, GoodsStorageOutputModel>();

            CreateMap<UserInpudModel, UserDto>()
                .ForPath(dest => dest.City, o => o.MapFrom(src => src.CityId != null ? new CityDto() { id = src.CityId } : new CityDto()))
                .ForPath(dest => dest.Country, o => o.MapFrom(src => src.CountryId != null ? new CountryDto() { id = src.CityId } : new CountryDto()))
                .ForPath(dest => dest.Role, o => o.MapFrom(src => new RoleDto()));
            
            CreateMap<UserDto, UserOutputModel>();

            CreateMap<FeedBackInputModel, FeedBackDto>()
               .ForPath(dest => dest.User, o => o.MapFrom(src => src.UserId != null ? new UserDto() { Id = src.UserId } : new UserDto() { Id = 2 }))
               .ForPath(dest => dest.Goods, o => o.MapFrom(src => src.GoodsId != null ? new GoodsDto() { Id = src.GoodsId } : new GoodsDto()))
               .ForPath(dest => dest.Storage, o => o.MapFrom(src => src.StorageId != null ? new StorageDto() { Id = src.StorageId } : new StorageDto()))
               .ForPath(dest => dest.Rating, o => o.MapFrom(src => src.Rating != null ? src.Rating : 2.5d));

            CreateMap<FeedBackDto, FeedBackOutputModel>()
               .ForPath(dest => dest.CityName, o => o.MapFrom(src => src.Storage.City.Name));


        }
    }
}
