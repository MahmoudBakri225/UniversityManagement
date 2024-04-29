using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? FacultyId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Faculty? Faculty { get; set; }

    public virtual ICollection<ProfessorDepartment> ProfessorDepartments { get; set; } = new List<ProfessorDepartment>();

    public virtual ICollection<Prof> Profs { get; set; } = new List<Prof>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
