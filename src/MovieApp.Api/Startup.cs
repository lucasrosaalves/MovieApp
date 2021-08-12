using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieApp.Core.Domain.Repositories;
using MovieApp.Core.UseCases.Commands;
using MovieApp.Core.UseCases.Queries;
using MovieApp.Infra.Db;
using MovieApp.Infra.Repositories;

namespace MovieApp.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieApp.Api", Version = "v1" });
            });

            services.AddSingleton<DbContext>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddTransient<CreateActorCommand>();
            services.AddTransient<CreateCategoryCommand>();
            services.AddTransient<CreateMovieCommand>();
            services.AddTransient<DeleteActorCommand>();
            services.AddTransient<DeleteCategoryCommand>();
            services.AddTransient<DeleteMovieCommand>();

            services.AddTransient<GetActorByIdQuery>();
            services.AddTransient<GetActorsQuery>();
            services.AddTransient<GetCategoriesQuery>();
            services.AddTransient<GetCategoryByIdQuery>();
            services.AddTransient<GetMovieByIdQuery>();
            services.AddTransient<GetMoviesQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApp.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
