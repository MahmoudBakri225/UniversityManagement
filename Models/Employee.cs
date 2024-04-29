﻿using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public decimal? Salary { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? FacultyId { get; set; }

    public virtual Faculty? Faculty { get; set; }
}
