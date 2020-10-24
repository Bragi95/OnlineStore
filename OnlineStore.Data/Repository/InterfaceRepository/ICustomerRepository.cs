using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface ICustomerRepository
    {
        DataWrapper<CustomerDto> MergeCustomer(CustomerDto dto);
        DataWrapper<List<CustomerDto>> SelectAllCustomer();
        DataWrapper<CustomerDto> SelectCustomerById(int id);
    }
}