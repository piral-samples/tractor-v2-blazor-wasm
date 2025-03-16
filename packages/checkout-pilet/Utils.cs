using System.Collections.Generic;
using System.Linq;

namespace Checkout;

public static class Utils
{
    public static string Src(string image, int size)
    {
        return image.Replace("[size]", $"{size}");
    }
    
    public static string SrcSet(string image, IEnumerable<int> sizes)
    {
        return string.Join(", ", sizes.Select(size => $"{Src(image, size)} {size}w"));
    }
}
