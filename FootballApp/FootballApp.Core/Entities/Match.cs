using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class Match : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Date { get; set; } = DateTime.Now;

        public virtual Team HomeTeam { get; set; }
        [ForeignKey(nameof(HomeTeam))]
        public Guid HomeTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }
        [ForeignKey(nameof(AwayTeam))]
        public Guid AwayTeamId { get; set; }

        public virtual Tournament Tournament { get; set; }
        [ForeignKey(nameof(Tournament))]
        public Guid TournamentId { get; set; }

        public virtual ICollection<Statistics> Statistics { get; set; } = new HashSet<Statistics>();

        public string Location { get; set; } = string.Empty;
    }
}
