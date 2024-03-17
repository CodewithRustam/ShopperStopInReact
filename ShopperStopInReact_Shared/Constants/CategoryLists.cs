namespace ShopperStopInReact_Shared.Constants
{
    public class CategoryLists
    {
        public Dictionary<string, List<string>> CategoriesWithSubcategories { get; set; }

        public CategoryLists()
        {
            CategoriesWithSubcategories = new Dictionary<string, List<string>>
            {
                { "Clothing", new List<string> { "Men's Clothing", "Women's Clothing", "Kids' Clothing", "Activewear", "Outerwear",     "Underwear" } },
                { "Electronics", new List<string> { "Smartphones", "Laptops", "Tablets", "Cameras", "Headphones", "Speakers" } },
                { "Furniture", new List<string> { "Living", "Bedroom", "Dining", "Office", "Outdoor", "Kids" } },
                { "Books", new List<string> { "Fiction", "NonFiction", "Mystery", "ScienceFiction", "Biography", "SelfHelp",  "CookBooks" } },
                { "Shoes", new List<string> { "Men", "Women", "Kids", "Athletic", "Casual", "Boots", "Sandals" } },
                { "Home", new List<string> { "HomeDécor", "Bedding", "Bath", "Kitchenware", "SmallAppliances", "Storage", "Cleaning" } },
                { "Watches", new List<string> { "Men", "Women", "Unisex", "Smartwatches", "Luxury", "Sports" } },
                { "Jewellery", new List<string> { "Necklaces", "Earrings", "Bracelets", "Rings", "Brooches" } },
                { "Bags", new List<string> { "Handbags", "Backpacks", "ToteBags", "Luggage", "MessengerBags", "Wallets",     "TravelAccessories" } }
            };
        }
    }
    public  class AdminRoles
    {
        public  List<string>? AdminRolesData = new List<string>
            {
                "User Management",
                "Product Management",
                "Order Management",
                "Inventory Management",
                "Content Management",
                "Customer Support",
                "Analytics and Reporting",
                "Security and Compliance",
                "Marketing and Promotions",
                "Platform Customization",
                "Vendor Management",
            };
        
    }
}
