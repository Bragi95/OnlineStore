using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class OrderGoodsDto
    {
        public int? id { get; set; }
        public GoodsDto Goods { get; set; }
        public int? OrderId { get; set; }
        public int? QuantityGoods { get; set; }
    }
}
