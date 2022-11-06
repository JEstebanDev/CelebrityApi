using CelebrityAPI.Data;
using CelebrityAPI.Model.Domain;
using CelebrityAPI.Repository;
using CelebrityAPI.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CelebrityAPI
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
            services.AddDbContext<ApplicationDBContext>(dbOptions => dbOptions.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddTransient(typeof(ICrudRepository<Category>), typeof(CategoryRepository));
            services.AddTransient(typeof(ICrudRepository<Profession>), typeof(ProfessionRepository));
            services.AddTransient(typeof(ICrudRepository<SocialMedia>), typeof(SocialMediaRepository));
            services.AddTransient(typeof(ICrudRepository<UserAdmin>), typeof(UserAdminRepository));
            services.AddTransient(typeof(ICrudRepository<User>), typeof(UserRepository));
            services.AddTransient(typeof(ICrudCelebrityRepository), typeof(CelebrityRepository));


            //Adding the swagger
            services.AddControllers();
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Celebrity {groupName}",
                    Version = groupName,
                    Description = "That api give you online famous witch " +
                    "include youtubers instagrams and tiktok fenomens or actress, " +
                    "sport player very unique information. For example net worth, " +
                    "lucy number lucky color, education, weight, height and much more facts.",
                    
                    Contact = new OpenApiContact
                    {
                        Name = "Celebrity API",
                        Email = "castanoesteban9@gmail.com",
                        Url = new Uri("https://jestebandev.netlify.app/"),
                    }
                });
            });
        }
    }
}
