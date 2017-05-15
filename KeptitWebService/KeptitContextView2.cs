namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeptitContextView2 : DbContext
    {
        public KeptitContextView2()
            : base("name=KeptitContextView3")
        {
        }

        public virtual DbSet<GreenkeeperMinutterPrDag> GreenkeeperMinutterPrDags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
