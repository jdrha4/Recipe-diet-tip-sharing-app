// Jidelnicky.cs
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Domain.Entities
{
    public class Jidelnicek : Entity<int>
    {
        public string Nazov { get; set; }
        public string Popis { get; set; }
        public string Preferencia { get; set; }
        public string Ranajky { get; set; }
        public string Obed { get; set; }
        public string Vecera { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public IUser User { get; set; }
    }
}
