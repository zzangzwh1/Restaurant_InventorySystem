using System;
using System.Collections.Generic;

namespace Restaurant_InventorySystem.Models;

public partial class Etc
{
    public int Id { get; set; }

    public int? JfcId { get; set; }

    public string? ProductName { get; set; }

    public double? Price { get; set; }

    public double? Weight { get; set; }

    public virtual Jfc? Jfc { get; set; }
}
