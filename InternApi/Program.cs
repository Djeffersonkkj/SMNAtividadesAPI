using Asp.Versioning;
using InternApi.Data;
using InternApi.Interfaces;
using InternApi.Repositories;
using InternApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v2");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEstagiarioService, EstagiarioService>();
builder.Services.AddSingleton<IEstagiarioRepository, EstagiarioRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddHttpClient<IEnderecoService, EnderecoService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
});

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/{documentName}.json");

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/v1.json", "Intern API v1");
        options.SwaggerEndpoint("/v2.json", "Intern API v2");
    });
}

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
