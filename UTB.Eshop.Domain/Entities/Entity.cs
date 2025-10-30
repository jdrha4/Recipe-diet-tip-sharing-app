using System.ComponentModel.DataAnnotations;

namespace UTB.Eshop.Domain.Entities
{
    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
