using LeagueAssist;
using LeagueAssist.Entities;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class MatchDataInsertController : ApiController
    {
        // GET api/MatchDataInsert
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/MatchDataInsert/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/MatchDataInsert
        [HttpPost]
        public IHttpActionResult MatchDataInsert([FromBody]MatchDataInsertModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clas = new Class1();
            clas.UpdateMatch(int.Parse(model.Id), int.Parse(model.HomeGoals), int.Parse(model.AwayGoals), model.Description, model.MatchActions);
            return Ok();
        }

        // PUT api/MatchDataInsert/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/MatchDataInsert/5
        public void Delete(int id)
        {
        }
    }
}