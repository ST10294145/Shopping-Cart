using System;
using System.Collections.Generic;

public enum ProductCategory
{
    Clothing,
    Electronics,
    Home,
    Beauty,
    Groceries
}

public class Product
{
    public string Name { get; }
    public double Price { get; }
    public ProductCategory Category { get; }

    public Product(string name, double price, ProductCategory category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Name: {0}", Name);
        Console.WriteLine("Price: {0}", Price);
        Console.WriteLine("Category: {0}", Category);
    }
}

public class ShoppingCart
{
    private List<Product> products;

    public ShoppingCart()
    {
        products = new List<Product>();
    }

    public List<Product> Products
    {
        get { return products; }
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine("Product added to the cart.");
    }

    public void RemoveProduct(Product product)
    {
        if (products.Remove(product))
        {
            Console.WriteLine("Product removed from the cart.");
        }
        else
        {
            Console.WriteLine("Product not found in the cart.");
        }
    }
}

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            List<Product> availableProducts = GetAvailableProducts();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. View Available Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Remove Product from Cart");
                Console.WriteLine("5. Checkout and Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        DisplayAvailableProducts(availableProducts);
                        break;
                    case 2:
                        AddProductToCart(cart, availableProducts);
                        break;
                    case 3:
                        DisplayCart(cart);
                        break;
                    case 4:
                        RemoveProductFromCart(cart);
                        break;
                    case 5:
                        CheckoutAndExit(cart);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            }
        }

        static List<Product> GetAvailableProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product("T-Shirt", 10.0, ProductCategory.Clothing),
                new Product("Jeans", 20.0, ProductCategory.Clothing),
                new Product("Smartphone", 500.0, ProductCategory.Electronics),
                new Product("Laptop", 1000.0, ProductCategory.Electronics),
                new Product("Soap", 5.0, ProductCategory.Beauty),
                new Product("Shampoo", 8.0, ProductCategory.Beauty),
                new Product("Milk", 2.0, ProductCategory.Groceries),
                new Product("Bread", 3.0, ProductCategory.Groceries),
            };

            return products;
        }

        static void DisplayAvailableProducts(List<Product> products)
        {
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                product.DisplayInfo();
                Console.WriteLine("----------");
            }
        }

        static void AddProductToCart(ShoppingCart cart, List<Product> availableProducts)
        {
            Console.WriteLine("Enter the name of the product you want to add to cart:");
            string productName = Console.ReadLine();

            Product selectedProduct = availableProducts.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (selectedProduct != null)
            {
                cart.AddProduct(selectedProduct);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DisplayCart(ShoppingCart cart)
        {
            Console.WriteLine("Items in the Shopping Cart:");
            foreach (Product product in cart.Products)
            {
                product.DisplayInfo();
                Console.WriteLine("----------");
            }
        }

        static void RemoveProductFromCart(ShoppingCart cart)
        {
            Console.WriteLine("Enter the name of the product you want to remove from cart:");
            string productName = Console.ReadLine();

            Product selectedProduct = cart.Products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (selectedProduct != null)
            {
                cart.RemoveProduct(selectedProduct);
            }
            else
            {
                Console.WriteLine("Product not found in the cart.");
            }
        }

        static void CheckoutAndExit(ShoppingCart cart)
        {
            Console.WriteLine("Checking out...");
            Console.WriteLine("Items Purchased:");
            foreach (Product product in cart.Products)
            {
                product.DisplayInfo();
                Console.WriteLine("----------");
            }
            Console.WriteLine("Thank you for shopping with us!");
        }
    }
}
