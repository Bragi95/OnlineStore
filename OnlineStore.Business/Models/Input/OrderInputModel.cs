using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class OrderInputModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? StorageId { get; set; }
        public int? StatusOrderId { get; set; }
        public OrderGoodsInputModel? OrderGoods { get; set; }
        public string DateOrder { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
