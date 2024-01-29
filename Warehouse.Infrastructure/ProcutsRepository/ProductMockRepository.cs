using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure;

public class ProductMockRepository : IProductRepository
{
    List<Product> mockProducts = new List<Product>()
{
    new Product {Price = 16.99m, Title = "Cozy Hoodie", Description = "Warm and cozy hoodie in green for a relaxed and comfortable style.", Sizes = new List<string>{"Small", "Large" } },
    new Product {Price = 22.49m, Title = "Classic Denim Jacket", Description = "Timeless denim jacket with a stylish fit and durable construction.", Sizes = new List<string>{"Medium", "Large" } },
    new Product {Price = 14.95m, Title = "Striped Cotton T-Shirt", Description = "Casual and breathable striped cotton t-shirt for everyday wear.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 34.99m, Title = "Leather Ankle Boots", Description = "Fashionable leather ankle boots with a sleek design for any occasion.", Sizes = new List<string>{"7", "8", "9", "10" } },
    new Product {Price = 49.99m, Title = "Quilted Puffer Jacket", Description = "Stylish quilted puffer jacket to keep you warm during colder seasons.", Sizes = new List<string>{"Small", "Medium", "Large", "X-Large" } },

    new Product {Price = 29.95m, Title = "Slim Fit Jeans", Description = "Modern slim fit jeans for a contemporary and stylish look.", Sizes = new List<string>{"30Wx32L", "32Wx32L", "34Wx32L", "36Wx32L" } },
    new Product {Price = 12.99m, Title = "Basic White Sneakers", Description = "Essential white sneakers for a casual and versatile wardrobe.", Sizes = new List<string>{"6", "7", "8", "9", "10" } },
    new Product {Price = 42.50m, Title = "Knit Pullover Sweater", Description = "Soft and cozy knit pullover sweater for a warm and stylish winter.", Sizes = new List<string>{"Medium", "Large", "X-Large" } },
    new Product {Price = 18.75m, Title = "Printed Silk Scarf", Description = "Elegant printed silk scarf to add a touch of sophistication to any outfit.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 55.00m, Title = "Tailored Suit", Description = "Classic tailored suit for a polished and professional appearance.", Sizes = new List<string>{"40R", "42R", "44R", "46R" } },

    new Product {Price = 25.99m, Title = "V-Neck Sweater", Description = "Versatile V-neck sweater for a smart-casual style.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 38.50m, Title = "Canvas Backpack", Description = "Durable canvas backpack for carrying essentials in style.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 17.49m, Title = "Graphic Print T-Shirt", Description = "Bold graphic print t-shirt for a trendy and casual look.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 32.99m, Title = "Running Shoes", Description = "Comfortable running shoes for your active lifestyle.", Sizes = new List<string>{"7", "8", "9", "10", "11" } },
    new Product {Price = 45.25m, Title = "Wool Blend Coat", Description = "Sophisticated wool blend coat for a refined winter style.", Sizes = new List<string>{"Medium", "Large", "X-Large" } },

    new Product {Price = 19.95m, Title = "Cotton Chinos", Description = "Classic cotton chinos for a timeless and versatile wardrobe staple.", Sizes = new List<string>{"30Wx32L", "32Wx32L", "34Wx32L", "36Wx32L" } },
    new Product {Price = 14.99m, Title = "Crewneck Sweatshirt", Description = "Casual crewneck sweatshirt for a laid-back and comfortable vibe.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 28.75m, Title = "Crossbody Bag", Description = "Stylish crossbody bag to complete your everyday look.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 23.50m, Title = "Denim Skirt", Description = "Chic denim skirt for a trendy and feminine outfit.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 39.99m, Title = "Faux Leather Jacket", Description = "Edgy faux leather jacket for a bold and fashionable statement.", Sizes = new List<string>{"Medium", "Large", "X-Large" } },

    new Product {Price = 21.99m, Title = "Plaid Button-Up Shirt", Description = "Classic plaid button-up shirt for a timeless casual look.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 36.25m, Title = "Suede Ankle Boots", Description = "Trendy suede ankle boots to elevate your footwear collection.", Sizes = new List<string>{"7", "8", "9", "10" } },
    new Product {Price = 16.50m, Title = "Ribbed Knit Sweater", Description = "Cozy ribbed knit sweater for a warm and stylish winter.", Sizes = new List<string>{"Medium", "Large", "X-Large" } },
    new Product {Price = 27.99m, Title = "Printed Beach Towel", Description = "Vibrantly printed beach towel for a stylish day at the beach.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 49.50m, Title = "Formal Dress Shirt", Description = "Elegant formal dress shirt for a polished and sophisticated look.", Sizes = new List<string>{"15.5", "16", "16.5", "17" } },

    new Product {Price = 18.95m, Title = "Casual Joggers", Description = "Comfortable and casual joggers for a relaxed and sporty style.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 33.75m, Title = "Oversized Sunglasses", Description = "Chic oversized sunglasses to add a touch of glamour to your look.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 14.49m, Title = "Hooded Sweatshirt Dress", Description = "Stylish hooded sweatshirt dress for a trendy and comfortable outfit.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 26.99m, Title = "Leather Belt", Description = "Classic leather belt to complete your everyday attire.", Sizes = new List<string>{"32", "34", "36", "38" } },
    new Product {Price = 42.95m, Title = "Tailored Trench Coat", Description = "Sophisticated tailored trench coat for a timeless and polished look.", Sizes = new List<string>{"Medium", "Large", "X-Large" } },

    new Product {Price = 23.99m, Title = "Printed Silk Blouse", Description = "Elegant printed silk blouse for a refined and feminine ensemble.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 39.50m, Title = "Rugged Backpack", Description = "Durable rugged backpack for adventurous outdoor activities.", Sizes = new List<string>{"One Size" } },
    new Product {Price = 17.25m, Title = "Floral Print Maxi Dress", Description = "Graceful floral print maxi dress for a bohemian and romantic look.", Sizes = new List<string>{"Small", "Medium", "Large" } },
    new Product {Price = 29.99m, Title = "High-Top Sneakers", Description = "Trendy high-top sneakers for a fashion-forward and casual style.", Sizes = new List<string>{"6", "7", "8", "9", "10" } },
    new Product {Price = 48.00m, Title = "Wool Fedora Hat", Description = "Timeless wool fedora hat for a classic and sophisticated appearance.", Sizes = new List<string>{"Small", "Medium", "Large" } },
};


    async Task<IEnumerable<Product>> IProductRepository.GetAllProducts()
    {
        return await Task.FromResult<IEnumerable<Product>>(mockProducts);
    }
}

