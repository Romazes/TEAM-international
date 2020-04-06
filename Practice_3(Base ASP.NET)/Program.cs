using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Practice_3_Base_ASP.NET_.Models;

namespace Practice_3_Base_ASP.NET_
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(collection =>
                {
                    collection.AddSingleton<IProductsService, ProductsService>();
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
                    collection.AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc(options => options.EnableEndpointRouting = false)
                    .AddRazorRuntimeCompilation();

                })
                .Configure(builder =>
                {
                    builder.UseHsts().UseDeveloperExceptionPage().UseHttpsRedirection().UseCookiePolicy().UseAuthentication()
                           .UseStaticFiles().UseStaticFiles().UseResponseCaching().
                           UseStatusCodePagesWithReExecute("/error", "?code={0}").UseMvcWithDefaultRoute();
                })
                .UseKestrel(t => t.AddServerHeader = false).Build().RunAsync();
        }
    }
}
