using System;
using System.Collections.Generic;

namespace UniversityManagement.Models;

public partial class Library
{
    public int Id { get; set; }

    public int? NoOfBooks { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
