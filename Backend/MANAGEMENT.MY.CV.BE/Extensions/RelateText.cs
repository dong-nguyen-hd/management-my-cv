using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using IdGen;

namespace MANAGEMENT.MY.CV.BE.Extensions;

public static class RelateText
{
    #region GenId

    private static readonly IdGenerator _genId = new(Random.Shared.Next(0, 1023));

    public static string GenId() => _genId.CreateId().ToString();

    #endregion

    #region My Serialize

    private static JsonSerializerOptions _opt = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static T? MyDeserialize<T>(this string? source)
    {
        if (string.IsNullOrEmpty(source))
            return default;

        return JsonSerializer.Deserialize<T>(source, _opt);
    }

    public static string MySerialize<T>(this T source)
    {
        if (source is null)
            return string.Empty;

        return JsonSerializer.Serialize(source, _opt);
    }

    #endregion

    public static string RemoveSpaceCharacter(this string? text) =>
        string.IsNullOrEmpty(text) ? string.Empty : Regex.Replace(text.Trim(), @"\s{2,}", " ");

    public static string ToLowerAndRemoveSpace(this string? text) =>
        RemoveSpaceCharacter(text).ToLower();

    public static string RemoveAllSpaceChar(this string? text) =>
        string.IsNullOrEmpty(text) ? string.Empty : Regex.Replace(text.Trim(), @"\s+", "");
}