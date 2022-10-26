using CrimeEvent;
using CrimeEvent.Middleware;
using CrimeEventsMongoDB.MongoDBSettings;
using Microsoft.Net.Http.Headers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProfilesCollection();
builder.Services.AddScopedConfiguration();
builder.Services.AddScoped<ErrorHandling>();

builder.Services.Configure<CrimeEventDBSettings>(
    builder.Configuration.GetSection("CrimesStoreDB"));
builder.Services.AddHttpClient("Gateway", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["Hosts:LawEnforcementHost"]);
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
});

var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseMiddleware<ErrorHandling>();
app.UseAuthorization();

app.MapControllers();

app.Run();
