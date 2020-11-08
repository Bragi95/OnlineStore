using Dapper;
using OnlineStore.Data.Dto;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public class FeedBackRepository : BaseRepository, IFeedBackRepository
    {
        public DataWrapper<FeedBackDto> FeedBackMerge(FeedBackDto dto)
        {
            int id;
            var query = db.Query("FeedBack");
            if (dto.Id > 0)
            {
                query.Where("Id", dto.Id).Update(
                    new
                    {
                        goodsId = dto.Goods.Id,
                        storageId = dto.Storage.Id,
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
                    userId = dto.User.Id,
                    goodsId = dto.Goods.Id,
                    storageId = dto.Storage.Id,
                    date = DateTime.Now,
                    message = dto.Message,
                    rating = dto.Rating
                });
            }

            return SelectFeedBackById(id);
        }
        public DataWrapper<FeedBackDto> SelectFeedBackById(int id)
        {
            var data = new DataWrapper<FeedBackDto>();
            try
            {
                var query = db.Query("FeedBack").
                Select(
                "FeedBack.{Id,Message,Date, Rating}",
                "Storage.{Id, Name}",
                "City.{Id, Name}",
                "Goods.{Id, Brand, Model, Price}",
                "User.{Id,Name}"
                ).
                Join("User", "User.Id", "FeedBack.UserId").
                Join("Storage", "Storage.Id", "FeedBack.StorageId").
                Join("Goods", "Goods.Id", "FeedBack.goodsId").
                Join("City", "City.Id", "Storage.CityId").
                Where("FeedBack.Id", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<FeedBackDto, StorageDto, CityDto, GoodsDto, UserDto, FeedBackDto>(
                    sqlResult.Sql,
                    (feedback, storage, city,goods, user) =>
                    {
                        storage.City = city;
                        feedback.Goods = goods;
                        feedback.Storage = storage;
                        feedback.User = user;
                        return feedback;
                    },
                    splitOn: "Id",
                    param: sqlResult.NamedBindings).
                    SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<FeedBackDto>> SelectFeedBackByUserId(int id)
        {
            var data = new DataWrapper<List<FeedBackDto>>();
            try
            {
                var query = db.Query("FeedBack").
                Select(
                "FeedBack.{Id,Message,Date, Rating}",
                "Storage.{Id, Name}",
                "City.{Id, Name}",
                "Goods.{Id, Brand, Model, Price}",
                "User.{Id,Name}"
                ).
                Join("User", "User.Id", "FeedBack.UserId").
                Join("Storage", "Storage.Id", "FeedBack.StorageId").
                Join("Goods", "Goods.Id", "FeedBack.goodsId").
                Join("City", "City.Id", "Storage.CityId").
                Where("UserId", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<FeedBackDto, StorageDto, CityDto, GoodsDto, UserDto, FeedBackDto>(
                    sqlResult.Sql,
                    (feedback, storage, city, goods, user) =>
                    {
                        storage.City = city;
                        feedback.Goods = goods;
                        feedback.Storage = storage;
                        feedback.User = user;
                        return feedback;
                    },
                    splitOn: "Id",
                    param: sqlResult.NamedBindings).
                    ToList();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<FeedBackDto>> SelectFeedBackByGoodsId(int id)
        {
            var data = new DataWrapper<List<FeedBackDto>>();
            try
            {
                var query = db.Query("FeedBack").
                Select(
                "FeedBack.{Id,Message,Date, Rating}",
                "Storage.{Id, Name}",
                "City.{Id, Name}",
                "Goods.{Id, Brand, Model, Price}",
                "User.{Id,Name}"
                ).
                Join("User", "User.Id", "FeedBack.UserId").
                Join("Storage", "Storage.Id", "FeedBack.StorageId").
                Join("Goods", "Goods.Id", "FeedBack.goodsId").
                Join("City", "City.Id", "Storage.CityId").
                Where("GoodsId", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<FeedBackDto, StorageDto, CityDto, GoodsDto, UserDto, FeedBackDto>(
                    sqlResult.Sql,
                    (feedback, storage, city, goods, user) =>
                    {
                        storage.City = city;
                        feedback.Goods = goods;
                        feedback.Storage = storage;
                        feedback.User = user;
                        return feedback;
                    },
                    splitOn: "Id",
                    param: sqlResult.NamedBindings).
                    ToList();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<FeedBackDto>> SelectFeedBackByStorageId(int id)
        {
            var data = new DataWrapper<List<FeedBackDto>>();
            try
            {
                var query = db.Query("FeedBack").
                Select(
                "FeedBack.{Id,Message,Date, Rating}",
                "Storage.{Id, Name}",
                "City.{Id, Name}",
                "Goods.{Id, Brand, Model, Price}",
                "User.{Id,Name}"
                ).
                Join("User", "User.Id", "FeedBack.UserId").
                Join("Storage", "Storage.Id", "FeedBack.StorageId").
                Join("Goods", "Goods.Id", "FeedBack.goodsId").
                Join("City", "City.Id", "Storage.CityId").
                Where("StorageId", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<FeedBackDto, StorageDto, CityDto, GoodsDto, UserDto, FeedBackDto>(
                   sqlResult.Sql,
                   (feedback, storage, city, goods, user) =>
                   {
                       storage.City = city;
                       feedback.Goods = goods;
                       feedback.Storage = storage;
                       feedback.User = user;
                       return feedback;
                   },
                   splitOn: "Id",
                   param: sqlResult.NamedBindings).
                   ToList();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
    }
}
