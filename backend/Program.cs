var builder = WebApplication.CreateBuilder(args);

// Add services to dependency injection container
var services = builder.Services;
services.AddControllers();

var app = builder.Build();

// Configure HTTP request pipeline
app.MapControllers();

// Use static files for front end
app.UseStaticFiles();

app.Run();