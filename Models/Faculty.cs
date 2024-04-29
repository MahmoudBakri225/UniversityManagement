using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? LibraryId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Library? Library { get; set; }

    public virtual ICollection<ProfessorFaculty> ProfessorFaculties { get; set; } = new List<ProfessorFaculty>();
}
