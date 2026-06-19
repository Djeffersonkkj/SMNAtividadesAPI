using Asp.Versioning;
using InternApi.Interfaces;
using InternApi.Repositories;
using InternApi.Services;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IEstagiarioService, EstagiarioService>();
    builder.Services.AddSingleton<IEstagiarioRepository, EstagiarioRepository>();

    builder.Services.AddAutoMapper(cfg => {}, typeof(Program));

    builder.Services
        .AddApiVersioning( options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseSwagger();

app.MapControllers();

app.UseSwaggerUI();

app.Run();
