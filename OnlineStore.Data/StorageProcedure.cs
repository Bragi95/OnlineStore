using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data
{
    public class StorageProcedure
    {
        public const string MergeGoods = "MergeGoods";
        public const string MergeUser = "MergeUser";
        public const string MergeOrder = "MergeOrder";
        public const string MergeOrderGoods = "MergeOrder_Goods";
        public const string AddOrUpdate = "AddOrUpdate";
        public const string SearchGoods = "SearchGoods";
        public const string SelectUser = "SelectUserById";
        public const string SelectAllUser = "SelectAllUsers";
        public const string SelectOrderById = "SelectOrderById";
        public const string SelectQuantityGooldsByStorageId = "SelectQuantityGoodsByStorageId";
        public const string SelectAllQuantityGoods = "SelectAllQuantityGoods";
        public const string SelectOrderByUserId = "SelectOrderByUserId";
        public const string SelectOrderByStorageId = "SelectOrderByStorageId";
        public const string Transfer = "TransferGoods";
        public const string UpdateStatusOrderByOrderId = "UpdateStatusOrderByOrderId";
    }
}
