using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class GoodsStorageInputModel
    {
        public int? GoodsId { get; set; }
        public int? StorageId { get; set; }
        public int? QuantityGoods { get; set; }       
    }
}
