using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Models.Input;



namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsStorageController : Controller
    {



        [HttpGet]
        public ActionResult GetAllQuantityGoods()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetQuantityGoodsByStorageId(int id)
        {
            return Ok();
        }

        
        [HttpPost("Add")]
        public ActionResult AddGoodsStorage([FromBody] GoodsStorageInputModel model)
        {
            return Ok();
        }

        
        [HttpPut("Update")]
        public ActionResult UpdateGoodsStorage([FromBody] GoodsStorageInputModel model)
        {
            return Ok();
        }

        [HttpPut("Transfer")]
        public ActionResult Transfer([FromBody] GoodsStorageTransferInputModel model)
        {
            return Ok();
        }
    }
}
