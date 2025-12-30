using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental.Features
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _context;

		public RentalFeatures(MovieRentalDbContext context)
		{
			_context = context;
		}

		public async Task<DTO.Rental> Save(Requests.RentalSaveRequest input)
		{
            var entity = new Entities.Rental
            {
                MovieId = input.MovieId,
                DaysRented = input.DaysRented,
                PaymentMethodId = input.PaymentMethodId,
                CustomerId = input.CustomerId
            };
            await _context.Rentals.AddAsync(entity);
			await _context.SaveChangesAsync();

			var dto = new DTO.Rental
			{
				Id = entity.Id,
				MovieId = entity.MovieId,
				DaysRented =  0,
				PaymentMethodId = entity.PaymentMethodId,
				CustomerId = entity.CustomerId
			};
            return dto;
		}

		public async Task<IEnumerable<DTO.Rental>> GetRentalsByCustomerName(string customerName)
		{
            return await _context.Rentals
                .Where(r => r.Customer != null && EF.Functions.Like(r.Customer.Name, customerName))
                .Include(r => r.Movie)
                .AsNoTracking()
				.Select(r => new DTO.Rental
				{
					Id = r.Id,
					MovieId = r.MovieId,
					DaysRented = r.DaysRented,
					PaymentMethodId = r.PaymentMethodId,
					CustomerId = r.CustomerId
				})
                .ToListAsync();
        }
	}
}
