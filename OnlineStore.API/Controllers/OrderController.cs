using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Models.Input;


namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        
        [HttpGet("{Id}")]
        public ActionResult GetOrderById(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetOrdersByCustomerId(int id)
        {
            return Ok();
        }


        [HttpGet("{Id}")]
        public ActionResult GetOrderByStorageId(int id)
        {
            return Ok();
        }
     

        [HttpPost("Create")]
        public ActionResult AddOrder([FromBody] OrderInputModel model)
        {
            return Ok();
        }



        [HttpPut("Update")]
        public ActionResult UpdateOrder([FromBody] OrderInputModel model)  // TODO проверять статус заказа при <Ожидайте доставки> вычесть товар из магазина,
        {                                                                  // <Отменен> вернуть товар в магазин
            return Ok();
        }
    }
}
