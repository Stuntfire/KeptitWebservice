namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.SumTaskDateView")]
    public partial class SumTaskDateView
    {
        public int? TaskMinutesTotal { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string GreenTaskTitle { get; set; }
    }
}
