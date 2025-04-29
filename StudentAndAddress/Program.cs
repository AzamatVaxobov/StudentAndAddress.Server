using Serilog;
using Serilog.Sinks.Telegram;
using StudentAndAddress.Repository.AddressRepository;
using StudentAndAddress.Repository.StudentRepository;
using StudentAndAddress.Server.Configurations;
using StudentAndAddress.Service.AddressService;
using StudentAndAddress.Service.StudentService;

namespace StudentAndAddress;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Telegram
            (
                botToken: "8082585188:AAHXfZmSeJz2ih8WrpVXpG4Xv-NLFxV8i2k",
                chatId: "6448388108",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
            )
            .CreateLogger();

        try
        {
            Log.Information("Dastur ishga tushdi");

            builder.Services.AddControllers();
            builder.Services.AddResponseCaching();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host.UseSerilog();

            // Database configuration
            builder.ConfigureDatabase();

            // Dependency injection
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IAddressService, AddressService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

          
            app.UseAuthorization();

            app.UseResponseCaching();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred during application startup.");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
