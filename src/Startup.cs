using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

public class Startup
{
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
			app.UseDeveloperExceptionPage();

		var fileProvider = new PhysicalFileProvider(env.ContentRootPath);

		app.UseStaticFiles(new StaticFileOptions
		{
			FileProvider = fileProvider,
			ServeUnknownFileTypes = true
		});

		app.UseDirectoryBrowser(new DirectoryBrowserOptions
		{
			FileProvider = fileProvider
		});

		app.Run(context =>
		{
			context.Response.StatusCode = StatusCodes.Status404NotFound;
			return Task.CompletedTask;
		});
	}
}