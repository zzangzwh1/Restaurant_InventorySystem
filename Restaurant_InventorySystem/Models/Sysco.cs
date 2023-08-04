using System;
using System.Collections.Generic;

namespace Restaurant_InventorySystem.Models;

public partial class Sysco
{
    public int Id { get; set; }

    public int? GfsId { get; set; }

    public string? ProductName { get; set; }

    public double? Price { get; set; }

    public double? Weight { get; set; }

    public virtual Gf? Gfs { get; set; }

    public virtual ICollection<Jfc> Jfcs { get; set; } = new List<Jfc>();
}
