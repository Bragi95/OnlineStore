using AutoMapper;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using OnlineStore.Data.Dto;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Manager
{
    public class UserManager : IUserManager
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public DataWrapper<UserOutputModel> Merge(UserInpudModel model)
        {
            var dto = _mapper.Map<UserDto>(model);
            var result = _userRepository.MergeUser(dto);
            var mapping = _mapper.Map<UserOutputModel>(result.Data);

            return new DataWrapper<UserOutputModel>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<UserOutputModel> SelectUserById(int id)
        {

            var result = _userRepository.SelectUserById(id);
            var mapping = _mapper.Map<UserOutputModel>(result.Data);

            return new DataWrapper<UserOutputModel>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }

        public DataWrapper<List<UserOutputModel>> SelectUsers()
        {
            var result = _userRepository.SelectAllUser();
            var mapping = _mapper.Map<List<UserOutputModel>>(result.Data);

            return new DataWrapper<List<UserOutputModel>>
            {
                Data = mapping,
                ExceptionMessage = result.ExceptionMessage
            };
        }
    }
}
