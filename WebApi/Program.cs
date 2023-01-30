using Data.Config;
using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextBase>(options =>
  options.UseSqlServer(
      builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// singletons das interfaces

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>)); 
builder.Services.AddSingleton<IProduct, RepositoryProduct>();


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//           .AddJwtBearer(option =>
//           {
//               option.TokenValidationParameters = new TokenValidationParameters
//               {
//                   ValidateIssuer = false,
//                   ValidateAudience = false,
//                   ValidateLifetime = true,
//                   ValidateIssuerSigningKey = true,

//                   ValidIssuer = "Teste.Securiry.Bearer",
//                   ValidAudience = "Teste.Securiry.Bearer",
//                   IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
//               };

//               option.Events = new JwtBearerEvents
//               {
//                   OnAuthenticationFailed = context =>
//                   {
//                       Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
//                       return Task.CompletedTask;
//                   },
//                   OnTokenValidated = context =>
//                   {
//                       Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
//                       return Task.CompletedTask;
//                   }
//               };
//           });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

