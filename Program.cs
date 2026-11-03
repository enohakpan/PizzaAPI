using PizzaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<PizzaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
