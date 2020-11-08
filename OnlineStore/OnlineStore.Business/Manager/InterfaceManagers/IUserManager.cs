using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public interface IUserManager
    {
        DataWrapper<UserOutputModel> Merge(UserInpudModel model);
        DataWrapper<UserOutputModel> SelectUserById(int id);
        DataWrapper<List<UserOutputModel>> SelectUsers();
    }
}