using IGapi.Context;
using IGapi.Controllers;
using IGapi.Repositories;
using IGapi.Services;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddScoped<CandidateRepository>();
builder.Services.AddScoped<CandidateService>();
builder.Services.AddScoped<CandidateController>();
builder.Services.AddScoped<Offer_ApplicationRepository>();
builder.Services.AddScoped<Offer_ApplicationService>();
builder.Services.AddScoped<Offer_ApplicationController>();
builder.Services.AddScoped<OfferController>();
builder.Services.AddScoped<OfferService>();
builder.Services.AddScoped<OfferRepository>();








// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.BuildServiceProvider().GetService<ApplicationDBContext>().Database.Migrate();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
