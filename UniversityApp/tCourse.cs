namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tCourse")]
    public partial class tCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCourse()
        {
            tStudentCourse = new HashSet<tStudentCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }

        [StringLength(30)]
        public string courseName { get; set; }

        public int depID { get; set; }

        public int insID { get; set; }

        public virtual tDepartment tDepartment { get; set; }

        public virtual tInstructor tInstructor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tStudentCourse> tStudentCourse { get; set; }
    }
}
