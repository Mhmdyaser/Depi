using System;
using System.Collections.Generic;

namespace EF.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CurrentHeadcount { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
