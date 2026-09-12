using MovieStore.Api.Data;
using MovieStore.Api.Dtos;
using MovieStore.Api.Endpoints;
using MovieStore.Api.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();
builder.AddMovieStoreDb();  //DataExtensions

// 서버 Cors 설정
builder.Services.AddCors(o => o.AddPolicy("AllowClient", p =>
    p.WithOrigins("http://localhost:5054") //React 배포 주소
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()));  // 모든걸 허용

var app = builder.Build();
app.UseCors("AllowClient"); // 서버 Cors 설정

// Configure the HTTP request pipeline.
app.MapMoviesEndPoints();   //MovieEndPoints
app.MapGenreEndPoints();    //GenreEndPoints


app.Run();


