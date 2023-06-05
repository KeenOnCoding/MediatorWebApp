using MediatorWebApp.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString, 
        x => x.MigrationsAssembly("MediatorWebApp")));

builder.Services.AddDapper(connectionString);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddMediatR(typeof(IHandler).Assembly);

builder.Services.AddControllers();

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

//app.MigrateDatabase();

app.Run();

public static class Exten
{
    public static IServiceCollection AddDapper(this IServiceCollection services, string? connectionString)
    {

        return services.AddSingleton(x => ActivatorUtilities.CreateInstance<DapperContext>(x, connectionString));
    }
}

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                try
                {
                    if (!appContext.Users.Any())
                    {
                        appContext.Database.Migrate();
                    }

                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
        return webApp;
    }
}