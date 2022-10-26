using LawEnforcement;
using LawEnforcement.Middleware;
using LawEnforcementDB.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LawEnforcementContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DBLawEnforcement"]));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProfilesCollection();
builder.Services.AddScopedConfiguration();
builder.Services.AddScoped<ErrorHandling>();
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

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandling>();
app.UseAuthorization();
app.MapControllers();
app.ApplyPendingMigrations();

app.Run();
