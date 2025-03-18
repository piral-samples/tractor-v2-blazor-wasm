using System;
using System.Collections.Generic;

namespace Checkout;

public interface IDataRepository
{
    event EventHandler<EventArgs> CartChanged;

    void AddToCart(string sku);

    void RemoveFromCart(string sku);

    void Clear();

    int Quantity { get; }

    decimal Total { get; }

    IEnumerable<CartEntry> Entries { get; }

    Variant GetVariant(string sku);
}
