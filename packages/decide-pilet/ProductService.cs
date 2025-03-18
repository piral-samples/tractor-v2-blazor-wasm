using System.Collections.Generic;
using System.Linq;

namespace Decide;

public class ProductService : IProductService
{
    private static readonly List<Product> _products = [
      new Product
      {
          Name = "TerraFirma AutoCultivator T-300",
          Id = "AU-01",
          Category = "autonomous",
          Highlights = [
              "Precision GPS mapping optimizes field coverage.",
              "Hybrid engine ensures eco-friendly extended operation.",
              "Fully autonomous with smart obstacle detection and terrain adaptation."
          ],
          Variants = [
              new Variant
              {
                  Name = "Silver",
                  Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp",
                  Sku = "AU-01-SI",
                  Color = "#C0C0C0",
                  Price = 1000m
              }
          ]
      },
      new Product
      {
          Name = "SmartFarm Titan",
          Id = "AU-02",
          Category = "autonomous",
          Highlights = [
              "Advanced autopilot technology for precise farming operations.",
              "Eco-friendly solar-assisted power system for sustainable use.",
              "Intelligent AI for real-time field analysis and automated adjustments."
          ],
          Variants = [
              new Variant { Name = "Sunset Copper", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-OG.webp", Sku = "AU-02-OG", Color = "#dd5219", Price = 4100 },
              new Variant { Name = "Cosmic Sapphire", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-BL.webp", Sku = "AU-02-BL", Color = "#2A52BE", Price = 4000 },
              new Variant { Name = "Verdant Shadow", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-GG.webp", Sku = "AU-02-GG", Color = "#005A04", Price = 4000 }
          ]
      },
      new Product
      {
          Name = "FutureHarvest Navigator",
          Id = "AU-03",
          Category = "autonomous",
          Highlights = [
              "Autonomous navigation with sub-inch accuracy",
              "Solar-enhanced hybrid powertrain for extended operation",
              "Real-time crop and soil health analytics"
          ],
          Variants = [
              new Variant { Name = "Turquoise Titan", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-TQ.webp", Sku = "AU-03-TQ", Color = "#169fb8", Price = 1600 },
              new Variant { Name = "Majestic Violet", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-PL.webp", Sku = "AU-03-PL", Color = "#9B5FC0", Price = 1700 },
              new Variant { Name = "Scarlet Dynamo", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-RD.webp", Sku = "AU-03-RD", Color = "#FF2400", Price = 1900 },
              new Variant { Name = "Sunbeam Yellow", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-YE.webp", Sku = "AU-03-YE", Color = "#faad00", Price = 1800 }
          ]
      },
      new Product
      {
          Name = "Sapphire Sunworker 460R",
          Id = "AU-04",
          Category = "autonomous",
          Highlights = [
              "Next-generation autonomous guidance system for seamless operation",
              "High-capacity energy storage for all-day work without recharge",
              "Advanced analytics suite for precision soil and plant health management"
          ],
          Variants = [
              new Variant { Name = "Ruby Red", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-RD.webp", Sku = "AU-04-RD", Color = "#9B111E", Price = 8700 },
              new Variant { Name = "Midnight Onyx", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-BK.webp", Sku = "AU-04-BK", Color = "#353839", Price = 8500 }
          ]
      },
      new Product
      {
          Name = "EcoGrow Crop Commander",
          Id = "AU-05",
          Category = "autonomous",
          Highlights = [
              "Ultra-precise field navigation technology",
              "Dual-mode power system for maximum uptime",
              "On-the-go field data analysis for smart farming decisions"
          ],
          Variants = [
              new Variant { Name = "Zestful Horizon", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-05-ZH.webp", Sku = "AU-05-ZH", Color = "#FFA07A", Price = 3400 }
          ]
      },
      new Product
      {
          Name = "FarmFleet Sovereign",
          Id = "AU-06",
          Category = "autonomous",
          Highlights = [
              "Robust all-terrain adaptability for diverse farm landscapes",
              "High-efficiency energy matrix for longer field endurance",
              "Integrated crop management system with advanced diagnostics"
          ],
          Variants = [
              new Variant { Name = "Canary Zenith", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-CZ.webp", Sku = "AU-06-CZ", Color = "#FFD700", Price = 2200 },
              new Variant { Name = "Minted Jade", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-MT.webp", Sku = "AU-06-MT", Color = "#628882", Price = 2100 }
          ]
      },
      new Product
      {
          Name = "Verde Voyager",
          Id = "AU-07",
          Category = "autonomous",
          Highlights = [
              "Adaptive drive system intelligently navigates through diverse field conditions",
              "Clean energy operation with advanced solar battery technology",
              "High-resolution field scanners for precise agronomy insights"
          ],
          Variants = [
              new Variant { Name = "Glacial Mint", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-MT.webp", Sku = "AU-07-MT", Color = "#AFDBD2", Price = 4000 },
              new Variant { Name = "Sunbeam Yellow", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-YE.webp", Sku = "AU-07-YE", Color = "#FFDA03", Price = 5000 }
          ]
      },
      new Product
      {
          Name = "Field Pioneer",
          Id = "AU-08",
          Category = "autonomous",
          Highlights = [
              "Automated field traversal with intelligent pathfinding algorithms",
              "Eco-friendly electric motors paired with high-capacity batteries",
              "Real-time environmental monitoring for optimal crop growth"
          ],
          Variants = [
              new Variant { Name = "Polar White", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-08-WH.webp", Sku = "AU-08-WH", Color = "#E8E8E8", Price = 4500 }
          ]
      },
      new Product
      {
          Name = "Heritage Workhorse",
          Id = "CL-01",
          Category = "classic",
          Highlights = [
              "Proven reliability with a touch of modern reliability enhancements",
              "Robust construction equipped to withstand decades of labor",
              "User-friendly operation with traditional manual controls"
          ],
          Variants = [
              new Variant { Name = "Verdant Field", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GR.webp", Sku = "CL-01-GR", Color = "#6B8E23", Price = 5700 },
              new Variant { Name = "Stormy Sky", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GY.webp", Sku = "CL-01-GY", Color = "#708090", Price = 6200 }
          ]
      },
      new Product
      {
          Name = "Falcon Crest Farm",
          Id = "CL-02",
          Category = "classic",
          Highlights = [
              "Rugged simplicity meets classic design",
              "Built-to-last machinery for reliable fieldwork",
              "Ease of control with straightforward mechanical systems"
          ],
          Variants = [
              new Variant { Name = "Cerulean Classic", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-02-BL.webp", Sku = "CL-02-BL", Color = "#007BA7", Price = 2600 }
          ]
      },
      new Product
      {
          Name = "Falcon Crest Work",
          Id = "CL-03",
          Category = "classic",
          Highlights = [
              "Vintage engineering with a legacy of durability",
              "Powerful yet simple mechanics for easy operation and repair",
              "Classic aesthetics with a robust body, built to last"
          ],
          Variants = [
              new Variant { Name = "Meadow Green", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-GR.webp", Sku = "CL-03-GR", Color = "#7CFC00", Price = 2300 },
              new Variant { Name = "Rustic Rose", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-PI.webp", Sku = "CL-03-PI", Color = "#b50018", Price = 2300 },
              new Variant { Name = "Harvest Gold", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-YE.webp", Sku = "CL-03-YE", Color = "#DA9100", Price = 2300 }
          ]
      },
      new Product
      {
          Name = "Broadfield Majestic",
          Id = "CL-04",
          Category = "classic",
          Highlights = [
              "Built with the robust heart of early industrial workhorses",
              "Simplified mechanics for unparalleled ease of use and maintenance",
              "A testament to early agricultural machinery with a dependable engine"
          ],
          Variants = [
              new Variant { Name = "Oceanic Blue", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-BL.webp", Sku = "CL-04-BL", Color = "#0040a6", Price = 2200 },
              new Variant { Name = "Rustic Crimson", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-RD.webp", Sku = "CL-04-RD", Color = "#7B3F00", Price = 2200 },
              new Variant { Name = "Aqua Green", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-TQ.webp", Sku = "CL-04-TQ", Color = "#00b298", Price = 2200 }
          ]
      },
      new Product
      {
          Name = "Countryside Commander",
          Id = "CL-05",
          Category = "classic",
          Highlights = [
              "Reliable performance with time-tested engineering",
              "Rugged design for efficient operation across all types of terrain",
              "Classic operator comfort with modern ergonomic enhancements"
          ],
          Variants = [
              new Variant { Name = "Pacific Teal", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-PT.webp", Sku = "CL-05-PT", Color = "#479da8", Price = 2700 },
              new Variant { Name = "Barn Red", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-RD.webp", Sku = "CL-05-RD", Color = "#7C0A02", Price = 2700 }
          ]
      },
      new Product
      {
          Name = "Danamark Steadfast",
          Id = "CL-06",
          Category = "classic",
          Highlights = [
              "Engineered for the meticulous demands of Danish agriculture",
              "Sturdy chassis and reliable mechanics for longevity",
              "Utilitarian design with practical functionality and comfort"
          ],
          Variants = [
              new Variant { Name = "Emerald Forest", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-MT.webp", Sku = "CL-06-MT", Color = "#46f5bb", Price = 2800 },
              new Variant { Name = "Golden Wheat", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-YE.webp", Sku = "CL-06-YE", Color = "#faaf3f", Price = 2800 }
          ]
      },
      new Product
      {
          Name = "Greenland Rover",
          Id = "CL-07",
          Category = "classic",
          Highlights = [
              "Engineered to tackle the diverse European terrain with ease",
              "Sturdy and reliable mechanics known for their longevity",
              "Ergonomically designed for comfort during long working hours"
          ],
          Variants = [
              new Variant { Name = "Forest Fern", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-GR.webp", Sku = "CL-07-GR", Color = "#2ea250", Price = 2900 },
              new Variant { Name = "Autumn Amber", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-YE.webp", Sku = "CL-07-YE", Color = "#FFBF00", Price = 2900 }
          ]
      },
      new Product
      {
          Name = "Holland Hamster",
          Id = "CL-08",
          Category = "classic",
          Highlights = [
              "Dutch craftsmanship for precision and quality",
              "Optimized for tulip fields and versatile European landscapes",
              "Ergonomic design with a focus on operator comfort and efficiency"
          ],
          Variants = [
              new Variant { Name = "Polder Green", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-GR.webp", Sku = "CL-08-GR", Color = "#C2B280", Price = 7750 },
              new Variant { Name = "Tulip Magenta", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-PI.webp", Sku = "CL-08-PI", Color = "#D65282", Price = 7900 }
          ]
      },
      new Product
      {
          Name = "TerraFirma Veneto",
          Id = "CL-09",
          Category = "classic",
          Highlights = [
              "Elegant Italian design with sleek lines and a vibrant aesthetic",
              "Precision mechanics for vineyard and orchard maneuverability",
              "Comfort-focused design with a flair for the dramatic"
          ],
          Variants = [
              new Variant { Name = "Adriatic Blue", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-BL.webp", Sku = "CL-09-BL", Color = "#2f6ea3", Price = 2950 },
              new Variant { Name = "Tuscan Green", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-GR.webp", Sku = "CL-09-GR", Color = "#518b2b", Price = 2950 }
          ]
      },
      new Product
      {
          Name = "Global Gallant",
          Id = "CL-10",
          Category = "classic",
          Highlights = [
              "Retro design with a nod to the golden era of farming",
              "Engine robustness that stands the test of time",
              "Functional simplicity for ease of operation in any region"
          ],
          Variants = [
              new Variant { Name = "Sahara Dawn", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-SD.webp", Sku = "CL-10-SD", Color = "#b8a875", Price = 2600 },
              new Variant { Name = "Violet Vintage", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-VI.webp", Sku = "CL-10-VI", Color = "#8A2BE2", Price = 2600 }
          ]
      },
      new Product
      {
          Name = "Scandinavia Sower",
          Id = "CL-11",
          Category = "classic",
          Highlights = [
              "Authentic Swedish engineering for optimal cold-climate performance",
              "Sturdy build and mechanics for lifelong reliability",
              "Iconic design reflecting the simplicity and efficiency of Scandinavian style"
          ],
          Variants = [
              new Variant { Name = "Baltic Blue", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-SK.webp", Sku = "CL-11-SK", Color = "#95c1f4", Price = 3100 },
              new Variant { Name = "Nordic Gold", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-YE.webp", Sku = "CL-11-YE", Color = "#FFD700", Price = 3100 }
          ]
      },
      new Product
      {
          Name = "Celerity Cruiser",
          Id = "CL-12",
          Category = "classic",
          Highlights = [
              "A speedster in the classic tractor segment, unparalleled in quick task completion",
              "Sleek design with aerodynamic contours for reduced drag",
              "Enhanced gearbox for smooth acceleration and nimble handling"
          ],
          Variants = [
              new Variant { Name = "Velocity Blue", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-BL.webp", Sku = "CL-12-BL", Color = "#1E90FF", Price = 3200 },
              new Variant { Name = "Rally Red", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-RD.webp", Sku = "CL-12-RD", Color = "#ED2939", Price = 3200 }
          ]
      },
      new Product
      {
          Name = "Rapid Racer",
          Id = "CL-13",
          Category = "classic",
          Highlights = [
              "Streamlined design for faster field operations",
              "Optimized gear ratios for efficient power transmission",
              "Advanced air flow system for superior engine cooling"
          ],
          Variants = [
              new Variant { Name = "Speedway Blue", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-BL.webp", Sku = "CL-13-BL", Color = "#2679a6", Price = 7500 },
              new Variant { Name = "Raceway Red", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-RD.webp", Sku = "CL-13-RD", Color = "#CF1020", Price = 7500 }
          ]
      },
      new Product
      {
          Name = "Caribbean Cruiser",
          Id = "CL-14",
          Category = "classic",
          Highlights = [
              "Robust construction for enduring performance",
              "Time-tested design with a proven track record",
              "Easy-to-service mechanics for long-term reliability"
          ],
          Variants = [
              new Variant { Name = "Emerald Grove", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-GR.webp", Sku = "CL-14-GR", Color = "#57ae13", Price = 2300 },
              new Variant { Name = "Ruby Fields", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-RD.webp", Sku = "CL-14-RD", Color = "#cd2b1e", Price = 2300 }
          ]
      },
      new Product
      {
          Name = "Fieldmaster Classic",
          Id = "CL-15",
          Category = "classic",
          Highlights = [
              "Timeless design with a focus on comfort and control",
              "Efficient fuel consumption with a powerful engine",
              "Versatile functionality for all types of agricultural work"
          ],
          Variants = [
              new Variant { Name = "Vintage Pink", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-PI.webp", Sku = "CL-15-PI", Color = "#e1949e", Price = 6200 },
              new Variant { Name = "Sahara Dust", Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-SD.webp", Sku = "CL-15-SD", Color = "#dec78c", Price = 6200 }
          ]
      }
    ];

    public Product GetProduct(string id)
    {
        return _products.FirstOrDefault(m => m.Id == id);
    }
}
