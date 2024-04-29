using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class StudentCourse
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public string? Degree { get; set; }

    public int? Year { get; set; }

    public string? Semester { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
