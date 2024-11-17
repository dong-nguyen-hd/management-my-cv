namespace MANAGEMENT.MY.CV.BE.Resources.SystemData;

public sealed class ResponseMessage
{
    public static Dictionary<string, string>? ViValues { get; private set; }
    public static Dictionary<string, string>? EnValues { get; private set; }
}

public enum CodeMessage
{
    _99,
    _100,
    _101,
}