namespace MovieRental.Rental.Requests
{
    public class RentalSaveRequest
    {
        public int MovieId { get; set; }
        public int DaysRented { get; set; }
        public int PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
    }
}
