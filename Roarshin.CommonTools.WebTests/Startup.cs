using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Roarshin.CommonTools.DependencyInjection;
using Roarshin.CommonTools.WebTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roarshin.CommonTools.Database;

namespace Roarshin.CommonTools.WebTests {
    
    public class Startup {
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            // dependency injection for our common tools
            services.AddRoarshinCommonTools(cfg => {
                
                cfg.AddDataProvider(DataProviders.MySql, config => {
                    config.WithConfiguration(Configuration);
                });
                
                cfg.AddProfileIconProvider(() => new CustomProfileIconProvider());
            });

            // setup controllers & add swagger so we can run tests directly from the browser
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roarshin.CommonTools.WebTests", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roarshin.CommonTools.WebTests v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
    }
}
