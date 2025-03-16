using System.Collections.Generic;
using System.Linq;

namespace Checkout;

public class DataRepository : IDataRepository
{
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
        // Add the remaining variants here
    ];

    private readonly List<CartEntry> _entries = [];

    public int Quantity => _entries.Sum(e => e.Quantity);
    
    public decimal Total => _entries.Sum(e => e.Total);

    public IEnumerable<CartEntry> Entries => _entries.AsEnumerable();

    public void Clear()
    {
        _entries.Clear();
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
                return;
            }
        }

        _entries.Add(new CartEntry { Variant = variant, Total = variant.Price, Quantity = 1 });
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

                return;
            }
        }
    }

    public Variant GetVariant(string sku) => _variants.Find(m => m.Sku == sku);
}
