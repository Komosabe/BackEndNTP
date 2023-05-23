using BackEndTutorialNTP.Authorization;
using BackEndTutorialNTP.Helpers;
using BackEndTutorialNTP.Interfaces;
using BackEndTutorialNTP.Seeders;
using BackEndTutorialNTP.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using BackEndTutorialNTP.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FamilyDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("BackEndTutorialNTP")));//

builder.Services.AddCors();
builder.Services.AddControllers();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();

builder.Services.AddScoped<FamilyMemberSeeder>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

//Add configure of seeder
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<FamilyMemberSeeder>();
await seeder.Seed();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
//app.Run("http://localhost:4000");
