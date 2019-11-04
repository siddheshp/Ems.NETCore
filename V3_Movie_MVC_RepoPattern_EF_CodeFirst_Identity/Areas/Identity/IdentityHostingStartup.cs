using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Data;

[assembly: HostingStartup(typeof(V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Areas.Identity.IdentityHostingStartup))]
namespace V3_Movie_MVC_RepoPattern_EF_CodeFirst_Identity.Areas.Identity
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