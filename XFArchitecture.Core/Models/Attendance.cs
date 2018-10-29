using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XFArchitecture.Core.Models
{
    public class Attendance : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool Attended { get; set; }

        public Guid EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}