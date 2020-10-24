using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    class FeedBackInputModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? StorageId { get; set; }
        public int? GoodsId { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public double? Rating { get; set; }
    }
}
