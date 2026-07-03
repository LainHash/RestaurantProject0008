using DotNetEnv;
using Restaurant.Application;
using Restaurant.Infrastructure;
using Restaurant.Persistence;


Env.Load();


// Tìm file .env từ thư mục hiện tại, leo dần lên thư mục cha
// → hoạt động dù chạy từ VS (bin/Debug/...) hay dotnet run (src/Restaurant.API/)
var searchDir = Directory.GetCurrentDirectory();
while (searchDir is not null)
{
    var envPath = Path.Combine(searchDir, ".env");
    if (File.Exists(envPath)) { Env.Load(envPath); break; }
    searchDir = Directory.GetParent(searchDir)?.FullName;
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.InitialiseDatabaseAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/api/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
    return endpoints.OfType<RouteEndpoint>().Select(e => new
    {
        Method = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault(),
        Route = e.RoutePattern.RawText
    });
});

app.MapControllers();

app.Run();
