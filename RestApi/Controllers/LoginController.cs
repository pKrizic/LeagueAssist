using LeagueAssist;
using LeagueAssist.Entities;
using RestApi.Models;
using RestApi.Responses;
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
                return BadRequest(ModelState);
            var clas = new DataProcessor();
            var response = clas.ProccesData(model.Username, model.Password, 1);
            var message = new LoginResponse();
            if (!String.IsNullOrEmpty(response))
            {
                message.id = response;
                message.result = "succes";
                return Ok(message);
            }
            else
            {
                message.result = "failed";
                message.errorMessage = "Nemate prava ulogirati se u sustav";
                return Ok(message);
            }
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
