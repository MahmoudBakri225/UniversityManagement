using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class ProfessorDepartment
{
    public int ProfessorId { get; set; }

    public int DepartmentId { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Prof Professor { get; set; } = null!;
}
