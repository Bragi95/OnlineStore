using OnlineStore.Data;
using OnlineStore.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Business.Models.Output
{
    public class OrderOutputModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PaymentType { get; set; }
        public string StorageName { get; set; }
        public string StorageAddress { get; set; }
        public string StoragePhone { get; set; }
        public string StatusOrder { get; set; }
        public List<OrderGoodsOutputModel>? Goods { get; set; }
        public string DateOrder { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
