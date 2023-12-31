	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddControllersWithViews();

	

	builder.Services.AddCors(options =>
	{
	   options.AddPolicy("AllowAngularDev",
	           builder =>
		         {
			         builder.WithOrigins("http://localhost:4200")
				                  .AllowAnyMethod()
					              .AllowAnyHeader();
	             });
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}



app.UseHttpsRedirection();
	app.UseStaticFiles();

	app.UseCors("AllowAngularDev");

	app.UseRouting();
	app.UseAuthorization();

	app.UseEndpoints(endpoints =>
	{
        endpoints.MapControllers();
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapFallbackToController("Index", "Home");
    });

	app.Run();
