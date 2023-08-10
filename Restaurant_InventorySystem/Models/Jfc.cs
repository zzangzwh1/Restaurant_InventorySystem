using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_InventorySystem.Models;

public partial class Jfc
{
    public int Id { get; set; }

    public int? SyscoId { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    public string? ProductName { get; set; }
    [Required(ErrorMessage = "Price is required.")]
    public double? Price { get; set; }

    [Required(ErrorMessage = "Weight Name is required.")]
    public double? Weight { get; set; }

    public virtual ICollection<Etc> Etcs { get; set; } = new List<Etc>();

    public virtual Sysco? Sysco { get; set; }
}
