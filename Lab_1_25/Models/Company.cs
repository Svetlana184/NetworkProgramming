using System;
using System.Collections.Generic;

namespace Lab_1_25.Models;

public partial class Company
{
    public int IdCompany { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
