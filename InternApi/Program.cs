using InternApi.Interfaces;
using InternApi.Repositories;
using InternApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEstagiarioService, EstagiarioService>();
builder.Services.AddSingleton<IEstagiarioRepository, EstagiarioRepository>();

builder.Services.AddAutoMapper(cfg => {}, typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.UseSwagger();

app.MapControllers();

app.UseSwaggerUI();

app.Run();
