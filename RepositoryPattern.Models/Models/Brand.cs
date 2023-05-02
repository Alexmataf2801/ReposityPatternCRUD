using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;
}
