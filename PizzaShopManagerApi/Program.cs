using Microsoft.EntityFrameworkCore;

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

        // https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
