using System.Collections.Generic;

namespace OnlineStore.Business.Models.Input
{
    public class OrderInputModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int PaymentTypeId { get; set; }
        public int StorageId { get; set; }
        public int StatusOrderId { get; set; }
        public List<OrderGoodsInputModel> OrderGoods { get; set; }         
    }
}
