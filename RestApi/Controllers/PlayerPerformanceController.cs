using LeagueAssist;
using RestApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class PlayerPerformanceController : ApiController
    {
        // GET: api/PlayerPerformance
        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var clas = new Class1();
            var matchProcessor = new MatchProcessor();
            var response = matchProcessor.GetPlayerPerformance();
            var message = new PlayerPerformanceResponse();
            if (response.Count > 0 && response != null)
            {
                message.listResponse = response;
                return Ok(message);
            }
            else
            {
                return Ok(message);
            }
        }

        // GET: api/PlayerPerformance/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PlayerPerformance
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlayerPerformance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PlayerPerformance/5
        public void Delete(int id)
        {
        }
    }
}
