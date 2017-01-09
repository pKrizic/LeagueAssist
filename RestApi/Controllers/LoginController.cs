using LeagueAssist;
using LeagueAssist.Entities;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IHttpActionResult Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clas = new Class1();
            var user = new User { Password = model.Password, Username = model.Username };
            var response = clas.CheckUsernameAndPassword(user);

            if (!String.IsNullOrEmpty(response))
            {
                var message = new
                {
                    result = "succes",
                    id = response
                };
                return Ok(message);
            }
            else
                ModelState.AddModelError("result", "Nemate prava za logiranje");
            return BadRequest(ModelState);
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
