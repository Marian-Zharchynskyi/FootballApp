using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballApp.Core.Entities
{
    public class Team : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;
        public string Coach { get; set; } = string.Empty;
        public DateTime Founded { get; set; } =  DateTime.Now;
        public string Stadium { get; set; } = string.Empty;
        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
        public virtual ICollection<Match> HomeMatches { get; set; } = new HashSet<Match>();
        public virtual ICollection<Match> AwayMatches { get; set; } = new HashSet<Match>();
        public virtual ICollection<Transfer> Transfers { get; set; } = new HashSet<Transfer>();
    }

}
