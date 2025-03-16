using System.Collections.Generic;

namespace Explore;

public class CategoryDto
{
    public string Key { get; set; }

    public string Name { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

}
