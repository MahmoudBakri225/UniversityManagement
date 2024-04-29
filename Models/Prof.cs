using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Prof
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? OfficeNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<ProfessorDepartment> ProfessorDepartments { get; set; } = new List<ProfessorDepartment>();

    public virtual ICollection<ProfessorFaculty> ProfessorFaculties { get; set; } = new List<ProfessorFaculty>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
