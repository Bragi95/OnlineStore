using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class GoodsStorageDto
    {
        public int? id { get; set; }
        public GoodsDto? Goods { get; set; }
        public StorageDto? Storage { get; set; }
        public int? QuantityGoods {get;set;}
        public bool? Sale {get;set;}
        
    }
}
