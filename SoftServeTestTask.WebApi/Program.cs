using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using SoftServeTestTask.WebApi.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEntityFrameworkCore(builder.Configuration);

builder.Services.AddAutopMapperProfilesFromAssembly("SoftServeTestTask.BLL");
builder.Services.AddGenericRepository();

builder.Services.AddGlobalExceptionHandlerMiddleware();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidationBehaviours();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("SoftServeTestTask.BLL"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("SoftServeTestTask.BLL")));

builder.Services.AddProgramServices();

builder.Services.AddJwtAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionHandlerMiddleware();

app.Run();
