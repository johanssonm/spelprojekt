using Infrastructure.cs.Contracts;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Spelprojekt.Services;

namespace Webadmin.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult JsonFeed()
        {

            var repoService = new SqlRepository();

            var result = repoService.FindAll();

            return Json(new
            {
                success = true,
                Message = result
            });
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var dbservice = new SqlRepository();


            var result = dbservice.FindOne(id);

            return Json(new
            {
                success = true,
                Message = result
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
