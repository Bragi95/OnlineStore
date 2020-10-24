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
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public DataWrapper<CustomerDto> MergeCustomer(CustomerDto dto)
        {
            var data = new DataWrapper<CustomerDto>();
            try
            {
                data.Data = DbConnection.Query<CustomerDto, CountryDto, CityDto, RoleDto, CustomerDto>(
                  StorageProcedure.MergeCustomer,
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
                       dto.Email
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

        public DataWrapper<CustomerDto> SelectCustomerById(int id)
        {
            var data = new DataWrapper<CustomerDto>();
            try
            {
                data.Data = DbConnection.Query<CustomerDto, CountryDto, CityDto, RoleDto, CustomerDto>(
                  StorageProcedure.MergeCustomer,
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

        public DataWrapper<List<CustomerDto>> SelectAllCustomer()
        {
            var data = new DataWrapper<List<CustomerDto>>();
            try
            {
                data.Data = DbConnection.Query<CustomerDto, CountryDto, CityDto, RoleDto, CustomerDto>(
                 StorageProcedure.MergeCustomer,
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
