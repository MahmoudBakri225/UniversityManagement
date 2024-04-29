using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class ProfessorFaculty
{
    public int ProfessorId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int FacultyId { get; set; }

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual Prof Professor { get; set; } = null!;
}
