using MtasStudio.Api.Extensions;
using MtasStudio.Application;
using MtasStudio.Infrastructure;
using MtasStudio.Infrastructure.Context;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JSON serialization options
builder.Services.Configure<JsonSerializerOptions>(options =>
{
    // Preserve object reference loops
    options.ReferenceHandler = ReferenceHandler.Preserve;

    // Increase the maximum depth of nested objects to 64
    options.MaxDepth = 64;
});

builder.WebHost.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = false;
}).ConfigureAppConfiguration(i => i.AddConfiguration(GetConfiguration()));


ConfigureService(builder.Services, builder.Configuration);

var app = builder.Build();

app.MigrateDbContext<MtasDbContext>((context, services) =>
{
    var env = services.GetService<IWebHostEnvironment>();
    var logger = services.GetService<ILogger<MtasDbContext>>();
    new MtasDbContextSeed().SeedAsync(context, logger).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



static IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
    return builder.Build();
}

static void ConfigureService(IServiceCollection services, IConfiguration configuration)
{
    services.AddLogging(configure => configure.AddConsole())
        .AddApplicationRegistration()
        .AddPersistenceRegistration(configuration);
}