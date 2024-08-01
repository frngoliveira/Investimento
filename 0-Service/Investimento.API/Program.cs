using Investimento.Application._1._4_SeedWork;
using Investimento.Infra._3._1_Context;
using Investimento.Infra.CrossCutting.Ioc;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Http;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.RegisterServices();

        var apiUrl = builder.Configuration["Chaves:apiUrl"];
        var testKey = builder.Configuration["Chaves:testKey"];

        builder.Services.AddCors(options =>
        {
            string allowedHosts =
                builder.Configuration.GetSection(key: "CorsSettings:AllowedHosts").Value ?? string.Empty;

            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });

        builder.Services.AddAutoMapper(typeof(AutomapperConfig));

        builder.Services.AddDbContext<InvestimentoContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));       

        builder.Services.AddHttpClient("ApiClient", client =>
        {            
            client.BaseAddress = new Uri($"{apiUrl}");
            client.DefaultRequestHeaders.Add("X-Test-Key", $"{testKey}");
            HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));
        });

        builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Investimento.API", Version = "v1" }));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseCors();

        app.MapControllers();

        app.Run();       
    }
}