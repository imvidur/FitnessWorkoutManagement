using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var jwtval = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtval["SecretKey"]);

builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//authentication
builder.Services.AddAuthentication(i =>
{
    i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(i =>
{
    i.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
}); 


// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFitnessClassRepository, FitnessClassRepository>();
builder.Services.AddScoped<IFitnessClassService, FitnessClassService>();
builder.Services.AddScoped<IChallengeRepository, ChallengeRepository>();
builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();
builder.Services.AddScoped<IMealPlanService, MealPlanService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IWorkoutCategoryRepository, WorkoutCategoryRepository>();
builder.Services.AddScoped<IWorkoutCategoryService, WorkoutCategoryService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<JwtService>();

// Add JWT Authentication
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "FitnessManagement",
//            ValidAudience = "FitnessManagementUsers",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey1234567890098765432112345")),
//            RoleClaimType = "role"
//        };
//        options.Events = new JwtBearerEvents
//        {
//            OnTokenValidated = context =>
//            {
//                Console.WriteLine("Token validated.");
//                var identity = context.Principal.Identity as ClaimsIdentity;
//                var roleClaim = identity?.FindFirst("role");
//                if (roleClaim != null)
//                {
//                    Console.WriteLine($"Role: {roleClaim.Value}");
//                }
//                return Task.CompletedTask;
//            },
//            OnAuthenticationFailed = context =>
//            {
//                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
//                return Task.CompletedTask;
//            }
//        };
//    });

//builder.Services.AddAuthorizationBuilder()
//    .AddPolicy("TrainerOnly", policy => policy.RequireRole("Trainer"))
//    .AddPolicy("NutritionistOnly", policy => policy.RequireRole("Nutritionist"))
//    .AddPolicy("ClientOnly", policy => policy.RequireRole("Client"))
//    .AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

builder.Services.AddAuthorization(i =>
{
    i.AddPolicy("ClientOnly", j => j.RequireRole("Client"));
    i.AddPolicy("All", j => j.RequireRole("Admin", "User"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
