// Tip.cs
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Domain.Entities
{
    public class Tip : Entity<int>
    {
        public string Nazov { get; set; }
        public string Popis { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser User { get; set; }
    }
}
