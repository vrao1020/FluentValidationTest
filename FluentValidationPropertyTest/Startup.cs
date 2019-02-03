using FluentValidation.AspNetCore;
using FluentValidationPropertyTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationPropertyTest
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IFileValidate, FileValidate>();

            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    //add fluent validation
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = true;
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();

                    //below call is required to validate model state of actions that take in 
                    //IEnumerable of the models/dtos that need to be validated
                    //if not added, IEnumerable models/dtos will not be validated
                    fv.ImplicitlyValidateChildProperties = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
