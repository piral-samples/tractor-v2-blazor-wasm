using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout;

public class DataRepository : IDataRepository
{
    public event EventHandler<EventArgs> CartChanged;

    private static readonly List<Variant> _variants =
    [
        new Variant { Id = "AU-01", Name = "TerraFirma AutoCultivator T-300 Silver", Sku = "AU-01-SI", Price = 1000, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-01-SI.webp", Inventory = 8 },
        new Variant { Id = "AU-02", Name = "SmartFarm Titan Sunset Copper", Sku = "AU-02-OG", Price = 4100, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-OG.webp", Inventory = 4 },
        new Variant { Id = "AU-02", Name = "SmartFarm Titan Cosmic Sapphire", Sku = "AU-02-BL", Price = 4000, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-BL.webp", Inventory = 3 },
        new Variant { Id = "AU-02", Name = "SmartFarm Titan Verdant Shadow", Sku = "AU-02-GG", Price = 4000, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-02-GG.webp", Inventory = 6 },
        new Variant { Id = "AU-03", Name = "FutureHarvest Navigator Turquoise Titan", Sku = "AU-03-TQ", Price = 1600, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-TQ.webp", Inventory = 9 },
        new Variant { Id = "AU-03", Name = "FutureHarvest Navigator Majestic Violet", Sku = "AU-03-PL", Price = 1700, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-PL.webp", Inventory = 7 },
        new Variant { Id = "AU-03", Name = "FutureHarvest Navigator Scarlet Dynamo", Sku = "AU-03-RD", Price = 1900, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-RD.webp", Inventory = 8 },
        new Variant { Id = "AU-03", Name = "FutureHarvest Navigator Sunbeam Yellow", Sku = "AU-03-YE", Price = 1800, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-03-YE.webp", Inventory = 3 },
        new Variant { Id = "AU-04", Name = "Sapphire Sunworker 460R Ruby Red", Sku = "AU-04-RD", Price = 8700, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-RD.webp", Inventory = 9 },
        new Variant { Id = "AU-04", Name = "Sapphire Sunworker 460R Midnight Onyx", Sku = "AU-04-BK", Price = 8500, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-04-BK.webp", Inventory = 8 },
        new Variant { Id = "AU-05", Name = "EcoGrow Crop Commander Zestful Horizon", Sku = "AU-05-ZH", Price = 3400, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-05-ZH.webp", Inventory = 8 },
        new Variant { Id = "AU-06", Name = "FarmFleet Sovereign Canary Zenith", Sku = "AU-06-CZ", Price = 2200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-CZ.webp", Inventory = 3 },
        new Variant { Id = "AU-06", Name = "FarmFleet Sovereign Minted Jade", Sku = "AU-06-MT", Price = 2100, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-06-MT.webp", Inventory = 5 },
        new Variant { Id = "AU-07", Name = "Verde Voyager Glacial Mint", Sku = "AU-07-MT", Price = 4000, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-MT.webp", Inventory = 4 },
        new Variant { Id = "AU-07", Name = "Verde Voyager Sunbeam Yellow", Sku = "AU-07-YE", Price = 5000, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-07-YE.webp", Inventory = 9 },
        new Variant { Id = "AU-08", Name = "Field Pioneer Polar White", Sku = "AU-08-WH", Price = 4500, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/AU-08-WH.webp", Inventory = 4 },
        new Variant { Id = "CL-01", Name = "Heritage Workhorse Verdant Field", Sku = "CL-01-GR", Price = 5700, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GR.webp", Inventory = 8 },
        new Variant { Id = "CL-01", Name = "Heritage Workhorse Stormy Sky", Sku = "CL-01-GY", Price = 6200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-01-GY.webp", Inventory = 7 },
        new Variant { Id = "CL-02", Name = "Falcon Crest Farm Cerulean Classic", Sku = "CL-02-BL", Price = 2600, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-02-BL.webp", Inventory = 1 },
        new Variant { Id = "CL-03", Name = "Falcon Crest Work Meadow Green", Sku = "CL-03-GR", Price = 2300, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-GR.webp", Inventory = 7 },
        new Variant { Id = "CL-03", Name = "Falcon Crest Work Rustic Rose", Sku = "CL-03-PI", Price = 2300, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-PI.webp", Inventory = 3 },
        new Variant { Id = "CL-03", Name = "Falcon Crest Work Harvest Gold", Sku = "CL-03-YE", Price = 2300, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-03-YE.webp", Inventory = 6 },
        new Variant { Id = "CL-04", Name = "Broadfield Majestic Oceanic Blue", Sku = "CL-04-BL", Price = 2200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-BL.webp", Inventory = 6 },
        new Variant { Id = "CL-04", Name = "Broadfield Majestic Rustic Crimson", Sku = "CL-04-RD", Price = 2200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-RD.webp", Inventory = 3 },
        new Variant { Id = "CL-04", Name = "Broadfield Majestic Aqua Green", Sku = "CL-04-TQ", Price = 2200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-04-TQ.webp", Inventory = 0 },
        new Variant { Id = "CL-05", Name = "Countryside Commander Pacific Teal", Sku = "CL-05-PT", Price = 2700, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-PT.webp", Inventory = 1 },
        new Variant { Id = "CL-05", Name = "Countryside Commander Barn Red", Sku = "CL-05-RD", Price = 2700, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-05-RD.webp", Inventory = 1 },
        new Variant { Id = "CL-06", Name = "Danamark Steadfast Emerald Forest", Sku = "CL-06-MT", Price = 2800, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-MT.webp", Inventory = 1 },
        new Variant { Id = "CL-06", Name = "Danamark Steadfast Golden Wheat", Sku = "CL-06-YE", Price = 2800, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-06-YE.webp", Inventory = 2 },
        new Variant { Id = "CL-07", Name = "Greenland Rover Forest Fern", Sku = "CL-07-GR", Price = 2900, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-GR.webp", Inventory = 4 },
        new Variant { Id = "CL-07", Name = "Greenland Rover Autumn Amber", Sku = "CL-07-YE", Price = 2900, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-07-YE.webp", Inventory = 4 },
        new Variant { Id = "CL-08", Name = "Holland Hamster Polder Green", Sku = "CL-08-GR", Price = 7750, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-GR.webp", Inventory = 8 },
        new Variant { Id = "CL-08", Name = "Holland Hamster Tulip Magenta", Sku = "CL-08-PI", Price = 7900, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-08-PI.webp", Inventory = 3 },
        new Variant { Id = "CL-09", Name = "TerraFirma Veneto Adriatic Blue", Sku = "CL-09-BL", Price = 2950, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-BL.webp", Inventory = 4 },
        new Variant { Id = "CL-09", Name = "TerraFirma Veneto Tuscan Green", Sku = "CL-09-GR", Price = 2950, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-09-GR.webp", Inventory = 7 },
        new Variant { Id = "CL-10", Name = "Global Gallant Sahara Dawn", Sku = "CL-10-SD", Price = 2600, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-SD.webp", Inventory = 6 },
        new Variant { Id = "CL-10", Name = "Global Gallant Violet Vintage", Sku = "CL-10-VI", Price = 2600, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-10-VI.webp", Inventory = 2 },
        new Variant { Id = "CL-11", Name = "Scandinavia Sower Baltic Blue", Sku = "CL-11-SK", Price = 3100, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-SK.webp", Inventory = 0 },
        new Variant { Id = "CL-11", Name = "Scandinavia Sower Nordic Gold", Sku = "CL-11-YE", Price = 3100, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-11-YE.webp", Inventory = 3 },
        new Variant { Id = "CL-12", Name = "Celerity Cruiser Velocity Blue", Sku = "CL-12-BL", Price = 3200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-BL.webp", Inventory = 8 },
        new Variant { Id = "CL-12", Name = "Celerity Cruiser Rally Red", Sku = "CL-12-RD", Price = 3200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-12-RD.webp", Inventory = 8 },
        new Variant { Id = "CL-13", Name = "Rapid Racer Speedway Blue", Sku = "CL-13-BL", Price = 7500, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-BL.webp", Inventory = 1 },
        new Variant { Id = "CL-13", Name = "Rapid Racer Raceway Red", Sku = "CL-13-RD", Price = 7500, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-13-RD.webp", Inventory = 5 },
        new Variant { Id = "CL-14", Name = "Caribbean Cruiser Emerald Grove", Sku = "CL-14-GR", Price = 2300, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-GR.webp", Inventory = 3 },
        new Variant { Id = "CL-14", Name = "Caribbean Cruiser Ruby Fields", Sku = "CL-14-RD", Price = 2300, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-14-RD.webp", Inventory = 5 },
        new Variant { Id = "CL-15", Name = "Fieldmaster Classic Vintage Pink", Sku = "CL-15-PI", Price = 6200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-PI.webp", Inventory = 0 },
        new Variant { Id = "CL-15", Name = "Fieldmaster Classic Sahara Dust", Sku = "CL-15-SD", Price = 6200, Image = "https://blueprint.the-tractor.store/cdn/img/product/[size]/CL-15-SD.webp", Inventory = 9 }
    ];

    private readonly List<CartEntry> _entries = [];

    public int Quantity => _entries.Sum(e => e.Quantity);
    
    public decimal Total => _entries.Sum(e => e.Total);

    public IEnumerable<CartEntry> Entries => _entries.AsEnumerable();

    public void Clear()
    {
        _entries.Clear();
        TriggerCartChanged();
    }

    public void AddToCart(string sku)
    {
        var variant = GetVariant(sku);

        foreach (var entry in _entries)
        {
            if (entry.Variant == variant)
            {
                entry.Total += variant.Price;
                entry.Quantity++;
                TriggerCartChanged();
                return;
            }
        }

        _entries.Add(new CartEntry { Variant = variant, Total = variant.Price, Quantity = 1 });
        TriggerCartChanged();
    }

    public void RemoveFromCart(string sku)
    {
        var variant = GetVariant(sku);

        foreach (var entry in _entries)
        {
            if (entry.Variant == variant)
            {
                if (entry.Quantity == 1)
                {
                    _entries.Remove(entry);
                }
                else
                {
                    entry.Total -= variant.Price;
                    entry.Quantity--;
                }

                TriggerCartChanged();
                return;
            }
        }
    }

    public Variant GetVariant(string sku) => _variants.Find(m => m.Sku == sku);

    private void TriggerCartChanged()
    {
        CartChanged?.Invoke(this, EventArgs.Empty);
    }
}
