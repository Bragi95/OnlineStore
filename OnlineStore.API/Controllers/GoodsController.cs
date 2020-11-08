using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Serveces;
using OnlineStore.Business.Configurations;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;
using OnlineStore.Business.Models.Output;
using OnlineStore.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : Controller
    {
        private ValidationGoods _validationGoods;
        private IGoodsManager _goodsManager;
        DivisionGoodsByType _GoodsByType;
        public GoodsController(ValidationGoods validationGoods, IGoodsManager goodsManager, DivisionGoodsByType goodsByType)
        {
            _validationGoods = validationGoods;
            _goodsManager = goodsManager;
            _GoodsByType = goodsByType;
        }

        /// <summary>
        /// Returns the Goods by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get / Goods
        ///     {
        ///        "id": 1  
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">The selected product is returned</response>
        /// <response code="404">The product will not be found</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GoodsOutputModel>> GetGoodsById(int id)
        {
            var result = _goodsManager.SearchGoods(new SearchInputModel() { Id = id });           
            return MakeResponse(result);
        }


        [HttpGet]
        public ActionResult<List<GoodsOutputModel>> GetAllGoods()
        {
            var result = _goodsManager.SearchGoods(new SearchInputModel());
            return MakeResponse(result);
        }


        [HttpPost("Add")]
        public ActionResult AddGoods([FromBody] GoodsInputModel model)
        {
            string validationResult = _validationGoods.ValidateGoodsInputModel(model);
            if (!string.IsNullOrEmpty(validationResult))
            {
                return UnprocessableEntity(validationResult);
            }
            var result = _GoodsByType.Merge(model);
            return Ok(result);
        }


        [HttpPut("Update")]
        public ActionResult UpdateGoods([FromBody] GoodsInputModel model)
        {
            string validationResult = _validationGoods.ValidateGoodsInputModel(model);
            if (!string.IsNullOrEmpty(validationResult))
            {
                return UnprocessableEntity(validationResult);
            }
            var result = _GoodsByType.Merge(model);
            return Ok(result);
        }


        [HttpPost("Search")]
        public ActionResult<List<GoodsOutputModel>> SearchGoods([FromBody] SearchInputModel model)
        {
            var result = _GoodsByType.Search(model);            
            return Ok(result);
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
