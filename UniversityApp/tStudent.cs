namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tStudent")]
    public partial class tStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tStudent()
        {
            tStudentCourse = new HashSet<tStudentCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int studentID { get; set; }

        [StringLength(30)]
        public string studentFname { get; set; }

        [StringLength(30)]
        public string studentLname { get; set; }

        public int depID { get; set; }

        public virtual tDepartment tDepartment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tStudentCourse> tStudentCourse { get; set; }
    }
}
