using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XFArchitecture.Core.Models
{
    public class CourseUser : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
