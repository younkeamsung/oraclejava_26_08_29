using BlazorApp1.Clients;
using BlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var movieStoreUrl = builder.Configuration["MovieStoreUrl"]
    ?? throw new Exception("MovieStoreUrl이 설정되지 않았습니다.");
builder.Services.AddHttpClient<MoviesClient>(
    client => client.BaseAddress = new Uri(movieStoreUrl));
builder.Services.AddHttpClient<GenreClient>(
    client => client.BaseAddress = new Uri(movieStoreUrl));

//builder.Services.AddSingleton<MoviesClient>();
//builder.Services.AddSingleton<GenreClient>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();
app.UseStaticFiles();



app.MapStaticAssets();
//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode();
app.MapFallbackToFile("/react/{*path}", "react/index.html");
app.MapGet("/", () => Results.Redirect("/react/"));

app.Run();
