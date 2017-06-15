namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeptitContext : DbContext
    {
        public KeptitContext()
            : base("name=KeptitContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<FinishedTask> FinishedTasks { get; set; }
        public virtual DbSet<Greenkeeper> Greenkeepers { get; set; }
        public virtual DbSet<GreenTask> GreenTasks { get; set; }
        //public virtual DbSet<SubArea> SubAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasMany(e => e.FinishedTasks)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinishedTask>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Greenkeeper>()
                .HasMany(e => e.FinishedTasks)
                .WithRequired(e => e.Greenkeeper)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<SubArea>()
            //    .HasMany(e => e.FinishedTasks)
            //    .WithRequired(e => e.SubArea)
            //    .WillCascadeOnDelete(false);
        }
    }
}
