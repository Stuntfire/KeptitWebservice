namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.GreenkeeperInfo")]
    public partial class GreenkeeperInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinishedTasksID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GreenkeeperID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string GreenkeeperName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string AreaTitle { get; set; }

        //[Key]
        //[Column(Order = 4)]
        //[StringLength(40)]
        //public string SubAreaTitle { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(40)]
        public string GreenTaskTitle { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hours { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Minutes { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }
    }
}
