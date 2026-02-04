using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Load ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Gateway",
        Version = "v1"
    });
});

// Add Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateway API v1");
});

// Use Ocelot middleware
await app.UseOcelot();

app.Run();


//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

//var builder = WebApplication.CreateBuilder(args);

//// Load ocelot.json
//builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

//// Add Ocelot
//builder.Services.AddOcelot(builder.Configuration);

//var app = builder.Build();

//// Use Ocelot middleware
//await app.UseOcelot();

//app.Run();