namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.SumAreaView")]
    public partial class SumAreaView
    {
        public int? AreaMinutterIalt { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string AreaTitle { get; set; }
    }
}
