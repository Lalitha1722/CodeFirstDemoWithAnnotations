using System;
using System.Collections.Generic;

namespace CodeFirstDemoWithAnnotations.Models;

public partial class VwPassengerDatum
{
    public int SeatNo { get; set; }

    public string? SeatType { get; set; }

    public int? FlightNo { get; set; }

    public string? SourcePoint { get; set; }

    public string? Destination { get; set; }
}
