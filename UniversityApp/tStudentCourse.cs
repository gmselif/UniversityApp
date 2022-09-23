namespace UniversityApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tStudentCourse")]
    public partial class tStudentCourse
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int studentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseID { get; set; }

        [StringLength(15)]
        public string year { get; set; }

        [StringLength(15)]
        public string semester { get; set; }

        [StringLength(15)]
        public string midterm { get; set; }

        [StringLength(15)]
        public string final { get; set; }

        public virtual tCourse tCourse { get; set; }

        public virtual tStudent tStudent { get; set; }
    }
}
