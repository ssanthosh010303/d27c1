using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using PizzaShopManagerApi.Models;
using PizzaShopManagerApi.Repositories;
using PizzaShopManagerApi.Services;

internal class Program
{
    private static void ConfigureDic(IServiceCollection services)
    {
        services.AddScoped<IRepositoryBase<Pizza>, PizzaRepository>();
        services.AddScoped<IRepositoryBase<Customer>, CustomerRepository>();
        services.AddScoped<IRepositoryBase<Order>, OrderRepository>();
        services.AddScoped<IRepositoryBase<OrderItem>, OrderItemRepository>();

        services.AddScoped<IServiceBase<Pizza>, PizzaService>();
        services.AddScoped<IServiceBase<Customer>, CustomerService>();
        services.AddScoped<IServiceBase<Order>, OrderService>();
        services.AddScoped<IServiceBase<OrderItem>, OrderItemService>();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString(
                "Development"
            ), ServerVersion.AutoDetect(
                builder.Configuration.GetConnectionString("Development")
            ));
        });
        ConfigureDic(builder.Services);

        // Scan Referenced Assembiles for Profiles
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddControllers();

        // JWT-based Authentication
        builder.Services.AddAuthentication(options => {
            // Set Bearer Auth
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        builder.Configuration["Jwt:SigningKey"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true

            };
        });
        builder.Services.AddAuthorization();

        // https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
