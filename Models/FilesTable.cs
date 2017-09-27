using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MVCValidationTest.Models
{
    [Table("FilesTable")]
    public partial class FilesTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(50)]
        public string ContentType { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] FileData { get; set; }
    }
}
