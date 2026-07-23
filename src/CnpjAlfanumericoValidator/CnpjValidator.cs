using System.Text.RegularExpressions;

namespace CnpjAlfanumericoValidator;

/// <summary>
/// Valida inscrições de CNPJ numéricas e alfanuméricas.
/// </summary>
public static class CnpjValidator
{
    private static readonly int[] FirstDigitWeights = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    private static readonly int[] SecondDigitWeights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    private static readonly Regex AllowedCharacters = new("^[A-Z0-9]{12}[0-9]{2}$", RegexOptions.Compiled);

    /// <summary>
    /// Verifica se o CNPJ informado possui formato e dígitos verificadores válidos.
    /// </summary>
    public static bool IsValid(string? cnpj)
    {
        string normalized = CnpjFormatter.RemoveMask(cnpj);

        if (normalized.Length != 14 || !AllowedCharacters.IsMatch(normalized))
        {
            return false;
        }

        if (normalized.All(character => character == normalized[0]))
        {
            return false;
        }

        string baseCnpj = normalized[..12];
        return normalized.EndsWith(CalculateCheckDigits(baseCnpj), StringComparison.Ordinal);
    }

    /// <summary>
    /// Calcula os dois dígitos verificadores para uma base com 12 caracteres.
    /// </summary>
    /// <exception cref="ArgumentException">A base não possui exatamente 12 letras ou números.</exception>
    public static string CalculateCheckDigits(string baseCnpj)
    {
        string normalized = CnpjFormatter.RemoveMask(baseCnpj);

        if (normalized.Length != 12 || normalized.Any(character => !char.IsAsciiLetterOrDigit(character)))
        {
            throw new ArgumentException("A base do CNPJ deve conter exatamente 12 caracteres alfanuméricos.", nameof(baseCnpj));
        }

        normalized = normalized.ToUpperInvariant();
        int firstDigit = CalculateDigit(normalized, FirstDigitWeights);
        int secondDigit = CalculateDigit(normalized + firstDigit, SecondDigitWeights);

        return $"{firstDigit}{secondDigit}";
    }

    private static int CalculateDigit(string value, IReadOnlyList<int> weights)
    {
        int sum = 0;

        for (int index = 0; index < value.Length; index++)
        {
            sum += CharacterConverter.ToNumericValue(value[index]) * weights[index];
        }

        int remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}
