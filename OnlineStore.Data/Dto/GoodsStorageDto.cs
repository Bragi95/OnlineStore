using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class GoodsStorageDto
    {
        public int? id { get; set; }
        public int? GoodsId { get; set; }
        public int? StorageId { get; set; }
        public int? QuantityGoods {get;set;}
        public bool? Sale {get;set;}
    }
}
