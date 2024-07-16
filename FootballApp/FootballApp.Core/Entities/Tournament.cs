using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Entities
{
    public class Tournament : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public virtual ICollection<Match> Matches { get; set; } = new HashSet<Match>();
        public string Sponsor { get; set; } = string.Empty;
    }
}
