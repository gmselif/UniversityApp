namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tFaculty")]
    public partial class tFaculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tFaculty()
        {
            tDepartment = new HashSet<tDepartment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int facultyID { get; set; }

        [StringLength(30)]
        public string facultyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDepartment> tDepartment { get; set; }
    }
}
