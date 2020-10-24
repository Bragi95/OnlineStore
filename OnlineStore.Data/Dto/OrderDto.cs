using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public CustomerDto? Customer { get; set; }
        public PaymentTypeDto? PaymentType { get; set; }
        public StorageDto? Storage { get; set; }
        public StatusOrderDto? StatusOrder { get; set; }
        public List<OrderGoodsDto>? Goods { get; set; }
        public DateTime? DateOrder { get; set; }
        public decimal? TotalCost { get; set; }

    }
}
