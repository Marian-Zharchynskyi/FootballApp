using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp.Core.Entities
{

    public class Player : IEntity<Guid>
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Statistics> Statistics { get; set; }
        public decimal MarketValue { get; set; }
    }
}
