using OnlineStore.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class FeedBackOutputModel
    {
        public int Id { get; set; }
        public string  UserName { get; set; }       
        public string StorageName { get; set; }
        public string CityName { get; set; }
        public string GoodsBrand { get; set; }
        public string GoodsModel { get; set; }
        public decimal GoodsPrice { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public double Rating { get; set; }
    }
}
