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

// MetricService with in-memory test data
builder.Services.AddSingleton(new MetricService(SeedData.GetParticipations()));

var app = builder.Build();

// ------------------------------
// Configure middleware
// ------------------------------

// Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map controller endpoints
app.MapControllers();

app.Run();
