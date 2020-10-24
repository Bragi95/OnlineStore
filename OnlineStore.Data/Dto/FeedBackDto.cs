using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public CustomerDto CustomerId { get; set; }
        public StorageDto StorageId { get; set; }
        public GoodsDto GoodsId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public double Rating { get; set; }
    }
}
