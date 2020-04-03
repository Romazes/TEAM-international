using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Practice_3_Base_ASP.NET_
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(collection =>
                {
                    //HTTP Strict Transport Security Protocol (HSTS) - for Header of webp-page
                    collection.AddHsts(options =>
                    {
                        options.Preload = true;
                        options.IncludeSubDomains = true;
                        options.MaxAge = TimeSpan.FromDays(365);
                    })
                    .AddHttpsRedirection(options =>
                    {
                        options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                        options.HttpsPort = 8888;
                    })
                    .Configure<CookiePolicyOptions>(options =>
                    {
                        //Cookies must be Secure(Always)
                        options.Secure = CookieSecurePolicy.Always;
                        //Ask from users about cookies?
                        options.CheckConsentNeeded = context => true;
                        //Cookies will sent only about link
                        options.MinimumSameSitePolicy = SameSiteMode.Strict;
                    });
                    //Need when add system of authorization
                    //.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    //.AddCookie(options =>
                    //{
                    //    options.Cookie.Name = "Ramzes.Cookies";
                    //    options.LoginPath = new PathString(""); //!!!                 
                    //});
                    collection.AddAntiforgery(options =>
                    {
                        options.Cookie.Name = "RamzesAntiForgeryField";
                        options.HeaderName = "Ramzes-simply-token";
                    })
                    //AddResponseCompression()
                    .AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc(options => options.EnableEndpointRouting = false)
                    .AddRazorRuntimeCompilation();

                })
                .Configure(builder =>
                {
                    builder.UseHsts().UseHttpsRedirection().UseCookiePolicy().UseAuthentication()
                           .UseStaticFiles().UseStaticFiles().UseResponseCaching().
                           UseStatusCodePagesWithReExecute("/error", "?code={0}").UseMvcWithDefaultRoute();
                })
                .UseKestrel(t => t.AddServerHeader = false).Build().RunAsync();

            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
