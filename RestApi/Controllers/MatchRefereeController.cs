using LeagueAssist;
using RestApi.Models;
using RestApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class MatchRefereeController : ApiController
    {
        // GET: api/MatchReferee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MatchReferee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MatchReferee
        [HttpPost]
        public IHttpActionResult MatchReferee([FromBody]MatchReferee model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            /*
            var clas = new Class1();
            var response = clas.GetMatchesForReferee(int.Parse(model.Id), int.Parse(model.BrojUtakmica));
            var result = new MatchRefereeResponse();
            result.listResponse = response;
            */
            var matchProcessor = new MatchProcessor();
            var response = matchProcessor.RetrieveMatchesforReferee(int.Parse(model.Id), int.Parse(model.BrojUtakmica));
            var result = new MatchRefereeResponse();
            result.listResponse = response;


            return Ok(result);
        }

        // PUT: api/MatchReferee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MatchReferee/5
        public void Delete(int id)
        {
        }
    }
}
