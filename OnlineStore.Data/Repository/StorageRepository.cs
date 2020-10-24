using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Repository
{
    public class StorageRepository : BaseRepository, IStorageRepository
    {
        public OrderDto SelectOrderById(int id)
        {
            var query = db.Query("Order").
                Join("Customer", "Customer.Id", "Order.CustomerId").
                Join("Storage", "Storage.Id", "Order.StorageId").
                Join("PaymentType", "PaymentType.Id", "Order.PaymentTypeId").
                Join("StatusOrder", "StatusOrder.Id", "Order.StatusOrderId").
                LeftJoin("Order_Goods", "Order_Goods.orderId", "Order.Id").
                LeftJoin("Goods", "Goods.Id", "Order_Goods.goodsId").
                Select(
                "Storage.Name",
                "Storage.CityId",
                "Storage.Address",
                "Storage.Phone",
                "Goods.Brand",
                "Goods.Model",
                "Order_Goods.QuantityGoods",
                "(Goods.Price * Order_Goods.QuantityGoods) as Price",
                "sum(Price) as TotalCost"
                ).
                Where("id", id).
                Get<OrderDto>();

            return (OrderDto)query;
        }


        public StorageDto StorageMerge(StorageDto dto)
        {
            int id;
            var query = db.Query("Storage");
            if (dto.id > 0)
            {
                query.Where("Id", dto.id).Update(
                    new
                    {
                        CountryId = dto.Country.id,
                        CiryId = dto.City.id,
                        name = dto.Name,
                        address = dto.Address,
                        phone = dto.Phone,
                        email = dto.Email
                    }
                    );
                id = dto.id;
            }
            else
            {
                id = query.InsertGetId<int>(new
                {
                    CountryId = dto.Country.id,
                    CiryId = dto.City.id,
                    name = dto.Name,
                    address = dto.Address,
                    phone = dto.Phone,
                    email = dto.Email
                });
            }

            return SelectStorageById(id);
        }

        public StorageDto SelectStorageById(int id)
        {
            var query = db.Query("Storage").
                Join("Country", "Country.Id", "Storage.CountryId").
                Join("City", "City.Id", "Storage.CityId").
                Select(
                "Country.Name",
                "City.Name",
                "Storage.Name",
                "Storage.Address",
                "Storage.Phone",
                "Storage.Email"
                ).
                Where("id", id).
                Get<StorageDto>();

            return (StorageDto)query;
        }

        public StorageDto SelectStorageByCountryId(int id)
        {
            var query = db.Query("Storage").
                Join("Country", "Country.Id", "Storage.CountryId").
                Join("City", "City.Id", "Storage.CityId").
                Select(
                "Country.Name",
                "City.Name",
                "Storage.Name",
                "Storage.Address",
                "Storage.Phone",
                "Storage.Email"
                ).
                Where("countryId", id).
                Get<StorageDto>();

            return (StorageDto)query;
        }

        public StorageDto SelectStorageByCityId(int id)
        {
            var query = db.Query("Storage").
                Join("Country", "Country.Id", "Storage.CountryId").
                Join("City", "City.Id", "Storage.CityId").
                Select(
                "Country.Name",
                "City.Name",
                "Storage.Name",
                "Storage.Address",
                "Storage.Phone",
                "Storage.Email"
                ).
                Where("cityId", id).
                Get<StorageDto>();

            return (StorageDto)query;
        }
    }
}
