using MovieStore.Api.Data;
using MovieStore.Api.Dtos;
using MovieStore.Api.Endpoints;
using MovieStore.Api.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();
builder.AddMovieStoreDb();  //DataExtensions

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapMoviesEndPoints();   //MovieEndPoints
app.MapGenreEndPoints();    //GenreEndPoints


app.Run();


