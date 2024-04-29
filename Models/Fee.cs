using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Fee
{
    public int FeeId { get; set; }

    public string? FeeType { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Status { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
