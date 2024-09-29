using Microsoft.EntityFrameworkCore;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("TestOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Replace with your frontend domain
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

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
builder.Services.AddScoped<IcezaRepository, EfcezaRepository>();
builder.Services.AddScoped<IrolRepository, EfrolRepository>();
builder.Services.AddScoped<IhesapAcmaTalebiRepository, EfhesapAcmaTalebiRepository>();
builder.Services.AddScoped<IkitapOduncRepository, EfkitapOduncRepository>();
builder.Services.AddScoped<IkitapRepository, EfkitapRepository>();
builder.Services.AddScoped<IkitapYayinTalebiRepository, EfkitapYayinTalebiRepository>();
builder.Services.AddScoped<IkitapYazariRepository, EfkitapYazariRepository>();
builder.Services.AddScoped<IsayfaRepository, EfsayfaRepository>();

builder.Services.AddControllers();




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TestOrigin");
app.UseHttpsRedirection();

app.Run();
