namespace LibraryTesting;
using BookLib;
using TaxLib;

[TestClass]
public class ABook
{
    [TestMethod]
    public void ABookCanHaveATitleAndAPrice()
    {
        //Arrange
        Book book = new Book();
        book.Title = "The Great Gatsby";
        book.Price = 10.00;
        //Act
        string result = book.Title; 
        double result2 = book.Price;
        //Assert
        Assert.AreEqual("The Great Gatsby", result);
        Assert.AreEqual(10.00, result2);
    }
    
    [TestMethod]
    public void ABooksTaxCanBeCalculated()
    {
        //Arrange
        Book book = new Book();
        book.Price = 14.99;
        TaxRate tax = new TaxRate();
        tax.SetTaxRate(0.05);
        //Act
        double result = (book.Price * tax.TaxRatePropety);
        //Assert
        Assert.AreEqual(0.7495, result);
    }
    
    [TestMethod]
    public void ABookAndTaxCanBeCalculatedTogether()
    {
        //Arrange
        Book book = new Book();
        book.Price = 14.99;
        book.PriceWithTax(new TaxRate());
        //Act
        double result = book.PriceWithTax(new TaxRate());
        //Assert
        Assert.AreEqual(16.489, result);
    }
}

[TestClass]
public class Tax
{
    [TestMethod]
    public void TaxCanBeSet()
    {
        //Arrange
        TaxRate tax = new TaxRate();
        tax.SetTaxRate(15);
        //Act
        double result = tax.TaxRatePropety;
        //Assert
        Assert.AreEqual(15, result);
    }
}