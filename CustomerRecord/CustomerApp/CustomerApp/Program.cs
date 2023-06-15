using CustomerApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddOptions();

// Swashbuckle - Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen();

builder.Logging.AddJsonConsole();

// Set CC Local db connection string
var dbConnectionString = builder.Configuration["DbContextSettings:ConnectionString"];

builder.Services.AddDbContextPool<PostgreSqlContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        // options.LogTo(Console.WriteLine);
    }
    options.UseNpgsql(dbConnectionString);
});

builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();
builder.Services.AddTransient<PostgreSqlContext, PostgreSqlContext>();

var app = builder.Build();

//var localDbContext = app.Services.CreateScope().ServiceProvider.GetService<PostgreSqlContext>();

// Update database based on migrations
//localDbContext.Database.Migrate();

app.UseRouting();

// Swashbuckle
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Service App V1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("K8s Customer Service App");
});

app.Run();
