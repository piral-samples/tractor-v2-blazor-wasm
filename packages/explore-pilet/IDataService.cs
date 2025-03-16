using System.Collections.Generic;

namespace Explore;

public interface IDataService
{
    IEnumerable<StoreDto> Stores { get; }

    IEnumerable<TeaserDto> Teasers { get; }

    IEnumerable<CategoryDto> Categories { get; }

    IEnumerable<RecommendationDto> GetRecommendations(IEnumerable<string> skus, int length = 4);

    CategoryDto GetCategory(string category);

    IEnumerable<ProductDto> GetAllProducts();
}
