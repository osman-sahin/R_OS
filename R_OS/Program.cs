using Microsoft.EntityFrameworkCore;
using R_OS.Business;
using R_OS.Context;
using R_OS.Services;
using MassTransit;
using R_OS.Models;

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
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
    });
});

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

//var bus = Bus.Factory.CreateUsingRabbitMq(config =>
//{
//    config.Host("amqp://guest:guest@localhost:5672");
//    config.ReceiveEndpoint("create-report-queue", c =>
//    {
//        c.Handler<ReportQueueModel>(ctx =>
//        {
//            return Console.Out.WriteLineAsync($"Queued: {ctx.Message.ReportUUID.ToString()}");
//        });
//    });
//});

//bus.Start();

//bus.Publish(new ReportQueueModel { ReportUUID = Guid.NewGuid() });

app.Run();
