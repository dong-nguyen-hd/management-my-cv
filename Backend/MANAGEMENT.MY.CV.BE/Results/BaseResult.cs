using System.Text.Json.Serialization;

namespace MANAGEMENT.MY.CV.BE.Results;

public class BaseResult<T>
{
    #region Properties

    [JsonPropertyName("data")]
    public T? Data { get; init; }

    [JsonIgnore]
    [JsonPropertyName("status")]
    public CodeMessage CodeMessage { get; init; }

    [JsonPropertyName("statusCode")]
    public string? StatusCode
    {
        get => GetElementNameCodeMessage(CodeMessage);
    }

    [JsonPropertyName("message")]
    public string? Message
    {
        get => _message;
        init => _message = GetMessage(value);
    }

    private string? _message;

    [JsonPropertyName("languageType")]
    public MyEnum.LanguageType LanguageType { get; set; }

    #endregion

    #region Constructor

    public BaseResult()
    {
    }

    public BaseResult(CodeMessage codeMessage, string? message = "", MyEnum.LanguageType lang = MyEnum.LanguageType.En)
    {
        this.Data = default(T);
        this.CodeMessage = codeMessage;
        this.Message = message ?? string.Empty;
        this.LanguageType = lang;
    }

    #endregion

    #region Method

    private string? GetMessage(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            if (LanguageType == MyEnum.LanguageType.Vi && ResponseMessage.ViValues != null)
                return ResponseMessage.ViValues.TryGetValue(StatusCode ?? string.Empty, out var value) ? value : string.Empty;

            if (ResponseMessage.EnValues != null)
                return ResponseMessage.EnValues.TryGetValue(StatusCode ?? string.Empty, out var value) ? value : string.Empty;
        }

        return input.RemoveSpaceCharacter();
    }

    private static string? GetElementNameCodeMessage(CodeMessage statusCode) =>
        Enum.GetName(typeof(CodeMessage), statusCode)?.TrimStart('_');

    #endregion
}