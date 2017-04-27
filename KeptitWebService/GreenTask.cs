namespace KeptitWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GreenGolf.GreenTasks")]
    public partial class GreenTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GreenTask()
        {
            FinishedTasks = new HashSet<FinishedTask>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GreenTaskID { get; set; }

        [Required]
        [StringLength(40)]
        public string GreenTaskTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedTask> FinishedTasks { get; set; }
    }
}
