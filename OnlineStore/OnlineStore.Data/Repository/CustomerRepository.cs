using Dapper;
using OnlineStore.Data.Dto;
using Shop.Data;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public class CustomerRepository : BaseRepository, IUserRepository
    {
        public DataWrapper<UserDto> MergeUser(UserDto dto)
        {
            var data = new DataWrapper<UserDto>();
            try
            {
                data.Data = DbConnection.Query<UserDto, CountryDto, CityDto, RoleDto, UserDto>(
                  StorageProcedure.MergeUser,
                   (customer, country, city, role) =>
                   {
                       customer.Country = country;
                       customer.City = city;
                       customer.Role = role;
                       return customer;
                   },
                   new
                   {
                       dto.Id,
                       CountryId = dto.Country.id,
                       CityId = dto.City.id,
                       dto.Name,
                       dto.LastName,
                       dto.Phone,
                       dto.Email,
                       dto.Address,
                       dto.Password
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<UserDto> SelectUserById(int id)
        {
            var data = new DataWrapper<UserDto>();
            try
            {
                data.Data = DbConnection.Query<UserDto, CountryDto, CityDto, RoleDto, UserDto>(
                  StorageProcedure.SelectUser,
                   (customer, country, city, role) =>
                   {
                       customer.Country = country;
                       customer.City = city;
                       customer.Role = role;
                       return customer;
                   },
                   new
                   {
                       id
                   },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }

        public DataWrapper<List<UserDto>> SelectAllUser()
        {
            var data = new DataWrapper<List<UserDto>>();
            try
            {
                data.Data = DbConnection.Query<UserDto, CountryDto, CityDto, RoleDto, UserDto>(
                 StorageProcedure.SelectAllUser,
                  (customer, country, city, role) =>
                  {
                      customer.Country = country;
                      customer.City = city;
                      customer.Role = role;
                      return customer;
                  },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                   ).ToList();
            }
            catch (Exception ex)
            {
                data.ExceptionMessage = ex.Message;
            }
            return data;
        }
    }
}
