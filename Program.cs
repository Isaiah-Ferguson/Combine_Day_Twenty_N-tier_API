using Combine_Day_Twenty_N_tier_API.Data;
using Combine_Day_Twenty_N_tier_API.Repositories;
using Combine_Day_Twenty_N_tier_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registering our AppDbContext with Dependancy injection -> We use SQLite -> we're letting EF core know we are using SQLite -> 
// Getting our connection string location -> and that tells EF core where our Database is.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Whenever anyone asks for an ISupplyRepository, Give them SupplyRepository.
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

// Whereever Anyone Asks for an ISupplyService, give them SupplyService.
builder.Services.AddScoped<ISupplyService, SupplyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
