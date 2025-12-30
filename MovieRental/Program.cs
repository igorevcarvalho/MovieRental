using FluentValidation;
using MovieRental.Data;
using MovieRental.Rental.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MovieRentalDbContext>();

builder.Services.AddScoped<IRentalFeatures, RentalFeatures>();
builder.Services.AddScoped<IValidator<MovieRental.Rental.Requests.RentalSaveRequest>, MovieRental.Rental.Validators.RentalSaveRequestValidator>();
builder.Services.AddScoped<IValidator<string>, MovieRental.Rental.Validators.RentalCustomerNameValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var client = new MovieRentalDbContext())
{
	client.Database.EnsureCreated();
}

app.Run();
