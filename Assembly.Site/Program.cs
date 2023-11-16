using Assembly.Site.Data.Services.Interfaces;
using Assembly.Site.Data.Services;
using NLog;
using NLog.Web;
using NLog.Extensions.Logging;
using Assembly.Site.Data.Context;
using Microsoft.EntityFrameworkCore;

var Logger = LogManager.Setup().LoadConfigurationFromFile("Nlog.config").GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    //NLog Configuration
    string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
    Directory.CreateDirectory(logDir);
    builder.Logging
        .ClearProviders()
        .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Error)
        .AddNLog(
            new NLogProviderOptions
            {
                CaptureMessageTemplates = true,
                CaptureMessageProperties = true,
            }
        );
    builder.Host.UseNLog();
 
    //Business Logic Injection
    builder.Services.AddScoped<IDeviceService, DeviceService>();
    builder.Services.AddScoped<IOperationService, OperationService>();
    builder.Services.AddScoped<ILoggerService, LoggerService>();
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    //DB Context
    string connection = builder.Configuration.GetConnectionString("AssemblyDbConnection")!;
    builder.Services.AddDbContextFactory<JAADBContext>(options =>
    {
        options.UseSqlServer(connection);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception e)
{
    Logger.Error(e.Message, e);
}
finally
{
    LogManager.Shutdown();
}
