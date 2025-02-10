using System;
using System.Collections.Generic;

namespace CodeFirstDemoWithAnnotations.Models;

public partial class Customer
{
    public int Custid { get; set; }

    public string? FirstName { get; set; }

    public string? Lastname { get; set; }

    public string? City { get; set; }

    public string? Mobile { get; set; }
}
