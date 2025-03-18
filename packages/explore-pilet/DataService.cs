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
        new RecommendationDto {
            Name = "TerraFirma AutoCultivator T-300 Silver",
            Sku = "AU-01-SI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp",
            Url = "/product/AU-01?sku=AU-01-SI",
            Rgb = new Color {
                Red = 192,
                Blue = 192,
                Green = 192
            }
        },
        new RecommendationDto {
            Name = "TerraFirma AutoCultivator T-300 Silver",
            Sku = "AU-01-SI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp",
            Url = "/product/AU-01?sku=AU-01-SI",
            Rgb = new Color {
                Red = 192,
                Green = 192,
                Blue = 192
            }
        },
        new RecommendationDto {
            Name = "SmartFarm Titan Sunset Copper",
            Sku = "AU-02-OG",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-OG.webp",
            Url = "/product/AU-02?sku=AU-02-OG",
            Rgb = new Color {
                Red = 221,
                Green = 82,
                Blue = 25
            }
        },
        new RecommendationDto {
            Name = "SmartFarm Titan Cosmic Sapphire",
            Sku = "AU-02-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-BL.webp",
            Url = "/product/AU-02?sku=AU-02-BL",
            Rgb = new Color {
                Red = 42,
                Green = 82,
                Blue = 190
            }
        },
        new RecommendationDto {
            Name = "SmartFarm Titan Verdant Shadow",
            Sku = "AU-02-GG",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-GG.webp",
            Url = "/product/AU-02?sku=AU-02-GG",
            Rgb = new Color {
                Red = 0,
                Green = 90,
                Blue = 4
            }
        },
        new RecommendationDto {
            Name = "FutureHarvest Navigator Turquoise Titan",
            Sku = "AU-03-TQ",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-TQ.webp",
            Url = "/product/AU-03?sku=AU-03-TQ",
            Rgb = new Color {
                Red = 22,
                Green = 159,
                Blue = 184
            }
        },
        new RecommendationDto {
            Name = "FutureHarvest Navigator Majestic Violet",
            Sku = "AU-03-PL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-PL.webp",
            Url = "/product/AU-03?sku=AU-03-PL",
            Rgb = new Color {
                Red = 155,
                Green = 95,
                Blue = 192
            }
        },
        new RecommendationDto {
            Name = "FutureHarvest Navigator Scarlet Dynamo",
            Sku = "AU-03-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-RD.webp",
            Url = "/product/AU-03?sku=AU-03-RD",
            Rgb = new Color {
                Red = 255,
                Green = 36,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "FutureHarvest Navigator Sunbeam Yellow",
            Sku = "AU-03-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-YE.webp",
            Url = "/product/AU-03?sku=AU-03-YE",
            Rgb = new Color {
                Red = 250,
                Green = 173,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Sapphire Sunworker 460R Ruby Red",
            Sku = "AU-04-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-RD.webp",
            Url = "/product/AU-04?sku=AU-04-RD",
            Rgb = new Color {
                Red = 155,
                Green = 17,
                Blue = 30
            }
        },
        new RecommendationDto {
            Name = "Sapphire Sunworker 460R Midnight Onyx",
            Sku = "AU-04-BK",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-BK.webp",
            Url = "/product/AU-04?sku=AU-04-BK",
            Rgb = new Color {
                Red = 53,
                Green = 56,
                Blue = 57
            }
        },
        new RecommendationDto {
            Name = "EcoGrow Crop Commander Zestful Horizon",
            Sku = "AU-05-ZH",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-05-ZH.webp",
            Url = "/product/AU-05?sku=AU-05-ZH",
            Rgb = new Color {
                Red = 255,
                Green = 160,
                Blue = 122
            }
        },
        new RecommendationDto {
            Name = "FarmFleet Sovereign Canary Zenith",
            Sku = "AU-06-CZ",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-CZ.webp",
            Url = "/product/AU-06?sku=AU-06-CZ",
            Rgb = new Color {
                Red = 255,
                Green = 215,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "FarmFleet Sovereign Minted Jade",
            Sku = "AU-06-MT",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-MT.webp",
            Url = "/product/AU-06?sku=AU-06-MT",
            Rgb = new Color {
                Red = 98,
                Green = 136,
                Blue = 130
            }
        },
        new RecommendationDto{
            Name = "Verde Voyager Glacial Mint",
            Sku = "AU-07-MT",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-MT.webp",
            Url = "/product/AU-07?sku=AU-07-MT",
            Rgb = new Color {
                Red = 175,
                Green = 219,
                Blue = 210
            }
        },
        new RecommendationDto {
            Name = "Verde Voyager Sunbeam Yellow",
            Sku = "AU-07-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-YE.webp",
            Url = "/product/AU-07?sku=AU-07-YE",
            Rgb = new Color {
                Red = 255,
                Green = 218,
                Blue = 3
            }
        },
        new RecommendationDto {
            Name = "Field Pioneer Polar White",
            Sku = "AU-08-WH",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-08-WH.webp",
            Url = "/product/AU-08?sku=AU-08-WH",
            Rgb = new Color {
                Red = 232,
                Green = 232,
                Blue = 232
            }
        },
        new RecommendationDto {
            Name = "Heritage Workhorse Verdant Field",
            Sku = "CL-01-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GR.webp",
            Url = "/product/CL-01?sku=CL-01-GR",
            Rgb = new Color {
                Red = 107,
                Green = 142,
                Blue = 35
            }
        },
        new RecommendationDto {
            Name = "Heritage Workhorse Stormy Sky",
            Sku = "CL-01-GY",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GY.webp",
            Url = "/product/CL-01?sku=CL-01-GY",
            Rgb = new Color {
                Red = 112,
                Green = 128,
                Blue = 144
            }
        },
        new RecommendationDto {
            Name = "Falcon Crest Farm Cerulean Classic",
            Sku = "CL-02-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-02-BL.webp",
            Url = "/product/CL-02?sku=CL-02-BL",
            Rgb = new Color {
                Red = 0,
                Green = 123,
                Blue = 167
            }
        },
        new RecommendationDto {
            Name = "Falcon Crest Work Meadow Green",
            Sku = "CL-03-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-GR.webp",
            Url = "/product/CL-03?sku=CL-03-GR",
            Rgb = new Color {
                Red = 124,
                Green = 252,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Falcon Crest Work Rustic Rose",
            Sku = "CL-03-PI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-PI.webp",
            Url = "/product/CL-03?sku=CL-03-PI",
            Rgb = new Color {
                Red = 181,
                Green = 0,
                Blue = 24
            }
        },
        new RecommendationDto {
            Name = "Falcon Crest Work Harvest Gold",
            Sku = "CL-03-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-YE.webp",
            Url = "/product/CL-03?sku=CL-03-YE",
            Rgb = new Color {
                Red = 218,
                Green = 145,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Broadfield Majestic Oceanic Blue",
            Sku = "CL-04-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-BL.webp",
            Url = "/product/CL-04?sku=CL-04-BL",
            Rgb = new Color {
                Red = 0,
                Green = 64,
                Blue = 166
            }
        },
        new RecommendationDto {
            Name = "Broadfield Majestic Rustic Crimson",
            Sku = "CL-04-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-RD.webp",
            Url = "/product/CL-04?sku=CL-04-RD",
            Rgb = new Color {
                Red = 123,
                Green = 63,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Broadfield Majestic Aqua Green",
            Sku = "CL-04-TQ",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-TQ.webp",
            Url = "/product/CL-04?sku=CL-04-TQ",
            Rgb = new Color {
                Red = 0,
                Green = 178,
                Blue = 152
            }
        },
        new RecommendationDto {
            Name = "Countryside Commander Pacific Teal",
            Sku = "CL-05-PT",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-PT.webp",
            Url = "/product/CL-05?sku=CL-05-PT",
            Rgb = new Color {
                Red = 71,
                Green = 157,
                Blue = 168
            }
        },
        new RecommendationDto {
            Name = "Countryside Commander Barn Red",
            Sku = "CL-05-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-RD.webp",
            Url = "/product/CL-05?sku=CL-05-RD",
            Rgb = new Color {
                Red = 124,
                Green = 10,
                Blue = 2
            }
        },
        new RecommendationDto {
            Name = "Danamark Steadfast Emerald Forest",
            Sku = "CL-06-MT",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-MT.webp",
            Url = "/product/CL-06?sku=CL-06-MT",
            Rgb = new Color {
                Red = 70,
                Green = 245,
                Blue = 187
            }
        },
        new RecommendationDto {
            Name = "Danamark Steadfast Golden Wheat",
            Sku = "CL-06-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-YE.webp",
            Url = "/product/CL-06?sku=CL-06-YE",
            Rgb = new Color {
                Red = 250,
                Green = 175,
                Blue = 63
            }
        },
        new RecommendationDto {
            Name = "Greenland Rover Forest Fern",
            Sku = "CL-07-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-GR.webp",
            Url = "/product/CL-07?sku=CL-07-GR",
            Rgb = new Color {
                Red = 46,
                Green = 162,
                Blue = 80
            }
        },
        new RecommendationDto {
            Name = "Greenland Rover Autumn Amber",
            Sku = "CL-07-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-YE.webp",
            Url = "/product/CL-07?sku=CL-07-YE",
            Rgb = new Color {
                Red = 255,
                Green = 191,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Holland Hamster Polder Green",
            Sku = "CL-08-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-GR.webp",
            Url = "/product/CL-08?sku=CL-08-GR",
            Rgb = new Color {
                Red = 194,
                Green = 178,
                Blue = 128
            }
        },
        new RecommendationDto {
            Name = "Holland Hamster Tulip Magenta",
            Sku = "CL-08-PI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-PI.webp",
            Url = "/product/CL-08?sku=CL-08-PI",
            Rgb = new Color {
                Red = 214,
                Green = 82,
                Blue = 130
            }
        },
        new RecommendationDto {
            Name = "TerraFirma Veneto Adriatic Blue",
            Sku = "CL-09-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-BL.webp",
            Url = "/product/CL-09?sku=CL-09-BL",
            Rgb = new Color {
                Red = 47,
                Green = 110,
                Blue = 163
            }
        },
        new RecommendationDto {
            Name = "TerraFirma Veneto Tuscan Green",
            Sku = "CL-09-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-GR.webp",
            Url = "/product/CL-09?sku=CL-09-GR",
            Rgb = new Color {
                Red = 81,
                Green = 139,
                Blue = 43
            }
        },
        new RecommendationDto {
            Name = "Global Gallant Sahara Dawn",
            Sku = "CL-10-SD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-SD.webp",
            Url = "/product/CL-10?sku=CL-10-SD",
            Rgb = new Color {
                Red = 184,
                Green = 168,
                Blue = 117
            }
        },
        new RecommendationDto {
            Name = "Global Gallant Violet Vintage",
            Sku = "CL-10-VI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-VI.webp",
            Url = "/product/CL-10?sku=CL-10-VI",
            Rgb = new Color {
                Red = 138,
                Green = 43,
                Blue = 226
            }
        },
        new RecommendationDto {
            Name = "Scandinavia Sower Baltic Blue",
            Sku = "CL-11-SK",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-SK.webp",
            Url = "/product/CL-11?sku=CL-11-SK",
            Rgb = new Color {
                Red = 149,
                Green = 193,
                Blue = 244
            }
        },
        new RecommendationDto {
            Name = "Scandinavia Sower Nordic Gold",
            Sku = "CL-11-YE",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-YE.webp",
            Url = "/product/CL-11?sku=CL-11-YE",
            Rgb = new Color {
                Red = 255,
                Green = 215,
                Blue = 0
            }
        },
        new RecommendationDto {
            Name = "Celerity Cruiser Velocity Blue",
            Sku = "CL-12-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-BL.webp",
            Url = "/product/CL-12?sku=CL-12-BL",
            Rgb = new Color {
                Red = 30,
                Green = 144,
                Blue = 255
            }
        },
        new RecommendationDto {
            Name = "Celerity Cruiser Rally Red",
            Sku = "CL-12-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-RD.webp",
            Url = "/product/CL-12?sku=CL-12-RD",
            Rgb = new Color {
                Red = 237,
                Green = 41,
                Blue = 57
            }
        },
        new RecommendationDto {
            Name = "Rapid Racer Speedway Blue",
            Sku = "CL-13-BL",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-BL.webp",
            Url = "/product/CL-13?sku=CL-13-BL",
            Rgb = new Color {
                Red = 38,
                Green = 121,
                Blue = 166
            }
        },
        new RecommendationDto {
            Name = "Rapid Racer Raceway Red",
            Sku = "CL-13-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-RD.webp",
            Url = "/product/CL-13?sku=CL-13-RD",
            Rgb = new Color {
                Red = 207,
                Green = 16,
                Blue = 32
            }
        },
        new RecommendationDto {
            Name = "Caribbean Cruiser Emerald Grove",
            Sku = "CL-14-GR",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-GR.webp",
            Url = "/product/CL-14?sku=CL-14-GR",
            Rgb = new Color {
                Red = 87,
                Green = 174,
                Blue = 19
            }
        },
        new RecommendationDto {
            Name = "Caribbean Cruiser Ruby Fields",
            Sku = "CL-14-RD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-RD.webp",
            Url = "/product/CL-14?sku=CL-14-RD",
            Rgb = new Color {
                Red = 205,
                Green = 43,
                Blue = 30
            }
        },
        new RecommendationDto {
            Name = "Fieldmaster Classic Vintage Pink",
            Sku = "CL-15-PI",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-PI.webp",
            Url = "/product/CL-15?sku=CL-15-PI",
            Rgb = new Color {
                Red = 225,
                Green = 148,
                Blue = 158
            }
        },
        new RecommendationDto {
            Name = "Fieldmaster Classic Sahara Dust",
            Sku = "CL-15-SD",
            Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-SD.webp",
            Url = "/product/CL-15?sku=CL-15-SD",
            Rgb = new Color {
                Red = 222,
                Green = 199,
                Blue = 140
            }
        }
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
        var len = colors.Count();

        if (len == 0)
        {
            return new Color
            {
                Red = 255,
                Blue = 255,
                Green = 255,
            };
        }

        var red = colors.Sum(c => c.Red);
        var blue = colors.Sum(c => c.Blue);
        var green = colors.Sum(c => c.Green);
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
