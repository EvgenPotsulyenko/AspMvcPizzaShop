using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMvcPizzaShop.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public byte[] Img { get; set; }
        public string Name { get; set; }
        public virtual Ingredient Ingred { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
}
