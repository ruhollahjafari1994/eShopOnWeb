using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(current =>
{
	// **************************************************
	// Set the comments path for the Swagger JSON and UI.
	// File Name: Application.xml
	var xmlFile =
		$"{ System.Reflection.Assembly.GetExecutingAssembly().GetName().Name }.xml";

	var xmlPathName =
		System.IO.Path.Combine(System.AppContext.BaseDirectory, xmlFile);

	current.IncludeXmlComments(filePath: xmlPathName);
	// **************************************************

	current.SwaggerDoc
		(name: "v1",
		info: new Microsoft.OpenApi.Models.OpenApiInfo
		{
			Version = "v1",
			Title = "Application",

			Description = "My Description",

			TermsOfService =
				new System.Uri("https://DTApp.ir/"),

			Contact = new Microsoft.OpenApi.Models.OpenApiContact
			{
				Name = "Ruhollah Jafari",
				Email = "jruhollah@gmail.com",
				Url = new System.Uri("https://www.linkedin.com/in/ruhollah-jafari/"),
			},

			License = new Microsoft.OpenApi.Models.OpenApiLicense
			{
				Name = "Use under MIT",
				Url = new System.Uri("https://blog.georgekosmidis.net/privacy-policy/"),
			},
		});
});
// **************************************************
builder.Services.AddTransient
	<Microsoft.AspNetCore.Http.IHttpContextAccessor,
	Microsoft.AspNetCore.Http.HttpContextAccessor>();

builder.Services.AddTransient
	(serviceType: typeof(Dtat.Logging.ILogger<>),
	implementationType: typeof(Dtat.Logging.NLogAdapter<>));
// **************************************************

// **************************************************
builder.Services.AddTransient<Persistence.DatabaseContext>();
// **************************************************

// **************************************************
// using MediatR;
//services.AddMediatR(typeof(Startup));

// using System.Reflection;
builder.Services.AddMediatR(typeof
	(Application.Users.EventHandlers.UserPasswordChangedEventHandler)
	.GetTypeInfo().Assembly);
// **************************************************

// **************************************************
builder.Services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>();
// **************************************************
IConfiguration Configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
							.Build(); ;

// **************************************************
builder.Services.AddDbContext<Persistence.DatabaseContext>(options =>
{
	options.UseSqlServer(Configuration["Database:ConnectionString"]);
});
// **************************************************

// **************************************************
// **************************************************
// **************************************************
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});