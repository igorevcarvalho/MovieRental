using System.ComponentModel.DataAnnotations;

namespace MovieRental.Customer.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
