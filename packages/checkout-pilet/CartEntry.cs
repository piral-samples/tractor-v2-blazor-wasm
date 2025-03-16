namespace Checkout;

public class CartEntry
{
    public decimal Total { get; set; }

    public int Quantity { get; set; }
    
    public Variant Variant { get; set; }
}
