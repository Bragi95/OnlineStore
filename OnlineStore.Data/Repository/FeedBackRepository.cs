using OnlineStore.Data.Dto;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public class FeedBackRepository : BaseRepository, IFeedBackRepository
    {
        public FeedBackDto SelectFeedBackById(int id)
        {
            var query = db.Query("FeedBack").
                Join("Customer", "Customer.Id", "Order.CustomerId").
                Join("Storage", "Storage.Id", "Order.StorageId").
                Join("Goods", "Goods.Id", "Order_Goods.goodsId").
                Select(
                "Customer.Name",
                "Customer.LastName",
                "Storage.Name",
                "Storage.CityId",
                "Goods.Brand",
                "Goods.Model",
                "Goods.Price"
                ).
                Where("id", id).
                Get<FeedBackDto>();

            return (FeedBackDto)query;
        }

        public FeedBackDto SelectFeedBackByCustomerId(int id)
        {
            var query = db.Query("FeedBack").
                Join("Customer", "Customer.Id", "Order.CustomerId").
                Join("Storage", "Storage.Id", "Order.StorageId").
                Join("Goods", "Goods.Id", "Order_Goods.goodsId").
                Select(
                "Customer.Name",
                "Customer.LastName",
                "Storage.Name",
                "Storage.CityId",
                "Goods.Brand",
                "Goods.Model",
                "Goods.Price"
                ).
                Where("CustomerId", id).
                Get<FeedBackDto>();

            return (FeedBackDto)query;
        }

        public FeedBackDto FeedBackMerge(FeedBackDto dto)
        {
            int id;
            var query = db.Query("FeedBack");
            if (dto.Id > 0)
            {
                query.Where("Id", dto.Id).Update(
                    new
                    {
                        goodsId = dto.GoodsId,
                        storageId = dto.StorageId,
                        message = dto.Message,
                        rating = dto.Rating
                    }
                    );
                id = dto.Id;
            }
            else
            {
                id = query.InsertGetId<int>(new
                {
                    customerId = dto.CustomerId,
                    goodsId = dto.GoodsId,
                    storageId = dto.StorageId,
                    date = DateTime.Now,
                    message = dto.Message,
                    rating = dto.Rating
                });
            }

            return SelectFeedBackById(id);
        }
    }
}
