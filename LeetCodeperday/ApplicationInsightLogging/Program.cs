using log4net.Config;
using log4net;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
ILog log = LogManager.GetLogger(typeof(Program));
var log4netConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "log4net.config");
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
var test = new FileInfo(log4netConfigPath);
XmlConfigurator.Configure(logRepository, new FileInfo(log4netConfigPath));

// Add services to the container.
string appInsightsConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
{
    ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"],
    EnableActiveTelemetryConfigurationSetup = true
});
var app = builder.Build();
log.Info("Application started.");

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
