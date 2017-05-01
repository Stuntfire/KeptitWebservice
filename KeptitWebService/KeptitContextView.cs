namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeptitContextView : DbContext
    {
        public KeptitContextView()
            : base("name=KeptitContextView")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GreenkeeperInfo> GreenkeeperInfoes { get; set; }
        public virtual DbSet<GreenkeeperinfoTimer> GreenkeeperinfoTimers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GreenkeeperInfo>()
                .Property(e => e.Notes)
                .IsUnicode(false);
        }
    }
}
