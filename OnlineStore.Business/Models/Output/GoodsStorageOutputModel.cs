using OnlineStore.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class GoodsStorageOutputModel
    {
        public int? id { get; set; }
        public GoodsOutputModel Goods { get; set; }
        public StorageOutputModel Storage { get; set; }
        public int? QuantityGoods { get; set; }        
    }
}
