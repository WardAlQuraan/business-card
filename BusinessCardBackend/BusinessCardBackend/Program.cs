using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_CORE;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE;
using BUSINESS_CARD_SERVICE.CommonServices;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();

GlobalAppSettings.AppSettings = appSettings;

builder.Services.AddDbContext<BusinessCardContext>(options =>
    options.UseSqlServer(GlobalAppSettings.AppSettings.BusinessCardConnectionString,
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }
    ));

builder.Services.AddScoped<IBusinessCardRepo , BusinessCardRepo>();
builder.Services.AddScoped<IBusinessCardService , BusinessCardService>();
builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<IXmlService , XmlService>();
builder.Services.AddScoped<IQrCodeService, QrCodeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("businessCardCors",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();


app.UseCors("businessCardCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
