using Microsoft.EntityFrameworkCore;
using ScurityApp.BLL.Services;
using ScurityApp.DAL;
using ScurityApp.DAL.Repositories;
using ScurityApp.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AppConfig = builder.Configuration;

IConfigurationSection configuration = AppConfig.GetSection("ConnectionStrings");
string connectionString = configuration.GetSection("Data").Value;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddAutoMapper(typeof(MiscProfile));
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<WorkScheduleRepository>();
builder.Services.AddScoped<ShiftRepository>();
builder.Services.AddScoped<SecurityObjectRepository>();

builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<WorkScheduleService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<SecurityObjectService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

}
    app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
