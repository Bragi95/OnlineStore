using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;


namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : Controller
    {
        IFeedBackManager _feedBackManager;
        IStorageManager _storageManager;
        IGoodsManager _goodsManager;
        IUserManager _userManager;

        public FeedBackController(IFeedBackManager feedBackManager, IUserManager userManager, IGoodsManager goodsManager, IStorageManager storageManager)
        {
            _feedBackManager = feedBackManager;
            _userManager = userManager;
            _goodsManager = goodsManager;
            _storageManager = storageManager;
        }


        [HttpGet("{id}")]
        public ActionResult<FeedBackOutputModel> GetFeedBackById(int id)
        {
            var result = _feedBackManager.SelectFeedBackById(id);
            return MakeResponse(result);
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<FeedBackOutputModel>> GetFeedBackByCustomerId(int id)
        {
            if (_userManager.SelectUserById(id).Data.Name == null) return NotFound("Customer not found");
            var result = _feedBackManager.SelectFeedBackByUserId(id);
            return MakeResponse(result);
        }

        [HttpGet("storage/{id}")]
        public ActionResult<List<FeedBackOutputModel>> GetFeedBackByStorageId(int id)
        {
            if (_storageManager.GetStorageById(id).Data.Name == null) return NotFound("Storage not found");

            var result = _feedBackManager.SelectFeedBackByStorageId(id);
            return MakeResponse(result);
        }

        [HttpGet("goods/{id}")]
        public ActionResult<List<FeedBackOutputModel>> GetFeedBackByGoodsId(int id)
        {
            if (_goodsManager.SearchGoods(new SearchInputModel() { Id = id }).Data.Count == 0) return NotFound("Goods not found");

            var result = _feedBackManager.SelectFeedBackByGoodsId(id);
            return MakeResponse(result);
        }


        [HttpPost("add")]
        public ActionResult<FeedBackOutputModel> AddFeedBack([FromBody] FeedBackInputModel model)
        {
            if (_goodsManager.SearchGoods(new SearchInputModel() { Id = model.GoodsId }).Data.Count == 0) return NotFound("Goods not found");
            if (_storageManager.GetStorageById(model.StorageId).Data.Name == null) return NotFound("Storage not found");
            if (model.Message == null) return BadRequest("You for got to leave message");

            var result = _feedBackManager.FeedBackMerge(model);
            return MakeResponse(result);
        }


        [HttpPut("update")]
        public ActionResult<FeedBackOutputModel> UpdateFeedback([FromBody] FeedBackInputModel model)
        {
            if (model.Message == null) return BadRequest("You for got to leave message");
            if (_feedBackManager.SelectFeedBackById((int)model.Id).Data.Message == null) return NotFound("FeedBack not found");
            if (_storageManager.GetStorageById(model.StorageId).Data.Name == null) return NotFound("Storage not found");
            if (_goodsManager.SearchGoods(new SearchInputModel() { Id = model.GoodsId }).Data.Count == 0) return NotFound("Goods not found");

            var result = _feedBackManager.FeedBackMerge(model);
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
