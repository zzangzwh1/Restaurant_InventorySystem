using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_InventorySystem.Models;

public partial class Sysco
{
    public int Id { get; set; }

    public int? GfsId { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    public string? ProductName { get; set; }
    [Required(ErrorMessage = "Product Name is required.")]
    public double? Price { get; set; }
    [Required(ErrorMessage = "Product Name is required.")]
    public double? Weight { get; set; }

    public virtual Gf? Gfs { get; set; }

    public virtual ICollection<Jfc> Jfcs { get; set; } = new List<Jfc>();
}
