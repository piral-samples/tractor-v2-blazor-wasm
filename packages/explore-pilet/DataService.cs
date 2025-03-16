using System;
using System.Collections.Generic;
using System.Linq;

namespace Explore;

public class DataService : IDataService
{
    private static readonly List<TeaserDto> _teasers =
    [
        new TeaserDto
        {
            Title = "Classic Tractors",
            Image = "https://blueprint.the-tractor.store/cdn/img/scene/[size]/classics.webp",
            Url = "/products/classic"
        },
        new TeaserDto
        {
            Title = "Autonomous Tractors",
            Image = "https://blueprint.the-tractor.store/cdn/img/scene/[size]/autonomous.webp",
            Url = "/products/autonomous"
        }
    ];
    private static readonly List<StoreDto> _stores =
    [
        new StoreDto
        {
            Id = "store-a",
            Name = "Aurora Flagship Store",
            Street = "Astronaut Way 1",
            City = "Arlington",
            Image = "https://blueprint.the-tractor.store/cdn/img/store/[size]/store-1.webp"
        },
        new StoreDto
        {
            Id = "store-b",
            Name = "Big Micro Machines",
            Street = "Broadway 2",
            City = "Burlington",
            Image = "https://blueprint.the-tractor.store/cdn/img/store/[size]/store-2.webp"
        },
        new StoreDto
        {
            Id = "store-c",
            Name = "Central Mall",
            Street = "Clown Street 3",
            City = "Cryo",
            Image = "https://blueprint.the-tractor.store/cdn/img/store/[size]/store-3.webp"
        },
        new StoreDto
        {
            Id = "store-d",
            Name = "Downtown Model Store",
            Street = "Duck Street 4",
            City = "Davenport",
            Image = "https://blueprint.the-tractor.store/cdn/img/store/[size]/store-4.webp"
        }
    ];
    private static readonly List<CategoryDto> _categories =
    [
        new CategoryDto
        {
            Key = "classic",
            Name = "Classics",
            Products = new List<ProductDto>
            {
                new ProductDto { Name = "Heritage Workhorse", Id = "CL-01", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GR.webp", StartPrice = 5700, Url = "/product/CL-01" },
                new ProductDto { Name = "Falcon Crest Farm", Id = "CL-02", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-02-BL.webp", StartPrice = 2600, Url = "/product/CL-02" },
                new ProductDto { Name = "Falcon Crest Work", Id = "CL-03", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-GR.webp", StartPrice = 2300, Url = "/product/CL-03" },
                new ProductDto { Name = "Broadfield Majestic", Id = "CL-04", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-BL.webp", StartPrice = 2200, Url = "/product/CL-04" },
                new ProductDto { Name = "Countryside Commander", Id = "CL-05", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-PT.webp", StartPrice = 2700, Url = "/product/CL-05" },
                new ProductDto { Name = "Danamark Steadfast", Id = "CL-06", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-MT.webp", StartPrice = 2800, Url = "/product/CL-06" },
                new ProductDto { Name = "Greenland Rover", Id = "CL-07", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-GR.webp", StartPrice = 2900, Url = "/product/CL-07" },
                new ProductDto { Name = "Holland Hamster", Id = "CL-08", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-GR.webp", StartPrice = 7750, Url = "/product/CL-08" },
                new ProductDto { Name = "TerraFirma Veneto", Id = "CL-09", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-BL.webp", StartPrice = 2950, Url = "/product/CL-09" },
                new ProductDto { Name = "Global Gallant", Id = "CL-10", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-SD.webp", StartPrice = 2600, Url = "/product/CL-10" },
                new ProductDto { Name = "Scandinavia Sower", Id = "CL-11", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-SK.webp", StartPrice = 3100, Url = "/product/CL-11" },
                new ProductDto { Name = "Celerity Cruiser", Id = "CL-12", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-BL.webp", StartPrice = 3200, Url = "/product/CL-12" },
                new ProductDto { Name = "Rapid Racer", Id = "CL-13", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-BL.webp", StartPrice = 7500, Url = "/product/CL-13" },
                new ProductDto { Name = "Caribbean Cruiser", Id = "CL-14", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-GR.webp", StartPrice = 2300, Url = "/product/CL-14" },
                new ProductDto { Name = "Fieldmaster Classic", Id = "CL-15", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-PI.webp", StartPrice = 6200, Url = "/product/CL-15" }
            }
        },
        new CategoryDto
        {
            Key = "autonomous",
            Name = "Autonomous",
            Products = new List<ProductDto>
            {
                new ProductDto { Name = "TerraFirma AutoCultivator T-300", Id = "AU-01", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp", StartPrice = 1000, Url = "/product/AU-01" },
                new ProductDto { Name = "SmartFarm Titan", Id = "AU-02", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-OG.webp", StartPrice = 4000, Url = "/product/AU-02" },
                new ProductDto { Name = "FutureHarvest Navigator", Id = "AU-03", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-TQ.webp", StartPrice = 1600, Url = "/product/AU-03" },
                new ProductDto { Name = "Sapphire Sunworker 460R", Id = "AU-04", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-RD.webp", StartPrice = 8500, Url = "/product/AU-04" },
                new ProductDto { Name = "EcoGrow Crop Commander", Id = "AU-05", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-05-ZH.webp", StartPrice = 3400, Url = "/product/AU-05" },
                new ProductDto { Name = "FarmFleet Sovereign", Id = "AU-06", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-CZ.webp", StartPrice = 2100, Url = "/product/AU-06" },
                new ProductDto { Name = "Verde Voyager", Id = "AU-07", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-MT.webp", StartPrice = 4000, Url = "/product/AU-07" },
                new ProductDto { Name = "Field Pioneer", Id = "AU-08", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-08-WH.webp", StartPrice = 4500, Url = "/product/AU-08" }
            }
        }
    ];

    private static readonly List<RecommendationDto> _recommendations =
    [
        new RecommendationDto { Name = "TerraFirma AutoCultivator T-300 Silver", Sku = "AU-01-SI", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp", Url = "/product/AU-01?sku=AU-01-SI", Rgb = new Color { Red = 192, Blue = 192, Green = 192 } },
    ];

    public IEnumerable<StoreDto> Stores => _stores;
    
    public IEnumerable<TeaserDto> Teasers => _teasers;
    
    public IEnumerable<CategoryDto> Categories => _categories;

    public IEnumerable<ProductDto> GetAllProducts()
    {
        return _categories.SelectMany(m => m.Products);
    }

    public CategoryDto GetCategory(string category)
    {
        return _categories.FirstOrDefault(m => m.Key == category);
    }

    private static Color GetAverageColor(IEnumerable<Color> colors)
    {
        var red = colors.Sum(c => c.Red);
        var blue = colors.Sum(c => c.Blue);
        var green = colors.Sum(c => c.Green);
        var len = colors.Count();
        return new Color
        {
            Red = red / len,
            Blue = blue / len,
            Green = green / len,
        };
    }

    private static IEnumerable<Color> GetColors(IEnumerable<string> skus)
    {
        return _recommendations
          .Where(m => skus.Contains(m.Sku))
          .Select(m => m.Rgb);
    }

    private static double ColorDistance(Color rgb1, Color rgb2)
    {
        return Math.Sqrt(Math.Pow(rgb1.Red - rgb2.Red, 2) + Math.Pow(rgb1.Blue - rgb2.Blue, 2) + Math.Pow(rgb1.Green - rgb2.Green, 2));
    }

    public IEnumerable<RecommendationDto> GetRecommendations(IEnumerable<string> skus, int length = 4)
    {
        var targetRgb =  GetAverageColor(GetColors(skus));
        return _recommendations
          .Where(m => !skus.Contains(m.Sku))
          .OrderByDescending(m => ColorDistance(m.Rgb, targetRgb))
          .Take(length);
    }
}
