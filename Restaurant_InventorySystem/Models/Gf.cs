using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_InventorySystem.Models;

public partial class Gf
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    public string? ProductName { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    public double? Price { get; set; }

    [Required(ErrorMessage = "Weight  is required.")]
    public double? Weight { get; set; }

    public virtual ICollection<Sysco> Syscos { get; set; } = new List<Sysco>();
}
