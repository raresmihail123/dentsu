using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using dentsu.Controller;

namespace dentsu
    
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");
            // Add services to the container.
            // Register SolutionService as a singleton
            builder.Services.AddSingleton<ISolutionService, SolutionService>();

            // Add other services needed by your application
            builder.Services.AddControllers(); // Add support for API controllers

            // Add other services here, e.g., for database context, authentication, etc.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Show detailed error pages in development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Show custom error page in production
                app.UseHsts(); // Enforce HTTPS
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
            app.UseStaticFiles(); // Serve static files from wwwroot

            app.UseRouting(); // Enable routing

            app.UseAuthentication(); // Enable authentication middleware
            app.UseAuthorization(); // Enable authorization middleware

            app.MapControllers(); // Map controller endpoints

            app.Run(); // Start the application
        }
    }
}