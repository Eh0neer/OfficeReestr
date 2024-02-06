using System;
using System.Collections.Generic;

namespace OfficeReestr.OfficeReestrModel;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Position { get; set; }

    public DateOnly? HireDate { get; set; }

    public DateOnly? DateOfTermination { get; set; }

    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
}
