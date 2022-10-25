using CrimeEvent;
using CrimeEventsMongoDB.MongoDBSettings;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProfilesCollection();
builder.Services.AddScopedConfiguration();

builder.Services.Configure<CrimeEventDBSettings>(
    builder.Configuration.GetSection("CrimesStoreDB"));
builder.Services.AddHttpClient("Gateway", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["Hosts:LawEnforcementHost"]);
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
