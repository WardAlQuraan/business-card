using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BusinessCardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessCardConnectionString"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }
    ));

builder.Services.AddScoped<IBusinessCardRepo , BusinessCardRepo>();
builder.Services.AddScoped<IBusinessCardService , BusinessCardService>();
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

app.UseCors("businessCardCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
