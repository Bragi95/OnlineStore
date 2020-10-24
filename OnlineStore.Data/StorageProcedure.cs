using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data
{
    public class StorageProcedure
    {
        public const string MergeGoods = "MergeGoods";
        public const string MergeCustomer = "MergeCustomer";
        public const string MergeOrder = "MergeOrder";
        public const string MergeOrderGoods = "MergeOrder_Goods";
        public const string AddOrUpdate = "AddOrUpdate";
        public const string SearchGoods = "SearchGoods";
        public const string SelectCustomer = "SelectCustomerById";
        public const string SelectAllCustomer = "SelectAllCustomer";
        public const string SelectOrderById = "SelectOrderById";
        public const string SelectOrderByStorageId = "SelectOrderByStorageId";
        public const string SelectOrderByCustomerId = "SelectOrderByCustomerId";
        public const string Transfer = "TransferGoods";
    }
}
