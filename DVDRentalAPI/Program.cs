using DVDRentalAPI.Application;
using DVDRentalAPI.Persistence;
using DVDRentalAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();


builder.Services.AddControllers();

builder.Services.AddDbContext<DVDRentalAPIDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

var app = builder.Build();

app.MapControllers();

app.Run();
