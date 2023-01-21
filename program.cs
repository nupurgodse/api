using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BajajCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));

});
builder.Services.AddScoped<IDataService<Department, int>, DepartmentDataService>();
builder.Services.AddScoped<IDataService<Employee, int>, EmployeeDataService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//swagger documentations
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
