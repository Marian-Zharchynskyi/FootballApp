using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class PlayerTransfer : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual Team FromTeam { get; set; }
        [ForeignKey(nameof(FromTeam))]
        public Guid FromTeamId { get; set; }

        public virtual Team ToTeam { get; set; }
        [ForeignKey(nameof(ToTeam))]
        public Guid ToTeamId { get; set; }

        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
        public string ContractDuration { get; set; } = string.Empty;
    }
}
