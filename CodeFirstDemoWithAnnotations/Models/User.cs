using System;
using System.Collections.Generic;

namespace CodeFirstDemoWithAnnotations.Models;

public partial class User
{
    public string Userid { get; set; } = null!;

    public string? Password { get; set; }
}
