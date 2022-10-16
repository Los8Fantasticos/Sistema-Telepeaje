using Microsoft.EntityFrameworkCore;

using MinimalAPI_Reconocimiento.Configurations;
using MinimalAPI_Reconocimiento.Contracts.Repositories;
using MinimalAPI_Reconocimiento.Contracts.Services;
using MinimalAPI_Reconocimiento.Endpoints.Patente;
using MinimalAPI_Reconocimiento.Infrastructure;
using MinimalAPI_Reconocimiento.Infrastructure.Repositories;
using MinimalAPI_Reconocimiento.Services;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureBuilder();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ?? builder.Configuration["ConnectionStrings"]?.ToString() ?? "";

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureLogger(builder);
builder.Services.AddScoped<PatenteEndpoint>();
builder.Services.AddScoped<IPatenteRepository, PatenteRepository>();
builder.Services.AddScoped<IPatenteService, PatenteService>();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var databaseContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    if (databaseContext != null)
    {
        databaseContext.Database.EnsureCreated();
    }
    scope.ServiceProvider.GetService<PatenteService>();
    scope.ServiceProvider.GetService<PatenteEndpoint>()?.MapPatenteEndpoints(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();