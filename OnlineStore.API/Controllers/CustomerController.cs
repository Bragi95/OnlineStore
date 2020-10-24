using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Models.Input;



namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {      
               
        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAllCustomer()
        {

            return Ok();
        }

        [HttpPost("Registration")]
        public ActionResult AddCustomer([FromBody] CustomerInpudModel model)
        {
            return Ok();
        }

        
        [HttpPut("Update")]
        public ActionResult UpdateCustomer([FromBody] CustomerInpudModel model)
        {
            return Ok();
        }

        
       
    }
}
