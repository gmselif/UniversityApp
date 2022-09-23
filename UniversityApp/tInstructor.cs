namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tInstructor")]
    public partial class tInstructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tInstructor()
        {
            tCourse = new HashSet<tCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int insID { get; set; }

        [StringLength(30)]
        public string insName { get; set; }

        [StringLength(30)]
        public string insLastname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCourse> tCourse { get; set; }
    }
}
