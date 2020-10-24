using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class OrderGoodsInputModel
    {
        public int? id { get; set; }
        public List<int>? GoodsId { get; set; }
        public int? OrderId { get; set; }
        public int? QuantityGoods { get; set; }
    }
}
