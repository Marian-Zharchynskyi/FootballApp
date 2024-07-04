using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp.Core.Entities
{
    public class Match : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<Statistics> Statistics { get; set; }
        public string Location { get; set; }
    }
}
