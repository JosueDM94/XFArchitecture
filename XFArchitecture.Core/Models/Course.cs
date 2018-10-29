using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XFArchitecture.Core.Models
{
    public class Course : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Schedule { get; set; }

        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }

        public virtual ICollection<CourseUser> CourseUsers { get; set; } = new List<CourseUser>();
    }
}