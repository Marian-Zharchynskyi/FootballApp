using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class Player : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Position { get; set; } = string.Empty;

        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Team))]
        public Guid TeamId { get; set; }

        public virtual ICollection<Statistics> Statistics { get; set; } = new HashSet<Statistics>();
        public decimal MarketValue { get; set; }
    }
}
