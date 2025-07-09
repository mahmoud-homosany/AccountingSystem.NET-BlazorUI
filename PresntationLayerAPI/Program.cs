
using ApplicationLayer.Contract;
using ApplicationLayer.Mapper;
using ApplicationLayer.Services;
using EContext.Models;
using InfrastructureLayer;
using Microsoft.EntityFrameworkCore;

namespace PresntationLayerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TContext>(option => option.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(typeof(Mapperr));
            ///// 
            builder.Services.AddScoped<IAccReposatiry, AccRepo>();
            builder.Services.AddScoped<IAccService, AccService>();

            builder.Services.AddScoped<ISubAccReposatiry, SubAccRepo>();
            builder.Services.AddScoped<ISubAccService, SubAccService>();

            builder.Services.AddScoped<IJvReposatiry, JVRepo>();
            builder.Services.AddScoped<IJvService, JVService>();

            builder.Services.AddScoped<IJVDetailsReposatiry, JVDetailsRepo>();
            builder.Services.AddScoped<IJVDetailsService, JVDetailsService>(); 


            builder.Services.AddScoped<IJVTypesReposatiry, JVTypesRepo>();
            builder.Services.AddScoped<IJvTypesService, JvTypesService>();

            builder.Services.AddScoped<ISubAccTypeService, SubAccTypeService>();
            builder.Services.AddScoped<ISubAccType, SubAccTypeRepo>();

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Employee API",
                    Version = "v1",
                    Description = "API for Jv Management"

                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API v1");
                    c.RoutePrefix = "swagger";
                });
            }
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
