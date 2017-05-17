namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.SumTaskView")]
    public partial class SumTaskView
    {
        public int? TaskMinutesTotal { get; set; }

        [Key]
        [StringLength(40)]
        public string GreenTaskTitle { get; set; }
    }
}
