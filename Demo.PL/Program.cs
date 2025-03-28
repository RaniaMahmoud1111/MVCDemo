using Demo.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{// hi we not have start up  (from .net 6)that had 2 methods(1.configure : that contain middle wares    2.configure services: register  things that run using DI )configurations to build kestrel
    // 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // this instead of the configer services in startup
            #region Configur Services (that run using DI)

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //  builder.Services.AddSingleton<AppDbContext>();
            // builder.Services.AddScoped<AppDbContext>(); 
            //   builder.Services.AddTransient<AppDbContext>();


            #endregion
            // action delegate  has no return  take one parameter 

            builder.Services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            
            });// here you register both AppDbcontext , dbContextOptions
          


            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            #region   configure middel waires 

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");// this appear if you not in dev env
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();// to check your request is secure 
            }

            app.UseHttpsRedirection();// redirect your request to https if you use http 
            app.UseStaticFiles();// if i send (css, js ,..) files which exists in wwwroot 

            app.UseRouting();//take your url and compairs it to its routing table

            #region   Cratical Questions 
            // ordering of middel waire is important ???
            // yes but ,not in many cases 
            // if thing depends on another so here ordering is important 


            /* here  ordering not matter 
                app.UseRouting();
                app.UseStaticFiles();
             */

            /* here the ordering is important (in security module )
                app.UseAuthentication();// who you are ?
                app.UseAuthorization();// what roles you can do?
             */

            #endregion
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
#endregion

            app.Run();


        }
    }
}
