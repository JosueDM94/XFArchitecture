using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XFArchitecture.Core.Models
{
    public class Enrollment : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public double FinalScore { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Guid CourseUserId { get; set; }
        public CourseUser CourseUser { get; set; }
    }
}