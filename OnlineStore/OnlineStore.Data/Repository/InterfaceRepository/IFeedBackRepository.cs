using OnlineStore.Data.Dto;
using System.Collections.Generic;

namespace OnlineStore.Data.Repository
{
    public interface IFeedBackRepository
    {
        DataWrapper<FeedBackDto> FeedBackMerge(FeedBackDto dto);
        DataWrapper<FeedBackDto> SelectFeedBackById(int id);
        DataWrapper<List<FeedBackDto>> SelectFeedBackByUserId(int id);
        DataWrapper<List<FeedBackDto>> SelectFeedBackByGoodsId(int id);
        DataWrapper<List<FeedBackDto>> SelectFeedBackByStorageId(int id);
    }
}