using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_1_25.Models;

public partial class Company
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCompany { get; set; }

    public string Name { get; set; } = null!;
    public int IdCountry { get;set; }
}
