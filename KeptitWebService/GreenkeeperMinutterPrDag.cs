namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.GreenkeeperMinutterPrDag")]
    public partial class GreenkeeperMinutterPrDag
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string GreenkeeperName { get; set; }

        public int? Minutterialt { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
