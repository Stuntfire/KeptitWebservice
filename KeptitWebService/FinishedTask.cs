namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.FinishedTasks")]
    public partial class FinishedTask
    {
        [Key]
        public int FinishedTasksID { get; set; }

        public int AreaID { get; set; }

        public int? GreenTaskID { get; set; }

        //public int SubAreaID { get; set; }

        public int GreenkeeperID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual Area Area { get; set; }

        public virtual Greenkeeper Greenkeeper { get; set; }

        public virtual GreenTask GreenTask { get; set; }

        //public virtual SubArea SubArea { get; set; }
    }
}
