using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Serveces;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        IOrderManager _orderManager;
        ValidationOrder _validationOrder;
        public OrderController(IOrderManager orderManager, ValidationOrder validationOrder)
        {
            _orderManager = orderManager;
            _validationOrder = validationOrder;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrdersById(int id)
        {
            var result = _orderManager.GetOrderById(id);
            return MakeResponse(result);
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<OrderOutputModel>> GetOrdersByCustomerId(int id)
        {
            var res = _validationOrder.ValidationCustomerById(id);
            if (res != string.Empty) return UnprocessableEntity(res);

            var result = _orderManager.GetOrderByUserId(id);
            return MakeResponse(result);
        }

        [HttpGet("Storage/{id}")]
        public ActionResult<List<OrderOutputModel>> GetOrderByStorageId(int id)
        {
            var res = _validationOrder.ValidationStorageById(id);
            if (res != string.Empty) return UnprocessableEntity(res);

            var result = _orderManager.GetOrderByStorageId(id);
            return MakeResponse(result);
        }       
     

        [HttpPost("Create")]
        public ActionResult<OrderOutputModel> AddOrder([FromBody] OrderInputModel model)
        {
            var res = _validationOrder.ValidationAddOrder(model);
            if (res != string.Empty) return UnprocessableEntity(res);

            var result = _orderManager.MergeOrder(model);

            return MakeResponse(result);
        }



        [HttpPut("Update")]
        public ActionResult<OrderOutputModel> UpdateOrder([FromBody] OrderInputModel model)  
        {
            var res = _validationOrder.ValidationUpdateOrder(model);
            if (res != string.Empty) return UnprocessableEntity(res);

            var result = _orderManager.MergeOrder(model);          
            
            return MakeResponse(result);
        }

        [HttpPut("{id}/Update-status/{statusId}")]
        public ActionResult<OrderOutputModel> UpdateSatusOrder(int id, int statusId)
        {
            var result = _orderManager.UpdateStatusOrderByOrderId(id, statusId);

            return MakeResponse(result);
        }

        private ActionResult<T> MakeResponse<T>(DataWrapper<T> operationResult)
        {
            if (operationResult.IsOk)
            {
                if (operationResult.Data == null)
                {
                    return NotFound();
                }
                return Ok(operationResult.Data);
            }
            return Problem(detail: operationResult.ExceptionMessage, statusCode: 520);
        }
    }
}
