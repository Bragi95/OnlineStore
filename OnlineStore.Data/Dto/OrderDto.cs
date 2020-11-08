using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public UserDto? User { get; set; }
        public PaymentTypeDto? PaymentType { get; set; }
        public StorageDto? Storage { get; set; }
        public StatusOrderDto? StatusOrder { get; set; }
        public List<OrderGoodsDto> OrderGoods { get; set; }
        public DateTime? DateOrder { get; set; }
        public decimal? TotalCost { get; set; }

    }
}
