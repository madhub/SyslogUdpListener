# SyslogUdpListener
A lightweight syslog UDP server built with ASP.NET Core and Serilog for file-based logging with rotation and cleanup.

## Features
- **Syslog UDP Listener**: Listens for incoming syslog messages on UDP port 1514.
- **File-based Logging**: Logs messages to files using Serilog with daily rolling logs.
- **Log Rotation and Cleanup**:
  - Automatically rolls over log files daily.
  - Limits log file size to 10 MB.
  - Retains the last 10 log files.
- **Error Handling**: Logs errors encountered while processing UDP messages.

## How to Use
### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later.
- Ensure port `1514` is available on your machine.

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/madhub/SyslogUdpListener.git
   cd SyslogUdpListener
