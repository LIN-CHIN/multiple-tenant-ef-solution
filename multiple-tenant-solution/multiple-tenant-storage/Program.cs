using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using multiple_tenant_storage;
using multiple_tenant_storage.Context;
using multiple_tenant_storage.DAOs;
using multiple_tenant_storage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiSettings = builder.Configuration.GetSection("ApiSettings")
    .Get<ApiSettings>(c => c.BindNonPublicProperties = true);

// inject services 
builder.Services.AddSingleton(apiSettings);
builder.Services.AddDbContext<TenantContext>(
    opt => opt.UseNpgsql(
        apiSettings.ConnectionString,
        dbContext => dbContext.MigrationsHistoryTable( 
            HistoryRepository.DefaultTableName,
                    "app_tenant_schema")));

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ITenantDAO, TenantDAO>();

var app = builder.Build();

//db migrate
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TenantContext>();
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
