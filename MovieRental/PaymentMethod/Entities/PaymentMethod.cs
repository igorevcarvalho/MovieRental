using System.ComponentModel.DataAnnotations;

namespace MovieRental.PaymentMethod.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        public required string Method { get; set; }
    }
}
