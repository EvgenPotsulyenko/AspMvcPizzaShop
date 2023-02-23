using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMvcPizzaShop.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Sausage { get; set; }
        public bool Ananas { get; set; }
        public bool DoubleCheese { get; set; }
        public bool Mushrooms { get; set; }
    }
}
