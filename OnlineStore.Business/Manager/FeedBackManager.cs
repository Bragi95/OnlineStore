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
    public class FeedBackManager : IFeedBackManager
    {
        IFeedBackRepository _feedBackRepository;
        IMapper _mapper;

        public FeedBackManager(IFeedBackRepository feedBackRepository, IMapper mapper)
        {
            _feedBackRepository = feedBackRepository;
            _mapper = mapper;
        }

        public DataWrapper<FeedBackOutputModel> FeedBackMerge(FeedBackInputModel model)
        {
            var dto = _mapper.Map<FeedBackDto>(model);
            var feedback = _feedBackRepository.FeedBackMerge(dto);
            var result = _mapper.Map<FeedBackOutputModel>(feedback.Data);

            return new DataWrapper<FeedBackOutputModel>
            {
                Data = result,
                ExceptionMessage = feedback.ExceptionMessage
            };
        }

        public DataWrapper<FeedBackOutputModel> SelectFeedBackById(int id)
        {
            var feedback = _feedBackRepository.SelectFeedBackById(id);
            var result = _mapper.Map<FeedBackOutputModel>(feedback.Data);

            return new DataWrapper<FeedBackOutputModel>
            {
                Data = result,
                ExceptionMessage = feedback.ExceptionMessage
            };
        }

        public DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByUserId(int id)
        {
            var feedback = _feedBackRepository.SelectFeedBackByUserId(id);
            var result = _mapper.Map<List<FeedBackOutputModel>>(feedback.Data);

            return new DataWrapper<List<FeedBackOutputModel>>
            {
                Data = result,
                ExceptionMessage = feedback.ExceptionMessage
            };
        }

        public DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByStorageId(int id)
        {
            var feedback = _feedBackRepository.SelectFeedBackByStorageId(id);
            var result = _mapper.Map<List<FeedBackOutputModel>>(feedback.Data);

            return new DataWrapper<List<FeedBackOutputModel>>
            {
                Data = result,
                ExceptionMessage = feedback.ExceptionMessage
            };
        }

        public DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByGoodsId(int id)
        {
            var feedback = _feedBackRepository.SelectFeedBackByGoodsId(id);
            var result = _mapper.Map<List<FeedBackOutputModel>>(feedback.Data);

            return new DataWrapper<List<FeedBackOutputModel>>
            {
                Data = result,
                ExceptionMessage = feedback.ExceptionMessage
            };
        }
    }
}
