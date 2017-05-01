namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.GreenkeeperinfoTimer")]
    public partial class GreenkeeperinfoTimer
    {
        [Key]
        [StringLength(40)]
        public string GreenkeeperName { get; set; }

        public int? TimerIalt { get; set; }
    }
}
