using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x=>
{
    x.Password.RequireUppercase=false;          // ÞÝFRE ÝÇÝN ZORUNLULUKLARI KALDIRDIK.
    x.Password.RequireNonAlphanumeric=false;
})
    .AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMvc(config =>
{
   var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                   .Build();
   config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
builder.Services.AddControllers();



builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
    );
builder.Services.AddHttpClient();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.LoginPath = "/Login/Index";
//    options.SlidingExpiration = true;
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectDemo v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(

    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(

    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
    endpoints.MapRazorPages();

});




app.Run();
