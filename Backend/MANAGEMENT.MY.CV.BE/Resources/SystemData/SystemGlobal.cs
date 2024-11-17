namespace MANAGEMENT.MY.CV.BE.Resources.SystemData;

public static class SystemGlobal
{
    #region AppConnectionString

    private static string? _appConnectionString;

    public static string? AppConnectionString
    {
        get => _appConnectionString;
        set => SetPostgresqlConnectionString(value);
    }

    private static void SetPostgresqlConnectionString(string? value)
    {
        if (!string.IsNullOrEmpty(_appConnectionString))
            throw new InvalidOperationException();

        if (string.IsNullOrEmpty(_appConnectionString) && !string.IsNullOrEmpty(value))
            _appConnectionString = value;
    }

    #endregion

    #region IsDebug

    private static bool? _isDebug;

    public static bool IsDebug
    {
        get => _isDebug ?? false;
        set => SetIsDebug(value);
    }

    private static void SetIsDebug(bool value)
    {
        if (_isDebug != null)
            throw new InvalidOperationException();

        _isDebug ??= value;
    }

    #endregion

    public const string Masked = "*** Masked ***";
}