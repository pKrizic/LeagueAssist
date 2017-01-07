using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class PersonMap: ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.firstName);
            Map(x => x.lastName);
            Map(x => x.birthDate);
            Map(x => x.Email);
            Map(x => x.Phone);
            References(x => x.Type);
            References(x => x.User);
        }
    }
}
