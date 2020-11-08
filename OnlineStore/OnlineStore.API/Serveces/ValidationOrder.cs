using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlineStore.API.Serveces
{
    public class ValidationOrder
    {
        IOrderManager _orderManager;
        IStorageManager _storageManager;
        IUserManager  _userManager;

        public ValidationOrder(IOrderManager orderManager, IStorageManager storageManager, IUserManager userManager)
        {
            _orderManager = orderManager;
            _storageManager = storageManager;
            _userManager = userManager;
        }

        public string ValidationAddOrder(OrderInputModel model)
        {

           // RuleFor(x => model.UserId).MustNot(0).WithErrorMEssage(ResponseMessage.CustomerFieldMissing);

            var result = string.Empty;
            if (model.UserId == 0)
            {
                result += ResponseMessage.CustomerFieldMissing + " ";
            }
            else if (model.OrderGoods.Count == 0)
            {
                result += ResponseMessage.GoodsFieldMissing + " ";
            }
            else if (model.PaymentTypeId == 0 && model.PaymentTypeId > 3)
            {
                result += ResponseMessage.PaymentTypeFieldMissing + " ";
            }
            else if (model.StatusOrderId == 0 || model.StatusOrderId > 6 || model.StatusOrderId == 5)
            {
                result += ResponseMessage.StatusFieldMissing + " ";
            }
            else if (model.StorageId == 0)
            {
                result += ResponseMessage.StorageFieldMissing + " ";
            }


            if (_storageManager.GetStorageById((int)model.StorageId).Data.Name == null)
            {
                result += ResponseMessage.StorageNotFound + " ";
            }
            if (_userManager.SelectUserById(model.UserId).Data.Name == null)
            {
                result += ResponseMessage.CustomerNotFound + " ";
            }

            return result;
        }
        public string ValidationUpdateOrder(OrderInputModel model)
        {
            var result = string.Empty;
            if(model.UserId == 0 )
            {
                result += ResponseMessage.CustomerFieldMissing + " ";
            }
            else if(model.OrderGoods.Count == 0)
            {
                result += ResponseMessage.GoodsFieldMissing + " ";
            }
            else if (model.PaymentTypeId == 0 && model.PaymentTypeId > 3)
            {
                result += ResponseMessage.PaymentTypeFieldMissing + " ";
            }
            else if (model.StatusOrderId == 0 && model.StatusOrderId > 6)
            {
                result += ResponseMessage.StatusFieldMissing + " ";
            }
            else if (model.StorageId == 0)
            {
                result += ResponseMessage.StorageFieldMissing + " ";
            }


            var order = _orderManager.GetOrderById((int)model.Id);
            if (order.Data == null) {
                result += order.ExceptionMessage + " ";
            };
            if (order.Data.StatusOrder == "Return" && model.StatusOrderId == (int)StatusOrder.Canceled)
            {
                result += ResponseMessage.Canceled + " ";
            }
            if (order.Data.StatusOrder == "OrderCollected" && model.StatusOrderId == (int)StatusOrder.OrderCollected)
            {
                result += ResponseMessage.OrderCollected + " "; 
            }
            if (_storageManager.GetStorageById((int)model.StorageId).Data.Name == null)
            {
                result += ResponseMessage.StorageNotFound + " ";
            }
            if(_userManager.SelectUserById(model.UserId).Data.Name == null)
            {
                result += ResponseMessage.CustomerNotFound + " ";
            }
            return result;
        }

        public string ValidationStorageById(int id)
        {
            var result = string.Empty;
            if (_storageManager.GetStorageById(id).Data.Name == null)
            {
                result += ResponseMessage.StorageNotFound + " ";
            }
            return result;
        }

        public string ValidationCustomerById(int id)
        {
            var result = string.Empty;
            if (_userManager.SelectUserById(id).Data.Name == null)
            {
                result += ResponseMessage.CustomerNotFound + " ";
            }
            return result;
        }
    }
}
