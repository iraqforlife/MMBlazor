using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
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
            services.AddControllers();
            /*
            if(env.IsDevelopment())
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            else
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DeployementConnection")));

            services.AddIdentity<Account, IdentityRole>(options => { options.User.AllowedUserNameCharacters = String.Empty; options.User.RequireUniqueEmail = true; }).AddEntityFrameworkStores<AppDbContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            var google = Configuration.GetSection("Google");*/
            /*services.AddAuthentication().AddGoogle(o =>
            {
                o.ClientId = google["ClientId"];
                o.ClientSecret = google["ClientSecret"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy => policy.RequireRole(Roles.Admin));
                options.AddPolicy("PaidAccess", policy =>
                    policy.RequireAssertion(context =>
                                context.User.IsInRole(Roles.Admin)
                                || context.User.IsInRole(Roles.PaidUser)));
            });
            */
            // Add Cors
            services.AddCors(o => o.AddPolicy("Policy", builder => {
                builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("Policy");
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
