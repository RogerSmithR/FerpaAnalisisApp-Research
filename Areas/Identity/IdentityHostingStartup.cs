using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FerpaAnalisisApp.Areas.Identity.IdentityHostingStartup))]
namespace FerpaAnalisisApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}