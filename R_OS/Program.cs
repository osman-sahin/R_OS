using Microsoft.EntityFrameworkCore;
using R_OS.Business;
using R_OS.Context;
using R_OS.Models;
using R_OS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AddressBookContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("R_OSContext")));
builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPeopleBusiness, PeopleBusiness>();
builder.Services.AddScoped<IContactInformationBusiness, ContactInformationBusiness>();
builder.Services.AddScoped<IReportBusiness, ReportBusiness>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AddressBookContext>();
//}


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
