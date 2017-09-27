using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MVCValidationTest.Models
{
    public partial class SampleDBContext : DbContext
    {
        public SampleDBContext()
            : base("name=SampleDBContext")
        {
        }

        public virtual DbSet<FilesTable> FilesTables { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilesTable>()
                .Property(e => e.ContentType)
                .IsUnicode(false);
        }
    }
}
