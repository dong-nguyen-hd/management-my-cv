namespace MANAGEMENT.MY.CV.BE.Extensions.AddConfig;

public static class RelateExternalFile
{
    public static void AddExternalFile(this ConfigurationManager configuration)
    {
        configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        configuration.AddJsonFile("./ResponseMessage/response-message-vi.json", optional: false, reloadOnChange: true);
        configuration.AddJsonFile("./ResponseMessage/response-message-en.json", optional: false, reloadOnChange: true);
        configuration.AddUserSecrets<Program>(false); // Explicit use secrets.json in env production, staging. By default it only use in development
    }
}