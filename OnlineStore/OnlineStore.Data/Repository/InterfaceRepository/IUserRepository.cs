using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IUserRepository
    {
        DataWrapper<UserDto> MergeUser(UserDto dto);
        DataWrapper<List<UserDto>> SelectAllUser();
        DataWrapper<UserDto> SelectUserById(int id);
    }
}