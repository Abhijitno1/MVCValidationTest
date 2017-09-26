using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCValidationTest.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }
    }
}