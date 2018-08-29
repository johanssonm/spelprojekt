using Repositories;
using System.Web.Http;

namespace NetWebAdmin.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var repoService = new Ef6SqlRepository();

            var result = repoService.FindAll();

            return Json(new
            {
                success = true,
                Message = result
            });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
