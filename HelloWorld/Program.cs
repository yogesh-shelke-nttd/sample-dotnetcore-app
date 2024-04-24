var builder = WebApplication.CreateBuilder(args);

// Set the new path for the appsettings.json file
var newPath = Path.Combine(Directory.GetCurrentDirectory(), "properties");

// Clear the existing configuration providers
builder.Configuration.Sources.Clear();

// Add the configuration providers with the new path
builder.Configuration.SetBasePath(newPath)
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
      .AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
