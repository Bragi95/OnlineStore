using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class TransferGoodsOutputModel
    {        public int? RecipiendId { get; set; }
        public int? id { get; set; }
        public int? GoodsId { get; set; }
        public int? SenderId { get; set; }
        public int? QuantityGoods { get; set; }
    }
}
