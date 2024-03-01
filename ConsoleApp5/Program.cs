using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
public class Product
{
    private ProductName name;
    private int price;
    public Product(ProductName name, int price)
    {
        this.name = name;
        this.price = price;
    }
    public ProductName GetName()
    {
        return name;
    }
    public int GetPrice()
    {
        return price;
    }
}
public class Payment
{
    private int currentMoney;
    public int GetMoney()
    {
        return currentMoney;
    }
    public Payment(int currentMoney)
    {
        this.currentMoney = currentMoney;
    }
    public void MinusMoney(int needToPay)
    {
        if (currentMoney - needToPay < 0)
        {
            Console.WriteLine("Not enough money");
        }
        else
        {
            currentMoney -= needToPay;
        }
    }
}
class Cash : Payment
{
    public Cash(int currentMoney) : base(currentMoney)
    {
    }
}
class NonCash : Payment
{
    public NonCash(int currentMoney) : base(currentMoney)
    {
    }
}
public class Shop
{
    List<Product> products = new List<Product> { };
    public void AddProduct(Product product)
    {
        products.Add(product);
    }
    public bool CheckProduct(ProductName productname)
    {
        foreach (Product item in products)
        {
            if (item.GetName() == productname)
            {
                return true;
            }
        }
        return false;
    }
    public void ShowProducts()
    {
        foreach (Product product in products)
        {
            Console.WriteLine($"Название : {product.GetName()}, Цена :{product.GetPrice()}");
        }
    }
    public void BuyProduct(ProductName productname, Payment payment, int needToPay)
    {
        foreach (Product item in products)
        {
            if (CheckProduct(productname) == true)
            {
                payment.MinusMoney(needToPay);
                products.Remove(item);
            }
            else
            {
                Console.WriteLine("Out of stock");
            }
        }
    }
}
public enum ProductName
{
    Orange,
    Strawberry,
    Milk,
    Flour,
    Pineapple
}
