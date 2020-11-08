using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public StorageDto Storage { get; set; }
        public GoodsDto Goods { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public double Rating { get; set; }
    }
}
