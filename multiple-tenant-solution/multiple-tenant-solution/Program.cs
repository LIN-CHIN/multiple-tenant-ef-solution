using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using multiple_tenant_solution;
using multiple_tenant_solution.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSettings = builder.Configuration.GetSection("ApiSettings")
    .Get<ApiSettings>(c => c.BindNonPublicProperties = true);

// inject services 
builder.Services.AddSingleton(appSettings);
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(
            appSettings.ConnectionString, 
            dbContext => dbContext.MigrationsHistoryTable(HistoryRepository.DefaultTableName,"app_main_schema")));

var app = builder.Build();

//db migrate
using (var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
