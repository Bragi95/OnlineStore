using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Models.Input;



namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : Controller
    {
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
        public ActionResult GetGoodsById(int id)
        {
            return Ok();
        }

        
        [HttpGet]
        public ActionResult GetAllGoods()
        {
            return Ok();
        }

        
        [HttpPost("Add")]
        public ActionResult AddGoods([FromBody] GoodsInputModel model)
        {
            return Ok();
        }

        
        [HttpPut("Update")]
        public ActionResult UpdateGoods([FromBody] GoodsInputModel model)
        {
            return Ok();
        }

        
        [HttpPost("Search")]
        public ActionResult SearchGoods([FromBody] SearchInputModel model)
        {
            return Ok();
        }
    }
}
