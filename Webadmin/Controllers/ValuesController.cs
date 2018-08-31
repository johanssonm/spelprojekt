using Microsoft.AspNetCore.Mvc;
using Repositories;
using Spelprojekt.Entities;

namespace Webadmin.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult JsonFeed()
        {
            var repoService = new EfCoreSqlRepository();

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
            var dbservice = new EfCoreSqlRepository();


            var result = dbservice.FindOne(id);

            return Json(new
            {
                success = true,
                Message = result
            });
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Player player)
        {
            var dbservice = new EfCoreSqlRepository();


            dbservice.Save(player);

            return Ok("Player was saved.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Player player)
        {
            var dbservice = new EfCoreSqlRepository();

            dbservice.Update(player);

            return Ok("Player was updated.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var dbservice = new EfCoreSqlRepository();

            dbservice.Delete(id);

            return Ok("Player was deleted.");
        }
    }
}
