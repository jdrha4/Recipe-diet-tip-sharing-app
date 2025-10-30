// Recipe.cs
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Domain.Entities
{
    public class Recipe : Entity<int>
    {
        public string Nazov { get; set; }
        public string Popis { get; set; }
        public string Preferencia { get; set; }
        public string Obtiaznost { get; set; }
        public string Ingrediencie { get; set; }
        public bool VegetarianskeJedlo { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser User { get; set; }
    }
}
