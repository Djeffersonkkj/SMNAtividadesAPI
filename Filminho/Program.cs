using Filminho.Services;
using Filminho.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi("filminho");

builder.Services.AddHttpClient("OMDb", client =>
{
    client.BaseAddress = new Uri("http://www.omdbapi.com/");
});

builder.Services.AddScoped<IOMDbApiService, OMDbApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/{documentName}.json");
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/filminho.json", "filminho"));
}

app.MapControllers();

app.Run();