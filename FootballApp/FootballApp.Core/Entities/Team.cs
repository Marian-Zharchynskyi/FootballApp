using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballApp.Core.Entities
{
    public class Team : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public DateTime Founded { get; set; }
        public string Stadium { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
    }

}
