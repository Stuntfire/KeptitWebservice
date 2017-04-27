namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.SubAreas")]
    public partial class SubArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubArea()
        {
            FinishedTasks = new HashSet<FinishedTask>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubAreaID { get; set; }

        [Required]
        [StringLength(40)]
        public string SubAreaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedTask> FinishedTasks { get; set; }
    }
}
