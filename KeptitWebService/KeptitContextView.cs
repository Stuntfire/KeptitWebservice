namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeptitContextView : DbContext
    {
        public KeptitContextView()
            : base("name=KeptitContextView2")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GreenkeeperInfo> GreenkeeperInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
