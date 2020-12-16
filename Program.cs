using System;
using System.IO;
using System.Net.Sockets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
	public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

	static IHostBuilder CreateHostBuilder(string[] args)
	{
		var port = 8080;

		while (IsPortInUse(port))
			port++;

		return Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseUrls($"http://*:{port}");
				webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
				webBuilder.UseStartup<Startup>();
			});
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
}