using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace Sample.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new StartOptions();
            options.Urls.Add("http://localhost:8090");
            options.Urls.Add("https://localhost:44301");

            using (WebApp.Start<Startup>(options))
            {
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseForcedHttps(44301);

            app.Run(ctx =>
            {
                ctx.Response.ContentType = "text/plain";
                return ctx.Response.WriteAsync("Hello world");
            });
        }
    }
}
