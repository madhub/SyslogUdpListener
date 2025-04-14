using System.Net.Sockets;
using System.Text;

namespace SyslogUdpListener;


public class SyslogUdpService : BackgroundService
{
    private readonly ILogger<SyslogUdpService> _logger;
    private UdpClient? _udpClient;
    private const int Port = 1514; // Syslog UDP port

    public SyslogUdpService(ILogger<SyslogUdpService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _udpClient = new UdpClient(Port);
        _logger.LogInformation("Syslog UDP listener started on port {Port}", Port);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var result = await _udpClient.ReceiveAsync(stoppingToken);
                string message = Encoding.UTF8.GetString(result.Buffer);
                await Console.Out.WriteLineAsync($"Received: {message} from {result.RemoteEndPoint}");
                _logger.LogInformation("Received: {Message} from {RemoteEndPoint}", message, result.RemoteEndPoint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error receiving UDP message");
            }
        }

        _udpClient.Close();
        _logger.LogInformation("Syslog UDP listener stopped.");
    }

    public override void Dispose()
    {
        _udpClient?.Dispose();
        base.Dispose();
    }
}