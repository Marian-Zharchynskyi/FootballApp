using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp.Core.Entities
{
    public class Transfer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid FromTeamId { get; set; }
        public Team FromTeam { get; set; }
        public Guid ToTeamId { get; set; }
        public Team ToTeam { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
    }
}
