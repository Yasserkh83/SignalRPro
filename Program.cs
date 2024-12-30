
using SignalRPro.HubServices;
using SignalRPro.SignalRHubs;
using Microsoft.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();  // SignalR zufügen.
builder.Services.AddSingleton<HubService>();
////builder.Services.AddCors(options =>  // ####### Wichtig um Seite richtig zu funktioniert ####### Kommt von GBT
////{
////    options.AddPolicy("AllowSpecificOrigin",
////        builder =>
////        {
////            builder.WithOrigins("https://localhost:7241")
////                   .AllowAnyHeader()
////                   .AllowAnyMethod()
////                   .AllowCredentials();
////        });
////});

var app = builder.Build();
////app.UseCors("AllowSpecificOrigin");  // ####### Wichtig um Seite richtig zu funktioniert #######  Kommt von GBT

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

if (app.Environment.IsDevelopment())    // Dies kommt von youtube  M 28.
{
    app.UseCors(policy =>
    {
        policy.WithOrigins("https://localhost:7241")
        .AllowAnyMethod().AllowAnyHeader().WithHeaders(HeaderNames.ContentType);
    });
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRConnectionHub>("/connect"); // für die Roating
app.Run();
