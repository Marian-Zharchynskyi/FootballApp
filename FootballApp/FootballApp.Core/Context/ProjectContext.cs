using FootballApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Core.Context
{
    public class ProjectContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<PlayerTransfer> PlayerTransfers { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Match to HomeTeam
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Match to AwayTeam
            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Player to Team
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transfer from Team
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.FromTeam)
                .WithMany(t => t.FromTransfers)
                .HasForeignKey(t => t.FromTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transfer to Team
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.ToTeam)
                .WithMany(t => t.ToTransfers)
                .HasForeignKey(t => t.ToTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // PlayerTransfer to FromTeam
            modelBuilder.Entity<PlayerTransfer>()
                .HasOne(pt => pt.FromTeam)
                .WithMany()
                .HasForeignKey(pt => pt.FromTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // PlayerTransfer to ToTeam
            modelBuilder.Entity<PlayerTransfer>()
                .HasOne(pt => pt.ToTeam)
                .WithMany()
                .HasForeignKey(pt => pt.ToTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
