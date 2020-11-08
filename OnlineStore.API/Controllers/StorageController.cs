using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        IStorageManager _storageManager;

        public StorageController(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        [HttpGet("{id}")]
        public ActionResult<StorageOutputModel> GetStorageInfoById(int id)
        {
           var result = _storageManager.GetStorageById(id);
            return MakeResponse(result);
        }


        [HttpGet("{id}/quantity-goods")]
        public ActionResult<List<GoodsStorageOutputModel>> GetQuantityGoodsByStoragesId(int id)
        {
            var result = _storageManager.SelectQuantityGoodsByStorageid(id);
            return MakeResponse(result);
        }

        [HttpGet("quantity-all-goods")]
        public ActionResult<List<GoodsStorageOutputModel>> GetQuantityAllGoods()
        {
            var result = _storageManager.SelectAllQuantityGoods();
            return MakeResponse(result);
        }

        [HttpGet("country/{id}")]
        public ActionResult<List<StorageOutputModel>> GetStoragesByCountryId(int id)
        {

            var result = _storageManager.GetStorageByCountryId(id);
            return MakeResponse(result);
        }

        [HttpGet("city/{id}")]
        public ActionResult<List<StorageOutputModel>> GetStoragesByCityId(int id)
        {
            var result = _storageManager.GetStorageByCityId(id);
            return MakeResponse(result);
        }

        [HttpPost("add")]
        public ActionResult<StorageOutputModel> AddStorage([FromBody] StorageInputModel model)
        {
            var result = _storageManager.MergeStorage(model);
            return MakeResponse(result);
        }

        
        [HttpPut("update")]
        public ActionResult<StorageOutputModel> UpdateStorage([FromBody] StorageInputModel model)
        {
            var result = _storageManager.MergeStorage(model);

            return MakeResponse(result);
        }

        [HttpPost("Transfer")]
        public ActionResult<List<TransferGoodsOutputModel>> TransferbetweenStorage([FromBody] GoodsStorageTransferInputModel model)
        {
            var result = _storageManager.TransferGoodsBetweenStorages(model);
            
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
