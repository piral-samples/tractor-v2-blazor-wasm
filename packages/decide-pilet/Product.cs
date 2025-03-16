using System.Collections.Generic;

namespace Decide;

public class Product
{
    public string Name { get; set; }

    public string Id { get; set; }

    public string Category { get; set; }

    public List<string> Highlights { get; set; }
    
    public List<Variant> Variants { get; set; }
}