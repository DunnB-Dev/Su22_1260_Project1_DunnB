namespace BookLib;
using TaxLib;

public class Book
{
    public string Title
    {
        get;
        set;
    } = "No Book";

    public double Price { get; set; }

    public double PriceWithTax(TaxRate taxRate)                 //PriceWithTax taxes a TaxRate as a parameter and passes it through to the book's price, calculating it with tax.
    {
        return Price + (taxRate.TaxRatePropety * Price);
    }
}