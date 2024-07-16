using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class Statistics : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual Player Player { get; set; }
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        public virtual Match Match { get; set; }
        [ForeignKey(nameof(Match))]
        public Guid MatchId { get; set; }

        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
