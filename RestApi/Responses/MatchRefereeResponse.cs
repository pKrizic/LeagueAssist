using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Responses
{

    public class MatchRefereeResponse
    {
        public List<MatchReferees> listResponse { get; set; }
    }
}