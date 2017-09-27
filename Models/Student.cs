using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MVCValidationTest.Models
{
    public partial class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }

        [Required]
        [StringLength(70)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string EmailId { get; set; }

        public int? Age { get; set; }

        [StringLength(30)]
        public string Location { get; set; }

        public DateTime DoJ { get; set; }

        [Required]
        [StringLength(30)]
        public string Department { get; set; }
    }
}
