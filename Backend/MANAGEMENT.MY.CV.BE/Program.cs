using System.Text;
using System.Text.Json;
using MANAGEMENT.MY.CV.BE.Controllers.Config;
using MANAGEMENT.MY.CV.BE.Domain.Contexts;
using MANAGEMENT.MY.CV.BE.Extensions.AddConfig;
using MANAGEMENT.MY.CV.BE.Extensions.JsonConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Serilog;

const string _hostingSourceContext = "Microsoft.Hosting.Lifetime";

try
{
    Console.OutputEncoding = Encoding.UTF8;

    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddExternalFile();
    SystemGlobal.IsDebug = builder.Environment.IsDevelopment();
    builder.Configuration.GetSystemData();

    // Declare log
    builder.Services.AddLog(builder.Configuration);
    _hostingSourceContext.LogWithContext().Information("Starting up");
    builder.Host.UseSerilog();

    // Force convert dateTime with kind in PostgreSQL
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    #region Add services to the container.

    builder.Services.ApplyTimeoutProfile();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddControllers(opt =>
    {
        opt.ApplyCacheProfile(); // Add custom cache profile
    }).ConfigureApiBehaviorOptions(options =>
    {
        // Adds a custom error response factory when Model-State is invalid
        options.InvalidModelStateResponseFactory = InvalidResponseFactory.ProduceErrorResponse;
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new MyDateTimeConverter());
    });

    // Add redis / mem cache
    if (CacheConfig.UseRedis)
    {
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = CacheConfig.RedisUri;
            options.InstanceName = CacheConfig.RedisInstanceName;
        });
    }
    else
    {
        builder.Services.AddDistributedMemoryCache();
    }

    builder.Services.AddResponseCaching();
    builder.Services.AddOpenApi();
    builder.Services.AddDbContext<CoreContext>(opts =>
    {
        opts.UseNpgsql(SystemGlobal.AppConnectionString, o =>
        {
            o.EnableRetryOnFailure();

            if (SystemGlobal.IsDebug)
            {
                opts.EnableDetailedErrors();
                opts.EnableSensitiveDataLogging();
            }
        });
    });

    builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });
    //builder.Services.AddDependencyInjection(builder.Configuration);
    builder.Services.AddCors(options => { options.AddPolicy("AllowAll", x => { x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });

    #endregion

    #region Configure the HTTP request pipeline.

    var app = builder.Build();
    app.UseStaticFiles(new StaticFileOptions
    {
        RequestPath = "/resources",
        HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
        OnPrepareResponse = (context) =>
        {
            var headers = context.Context.Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromHours(1)
            };
        }
    });

    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        // app.UseSwagger();
        // app.UseSwaggerUI();
        // app.UseHangfireDashboard();
    }

    app.MapOpenApi();
    app.UseResponseCompression();
    app.UseSerilogRequestLogging();
    if (app.Environment.IsProduction())
        app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseRouting();
    app.UseResponseCaching();
    app.UseRequestTimeouts();
    // app.UseMiddleware<LoggerMiddleware>();
    // app.UseMiddleware<ErrorHandlerMiddleware>();
    app.Use((context, next) => // No-caching explicit
    {
        context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
        {
            NoCache = true,
            NoStore = true
        };
        return next.Invoke();
    });
    // app.MapHealthCheck();
    app.MapControllers();
    app.Run();

    #endregion
}
catch (Exception ex)
{
    if (ex is HostAbortedException) // Ex throw by ef-core when migration
        return;

    _hostingSourceContext.LogWithContext().Fatal($"Unhandled exception: {ex.Message}", ex);
}
finally
{
    _hostingSourceContext.LogWithContext().Information("Shut down complete");
    Log.CloseAndFlush();
}