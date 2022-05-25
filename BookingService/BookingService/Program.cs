using BookingService.Data;
using BookingService.Data.Repositories;
using BookingService.Models;
using BookingService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<BookingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<BookingServiceItem, int>, BookingServiceRepository>();
builder.Services.AddScoped<ICrudService<BookingServiceItem, int>, BookingServiceService>();
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TodoRestAPI",
        Version =
    "v1"
    });
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();



app.MapControllers();



app.Run();