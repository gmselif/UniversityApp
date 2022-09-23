namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tDepartment")]
    public partial class tDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tDepartment()
        {
            tCourse = new HashSet<tCourse>();
            tStudent = new HashSet<tStudent>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int depID { get; set; }

        [StringLength(30)]
        public string depName { get; set; }

        public int facultyID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCourse> tCourse { get; set; }

        public virtual tFaculty tFaculty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tStudent> tStudent { get; set; }
    }
}
