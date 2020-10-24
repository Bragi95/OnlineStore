using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Models.Input;



namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        
        [HttpGet("{id}")]
        public ActionResult GetStorageInfoById(int id)
        {
            return Ok();
        }

        
        [HttpGet("{id}")]
        public ActionResult GetAllStoragesInfo()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetStoragesByCountryId(int id)
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetStoragesByCityId(int id)
        {

            return Ok();
        }

        [HttpPost]
        public ActionResult AddStorage([FromBody] StorageInputModel model)
        {
            return Ok();
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateStorage([FromBody] StorageInputModel model)
        {
            return Ok();
        }


    }
}
