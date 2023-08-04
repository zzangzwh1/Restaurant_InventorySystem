using System;
using System.Collections.Generic;

namespace Restaurant_InventorySystem.Models;

public partial class Jfc
{
    public int Id { get; set; }

    public int? SyscoId { get; set; }

    public string? ProductName { get; set; }

    public double? Price { get; set; }

    public double? Weight { get; set; }

    public virtual ICollection<Etc> Etcs { get; set; } = new List<Etc>();

    public virtual Sysco? Sysco { get; set; }
}
