using Microsoft.EntityFrameworkCore;
using EventParticipation.Api.Data;
using EventParticipation.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// Register services
// ------------------------------

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core with SQLite
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=EventParticipation.db"));

builder.Services.AddScoped<MetricService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Creates database and tables if missing

    if (!context.Participations.Any())
    {
        var participations = SeedData.GetParticipations();
        context.Participations.AddRange(participations);
        context.SaveChanges();
    }
}


// ------------------------------
// Configure middleware
// ------------------------------

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map controller endpoints
app.MapControllers();

app.Run();
