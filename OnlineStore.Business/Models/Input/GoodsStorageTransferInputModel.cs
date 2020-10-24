using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class GoodsStorageTransferInputModel 
    {
        public int? GoodsId { get; set; }
        public int? StorageId { get; set; }
        public int? QuantityGoods { get; set; }
        public int? RecipiendId { get; set; }
    }
}
