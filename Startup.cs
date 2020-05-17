using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using BlockKing.Detail;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BlockKing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddEntityFrameworkSqlServer();
            services.AddDbContextPool<BlockKingDbContext>(
                //options => options.UseMySql("Server=localhost;port=3306;Database=BlockKing;user=toor;password=7vC=zp#z<mz%DPlC{R+e;",
                options => options.UseMySql(Configuration["ConnectionStrings:mySQLConnectionString"],
                mysqlOptions =>
                {
                    mysqlOptions.ServerVersion(new Version(8, 0, 19), ServerType.MySql);
                    mysqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);
                }));
        }
        /*
            //var connectionString = Configuration.GetConnectionString("mySQLConnectionString");
            //services.AddDbContext<BlockKingDbContext>(options => options.UseMySQL(connectionString));
            services.AddDbContextPool<BlockKingDbContext>((serviceProvider, options) =>
            {
                // replace with your connection string
                options.UseMySql("Server=localhost;port=3306;Database=BlockKing;user=root;password=7vC=zp#z<mz%DPlC{R+e;", mySqlOptions => mySqlOptions
                    // replace with your Server Version and Type
                    .ServerVersion(new Version(8, 0, 18), ServerType.MySql));
                options.UseInternalServiceProvider(serviceProvider);
            });
        }*/
        /*public static void ConfigureEntityFramework(IServiceCollection services)
        {
            services.AddDbContextPool<BlockKingDbContext>(
                options => options.UseMySql("Server=localhost;port=3306;Database=BlockKing;user=root;password=7vC=zp#z<mz%DPlC{R+e;",
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0, 18), ServerType.MySql);
                    }
            ));
        }*/


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
