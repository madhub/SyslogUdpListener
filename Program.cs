using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/syslog-.log",
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 10_000_000, // 10 MB
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: 10,     // Keep last 10 files
        shared: true)
    .CreateLogger();

// Replace default logging with Serilog
builder.Host.UseSerilog();

builder.Services.AddHostedService<SyslogUdpListener.SyslogUdpService>();

var app = builder.Build();


app.MapGet("/", () => "Syslog UDP Server is running.");

app.Run();


