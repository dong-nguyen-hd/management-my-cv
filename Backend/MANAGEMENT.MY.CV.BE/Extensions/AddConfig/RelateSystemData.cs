namespace MANAGEMENT.MY.CV.BE.Extensions.AddConfig;

public static class RelateSystemData
{
    /// <summary>
    /// Role: retrieve configuration data for the system
    /// </summary>
    /// <param name="configuration"></param>
    public static void GetSystemData(this IConfiguration configuration)
    {
        SystemGlobal.AppConnectionString = configuration.GetConnectionString("AppConnection");
        configuration.GetSection(nameof(SystemInformation)).Get<SystemInformation>(x => x.BindNonPublicProperties = true);
        configuration.GetSection(nameof(CacheConfig)).Get<CacheConfig>(x => x.BindNonPublicProperties = true);
        configuration.GetSection(nameof(SerilogConfig)).Get<SerilogConfig>(x => x.BindNonPublicProperties = true);
        configuration.GetSection(nameof(ResponseMessage)).Get<ResponseMessage>(x => x.BindNonPublicProperties = true);
    }
}