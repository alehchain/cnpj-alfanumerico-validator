namespace CnpjAlfanumericoValidator;

/// <summary>
/// Extensões de conveniência para CNPJ.
/// </summary>
public static class CnpjExtensions
{
    public static bool IsValidCnpj(this string? value) => CnpjValidator.IsValid(value);

    public static string ToCnpjFormat(this string value) => CnpjFormatter.Format(value);
}
