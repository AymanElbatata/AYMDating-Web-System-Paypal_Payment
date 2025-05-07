using AYMDating.API.Helpers;
using AYMDating.DAL.Contexts;
using AYMDating.DAL.Interfaces;
using AYMDating.DAL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace AYMDating.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();

            builder.Services.AddDbContext<AYMDatingContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddApplicationServices();

            builder.Services.AddIdentityServices(builder.Configuration);

            //builder.Services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy", policy =>
            //    {
            //        //policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7090");
            //        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7090");
            //        //policy.AllowAnyHeader().AllowAnyMethod().WithOrigins();
            //    });
            //});

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    //policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7090");
                    policy.AllowAnyOrigin().AllowAnyOrigin().AllowAnyOrigin();
                    //policy.AllowAnyHeader().AllowAnyMethod().WithOrigins();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumentaion();

            //builder.Services.AddSwaggerGen();


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            SeedInitialData.SeedData(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(builder.Environment.ContentRootPath, "UserImages")),
            //    RequestPath = "/UserImages"
            //});
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //        app.MapControllers()
            //.RequireAuthorization("ApiScope");

            app.Run();
        }
    }
}