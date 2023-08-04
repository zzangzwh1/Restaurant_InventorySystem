using System;
using System.Collections.Generic;

namespace Restaurant_InventorySystem.Models;

public partial class Gf
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public double? Price { get; set; }

    public double? Weight { get; set; }

    public virtual ICollection<Sysco> Syscos { get; set; } = new List<Sysco>();
}
