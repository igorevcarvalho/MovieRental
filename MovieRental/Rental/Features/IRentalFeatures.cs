namespace MovieRental.Rental.Features;

public interface IRentalFeatures
{
	Task<DTO.Rental> Save(Requests.RentalSaveRequest rental);
    Task<IEnumerable<DTO.Rental>> GetRentalsByCustomerName(string customerName);
}