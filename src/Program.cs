using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

const int DefaultPort = 8080;

var useCustomPort = args.Length == 2 && (args[0].Equals("-p") || args[0].Equals("--port"));
var port = useCustomPort ? int.Parse(args[1]) : GetAvailablePort(DefaultPort);

var hostBuilder = CreateHostBuilder(args, port);

var ps = new ProcessStartInfo($"http://localhost:{port}")
{
	UseShellExecute = true,
	Verb = "open"
};
Process.Start(ps);

hostBuilder.Build().Run();


static IHostBuilder CreateHostBuilder(string[] args, int port)
{
	var rootDir = Directory.GetCurrentDirectory();

	return Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(webBuilder =>
		{
			webBuilder.UseUrls($"http://*:{port}");
			webBuilder.UseContentRoot(rootDir);
			webBuilder.UseStartup<Startup>();
		});
}

static int GetAvailablePort(int initialPort)
{
	while (IsPortInUse(initialPort))
		initialPort++;

	return initialPort;
}

static bool IsPortInUse(int port)
{
	try
	{
		using var tcpClient = new TcpClient();
		tcpClient.Connect("127.0.0.1", port);

		return true;
	}
	catch (Exception)
	{
		return false;
	}
}
