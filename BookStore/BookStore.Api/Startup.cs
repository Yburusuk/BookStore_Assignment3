using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper;
using MediatR;
using BookStore.Business.Cqrs;
using BookStore.Business.Mapper;
using BookStore.Data.Context;
using BookStore.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BookStore;

public class Startup
{
    public IConfiguration Configuration;
    
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }
    
    
    public void ConfigureServices(IServiceCollection services)
    {
               
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.Api", Version = "v1" });
        });

        var connectionString = Configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MapperConfig());
        });
        
        services.AddSingleton(config.CreateMapper());
        
        services.AddMediatR(typeof(GetAllBookQuery).GetTypeInfo().Assembly);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.Api v1"));
        }
      
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}