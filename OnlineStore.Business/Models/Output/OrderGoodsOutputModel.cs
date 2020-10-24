using Humanizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class OrderGoodsOutputModel
    {
        public int Id { get; set; }
        public GoodsOutputModel Goods { get; set; }
        public OrderOutputModel Order { get; set; }
        public int Quantity { get; set; }
    }
}
