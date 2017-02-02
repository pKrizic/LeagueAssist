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
    public class MatchDetailController : ApiController
    {
        // GET api/MatchDetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/MatchDetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/MatchDetail
        [HttpPost]
        public IHttpActionResult MatchDetail([FromBody]MatchDetailModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            /*
            var clas = new Class1();
            var Stadium = clas.GetMatchStadiumInfo(int.Parse(model.matchId));
            var MPActivity = clas.GetMatchActivityPlayers(int.Parse(model.matchId));
            var Players = clas.GetListOfPlayers(int.Parse(model.matchId));

            var result = new MatchDetailResponse();
            result.matchDetail = clas.GetMatchDetailInfo(Stadium, MPActivity, Players);
            */
            var matchProcessor = new MatchProcessor();
            var response = matchProcessor.RetrieveMatchDetails(int.Parse(model.matchId));
            var result = new MatchDetailResponse();
            result.matchDetail = response;

            return Ok(result);

        }

        // PUT api/MatchDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/MatchDetail/5
        public void Delete(int id)
        {
        }
    }
}