using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class Transfer : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public virtual Player Player { get; set; }
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }
        public Team FromTeam { get; set; }
        [ForeignKey(nameof(FromTeam))]
        public Guid FromTeamId { get; set; }

        public Team ToTeam { get; set; }
        [ForeignKey(nameof(ToTeam))]
        public Guid ToTeamId { get; set; }

        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
    }
}
