namespace TaxLib;

public class TaxRate
{
    public double TaxRatePropety { get; set; } = 0.10;
    public double SetTaxRate(double rate)                   //SetTaxRate sets the library tax rate and returns the new rate.
    {
        TaxRatePropety = rate;
        return TaxRatePropety;
    }
}