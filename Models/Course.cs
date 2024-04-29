using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CourseCode { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public virtual ICollection<Prof> Professors { get; set; } = new List<Prof>();
}
