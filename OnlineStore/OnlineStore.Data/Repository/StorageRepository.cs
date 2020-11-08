using Dapper;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Data.Repository
{
    public class StorageRepository : BaseRepository, IStorageRepository
    {     
        public DataWrapper<StorageDto> StorageMerge(StorageDto dto)
        {
            int id;
            var query = db.Query("Storage");
            if (dto.Id > 0)
            {
                query.Where("Id", dto.Id).Update(
                    new
                    {
                        CountryId = dto.Country.id,
                        CityId = dto.City.id,
                        name = dto.Name,
                        address = dto.Address,
                        phone = dto.Phone,
                        email = dto.Email
                    }
                    );
                id = dto.Id.Value;
            }
            else
            {
                id = query.InsertGetId<int>(new
                {
                    CountryId = dto.Country.id,
                    CityId = dto.City.id,
                    name = dto.Name,
                    address = dto.Address,
                    phone = dto.Phone,
                    email = dto.Email
                });
            }

            return SelectStorageById(id);
        }

        public DataWrapper<StorageDto> SelectStorageById(int id)
        {
            var data = new DataWrapper<StorageDto>();
            try
            {
                var query = db.Query("Storage").
                    Select(
                    "Storage.{Id, Name, Address,Phone,Email}",
                    "City.{Id, Name}",
                    "Country.{Id, Name}"
                    ).
                    Join("Country", "Country.Id", "Storage.CountryId").
                    Join("City", "City.Id", "Storage.CityId").
                    Where("Storage.Id", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<StorageDto, CityDto, CountryDto, StorageDto>(
                    sqlResult.Sql,
                    (storage, city, country) =>
                    {
                        storage.City = city;
                        storage.Country = country;
                        return storage;
                    },
                    splitOn: "Id",
                    param: sqlResult.NamedBindings).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;           
        }

        public DataWrapper<List<StorageDto>> SelectStorageByCountryId(int id)
        {
            var data = new DataWrapper<List<StorageDto>>();
            try
            {
                var query = db.Query("Storage").
                    Select(
                    "Storage.{Id, Name, Address,Phone,Email}",
                    "City.{Id, Name}",
                    "Country.{Id, Name}"
                    ).
                    Join("Country", "Country.Id", "Storage.CountryId").
                    Join("City", "City.Id", "Storage.CityId").
                    Where("Storage.CountryId", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<StorageDto, CityDto, CountryDto, StorageDto>(
                    sqlResult.Sql,
                    (storage, city, country) =>
                    {
                        storage.City = city;
                        storage.Country = country;
                        return storage;
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

        public DataWrapper<List<StorageDto>> SelectStorageByCityId(int id)
        {
            var data = new DataWrapper<List<StorageDto>>();
            try
            {
                var query = db.Query("Storage").
                    Select(
                    "Storage.{Id, Name, Address,Phone,Email}",
                    "City.{Id, Name}",
                    "Country.{Id, Name}"
                    ).
                    Join("Country", "Country.Id", "Storage.CountryId").
                    Join("City", "City.Id", "Storage.CityId").
                    Where("Storage.CityId", id);

                SqlResult sqlResult = compiler.Compile(query);

                data.Data = DbConnection.Query<StorageDto, CityDto, CountryDto, StorageDto>(
                    sqlResult.Sql,
                    (storage, city, country) =>
                    {
                        storage.City = city;
                        storage.Country = country;
                        return storage;
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
