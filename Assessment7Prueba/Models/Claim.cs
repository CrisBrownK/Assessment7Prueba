using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Assessment7Prueba.Models;

public partial class Claim
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Date { get; set; }

    public int VehicleId { get; set; }

    [ValidateNever]
    public virtual Vehicle Vehicle { get; set; } = null!;
}
