using Microsoft.EntityFrameworkCore;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<libraryDBContext>(options =>
{
    var connStr = builder.Configuration["ConnectionStrings:DefaultConnection"];
    options.UseNpgsql(connStr);

}

);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IuserRepository, EfuserRepository>();
builder.Services.AddScoped<ImesajRepository, EfmesajRepository>();
builder.Services.AddScoped<IpuanRepository, EfpuanRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
