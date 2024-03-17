
using Microsoft.EntityFrameworkCore;
using ShopperStopInReact_Shared.Constants;
using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.IRepository.ICustomerRepository;
using ShopperStopInReact_Shared.OTPGenerate;
using ShopperStopInReact_Shared.Repositoy.AdminRepository;
using ShopperStopInReact_Shared.Repositoy.CustomerRepository;

namespace ShopperStopInReactInReactInReact.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICartAndWishListRepository, CartAndWishListRepository>();
            builder.Services.AddScoped<IAdminDetailsRepository, AdminDetailsRepository>();
            builder.Services.AddScoped<GenerateOTP>();
            builder.Services.AddScoped<CategoryLists>();
            var ShoppingDBContext = builder.Configuration["ShoppingDbContext:ConnectionString"];
            builder.Services.AddDbContext<ShoppingDbContext>(options => options.UseSqlServer(ShoppingDBContext));
            // Other configurations...
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigins");

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
