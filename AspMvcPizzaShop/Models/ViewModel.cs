namespace AspMvcPizzaShop.Models
{
    public class ViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public List<Pizza> Pizzas { get; set; }
    }
}
