using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public int? PublicationYear { get; set; }

    public int? LibraryId { get; set; }

    public virtual Library? Library { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
