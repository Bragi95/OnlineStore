﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Dto
{
    public class GoodsStorageTransferDto : GoodsStorageDto
    { 
        public int? RecipiendId { get; set; }
    }
}
