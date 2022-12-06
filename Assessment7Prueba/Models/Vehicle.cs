using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Assessment7Prueba.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Vin { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Year { get; set; } = null!;

    public int OwnerId { get; set; }

    public virtual ICollection<Claim> Claims { get; } = new List<Claim>();

    [ValidateNever]
    public virtual Owner Owner { get; set; } = null!;
}
