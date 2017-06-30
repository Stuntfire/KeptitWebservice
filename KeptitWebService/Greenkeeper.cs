namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.Greenkeepers")]
    public partial class Greenkeeper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Greenkeeper()
        {
            FinishedTasks = new HashSet<FinishedTask>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GreenkeeperID { get; set; }

        [Required]
        [StringLength(40)]
        public string GreenkeeperName { get; set; }

        [Required]
        [StringLength(60)]
        public string GreenkeeperEmail { get; set; }

        [Required]
        [StringLength(100)]
        public string GreenkeeperPassword { get; set; }

        public bool? GreenkeeperAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedTask> FinishedTasks { get; set; }
    }
}
