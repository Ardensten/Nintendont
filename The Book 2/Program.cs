using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using The_Book_2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("The_Book_2ContextConnection") ?? throw new InvalidOperationException("Connection string 'The_Book_2ContextConnection' not found.");

builder.Services.AddDbContext<The_Book_2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<The_Book_2.Areas.Identity.Data.The_Book_2User>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<The_Book_2Context>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
