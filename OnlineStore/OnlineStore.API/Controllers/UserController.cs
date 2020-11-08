using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Manager;
using OnlineStore.Business.Models.Input;



namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var result = _userManager.SelectUserById(id);
            return Ok(result.Data);
        }

        [HttpGet]
        public ActionResult GetAllCustomer()
        {
            var result = _userManager.SelectUsers();
            return Ok(result.Data);
        }

        [HttpPost("Registration")]
        public ActionResult AddCustomer([FromBody] UserInpudModel model)
        {
           var result = _userManager.Merge(model);
            return Ok(result.Data);
        }

        
        [HttpPut("Update")]
        public ActionResult UpdateCustomer([FromBody] UserInpudModel model)
        {
            if (_userManager.SelectUserById(model.Id.Value).Data == null) return NotFound("Customer not found");
            var result = _userManager.Merge(model);
            return Ok(result.Data);
        }       
       
    }
}
