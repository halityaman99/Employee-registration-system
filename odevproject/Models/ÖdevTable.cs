using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odevproject.Models;

public partial class ÖdevTable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public required string KullaniciAdi { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public required string KullaniciSoyadi { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public required string TelefonNumarasi { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public required string Mail { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public required string Yetki { get; set; }

    [Required(ErrorMessage = "Zorunlu Alan")]
    public string? Yas { get; set; }

    public int? IlId { get; set; }
    public int? IlceId { get; set; }

    [ForeignKey("IlId")]
    public virtual Il? Il { get; set; }

    [ForeignKey("IlceId")]
    public virtual Ilce? Ilce { get; set; }
}
