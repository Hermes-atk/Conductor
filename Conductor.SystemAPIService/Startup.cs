using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Conductor.Common;
using Microsoft.IdentityModel.Tokens;

namespace Conductor.SystemAPIService
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
          
            //校验AccessToken,从身份校验中心(ID4Test)进行校验
            services.AddAuthentication("Bearer")  //Bear模式
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "http://127.0.0.1:9500"; // 1、授权中心地址
                        options.ApiName = "Conductor.SystemAPIService"; // 2、api名称(项目具体名称)
                        options.RequireHttpsMetadata = false; // 3、https元数据，不需要
                    });
            services.AddControllers();

            // services.AddAuthentication("Bearer")
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "https://localhost:9501";

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false
            //    };
            //});
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", option =>
            //    {
            //        option.Authority = "https://localhost:9501";
            //        option.Audience = "api1";

            //        //是否必需HTTPS
            //        //option.RequireHttpsMetadata = false;
            //    });
            //.AddIdentityServerAuthentication(op =>
            //{
            //    op.Authority = "http://localhost:9500";
            //    op.RequireHttpsMetadata = false;
            //    op.ApiName = "api1";  //api的name，需要和config的名称相同
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(name: "default", pattern: "{controller=System}/{action=Get}/{id?}");
            });

            //app.RegisterConsul(Configuration, lifetime);
        }
    }
}
