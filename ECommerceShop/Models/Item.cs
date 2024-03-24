namespace ECommerceShop.Models
{
    public class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Cost
        {
            get { return (Product.Price) * Quantity; }
        }
    }
}
