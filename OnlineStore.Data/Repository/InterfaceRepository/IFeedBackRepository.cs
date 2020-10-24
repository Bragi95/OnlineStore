using OnlineStore.Data.Dto;

namespace OnlineStore.Data.Repository
{
    public interface IFeedBackRepository
    {
        FeedBackDto FeedBackMerge(FeedBackDto dto);
        FeedBackDto SelectFeedBackByCustomerId(int id);
        FeedBackDto SelectFeedBackById(int id);
    }
}