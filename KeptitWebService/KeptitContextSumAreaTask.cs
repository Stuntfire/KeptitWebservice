namespace KeptitWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeptitContextSumAreaTask : DbContext
    {
        public KeptitContextSumAreaTask()
            : base("name=KeptitContextSumAreaTask")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<SumAreaView> SumAreaViews { get; set; }
        public virtual DbSet<SumTaskDateView> SumTaskDateViews { get; set; }
        public virtual DbSet<SumTaskView> SumTaskViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
