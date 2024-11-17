namespace MANAGEMENT.MY.CV.BE.Resources.Attribute;

/// <summary>
/// Role: remove sensitve data in DTO
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class SensitiveDataAttribute() : System.Attribute
{
}