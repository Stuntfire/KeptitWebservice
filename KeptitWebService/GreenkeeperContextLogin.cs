namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GreenkeeperContextLogin : DbContext
    {
        public GreenkeeperContextLogin()
            : base("name=GreenkeeperContextAdmin")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<FinishedTask> FinishedTasks { get; set; }
        public virtual DbSet<Greenkeeper> Greenkeepers { get; set; }
        public virtual DbSet<GreenTask> GreenTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasMany(e => e.FinishedTasks)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Greenkeeper>()
                .HasMany(e => e.FinishedTasks)
                .WithRequired(e => e.Greenkeeper)
                .WillCascadeOnDelete(false);
        }
    }
}
