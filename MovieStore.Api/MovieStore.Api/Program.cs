using MovieStore.Api.Dtos;
using MovieStore.Api.Endpoints;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapMoviesEndPoints();


app.Run();


