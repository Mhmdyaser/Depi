using System;
using System.Collections.Generic;

namespace EF.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gendor { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int CountryId { get; set; }

    public int DepartmentId { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime? ExitDate { get; set; }

    public decimal MonthlySalary { get; set; }

    public double BonusPerc { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
