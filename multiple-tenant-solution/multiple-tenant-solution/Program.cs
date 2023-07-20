using Microsoft.EntityFrameworkCore;
using multiple_tenant_solution;
using multiple_tenant_solution.Context;
using multiple_tenant_solution.DAOs.Material;
using multiple_tenant_solution.DAOs.User;
using multiple_tenant_solution.ExternalServices.Tenant;
using multiple_tenant_solution.Services.Material;
using multiple_tenant_solution.Services.User;

var builder = WebApplication.CreateBuilder(args);

try
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Configuration.AddEnvironmentVariables();
    builder.Services.AddHttpClient();

    var apiSettings = builder.Configuration.GetSection("ApiSettings")
        .Get<ApiSettings>(c => c.BindNonPublicProperties = true);

    var tenantServiceConfigs = builder.Configuration.GetSection("TenantServiceConfigs")
        .Get<TenantServiceConfigs>(c => c.BindNonPublicProperties = true);

    // inject services 
    builder.Services.AddSingleton(apiSettings);
    builder.Services.AddSingleton(tenantServiceConfigs);
    builder.Services.AddScoped<CurrentUserInfo>();
    builder.Services.AddDbContext<DataContext>();
    builder.Services.AddTransient<IMaterialService, MaterialService>();
    builder.Services.AddTransient<IMaterialDAO, MaterialDAO>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IUserDAO, UserDAO>();

    // inject external services 
    builder.Services.AddTransient<ITenantExternalService, TenantExternalService>();

    var app = builder.Build();

    app.UseExceptionHandler("/api/Error");

    //db migrate
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate();
    }

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex) 
{
    Console.WriteLine(ex.ToString());
    throw ex;
}