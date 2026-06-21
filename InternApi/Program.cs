using Asp.Versioning;
using InternApi.Interfaces;
using InternApi.Repositories;
using InternApi.Services;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo(){
        Version = "v1",
        Title = "Intern API",
    });

    options.SwaggerDoc("v2", new OpenApiInfo(){
        Version = "v2",
        Title = "Intern API",
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
} );

builder.Services.AddScoped<IEstagiarioService, EstagiarioService>();
builder.Services.AddSingleton<IEstagiarioRepository, EstagiarioRepository>();

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer( options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Intern API v1");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Intern API v2");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
