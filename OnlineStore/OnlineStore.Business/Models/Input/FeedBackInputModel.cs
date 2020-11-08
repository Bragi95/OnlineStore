using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.Business.Models.Input
{
    public class FeedBackInputModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        public int StorageId { get; set; }
        [Required]
        public int GoodsId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }
        [Required]
        [Range(1,5)]
        public double? Rating { get; set; }
    }
}
