using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Rental.Features;
using System.Net;
using Requests = MovieRental.Rental.Requests;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Requests.RentalSaveRequest input,
            [FromServices] IValidator<Requests.RentalSaveRequest> validator)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(input);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                var savedRental = await _features.Save(input);
                return Ok(savedRental);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{customerName}")]
        public async Task<IActionResult> Get(string customerName,
            [FromServices] IValidator<string> validator)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(customerName);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
                }

                return Ok(await _features.GetRentalsByCustomerName(customerName));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
