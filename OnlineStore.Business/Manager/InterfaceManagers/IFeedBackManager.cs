using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.Business.Manager
{
    public interface IFeedBackManager
    {
        DataWrapper<FeedBackOutputModel> FeedBackMerge(FeedBackInputModel model);
        DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByUserId(int id);
        DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByGoodsId(int id);
        DataWrapper<FeedBackOutputModel> SelectFeedBackById(int id);
        DataWrapper<List<FeedBackOutputModel>> SelectFeedBackByStorageId(int id);
    }
}