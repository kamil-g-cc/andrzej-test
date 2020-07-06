using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestShop.Areas.Identity.Data;
using QuestShop.Data;

[assembly: HostingStartup(typeof(QuestShop.Areas.Identity.IdentityHostingStartup))]
namespace QuestShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuestShopDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuestShopDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<QuestShopDbContext>();
            });
        }
    }
}