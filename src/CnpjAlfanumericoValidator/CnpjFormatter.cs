using System.Text;

namespace CnpjAlfanumericoValidator;

/// <summary>
/// Fornece operações de normalização e formatação de CNPJ.
/// </summary>
public static class CnpjFormatter
{
    /// <summary>
    /// Remove pontuação e espaços, mantendo somente letras e números em caixa alta.
    /// </summary>
    public static string RemoveMask(string? cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            return string.Empty;
        }

        var result = new StringBuilder(14);

        foreach (char character in cnpj)
        {
            if (CharacterConverter.IsAllowed(character))
            {
                result.Append(char.ToUpperInvariant(character));
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Aplica a máscara AA.AAA.AAA/AAAA-00 a um CNPJ com 14 caracteres.
    /// </summary>
    /// <exception cref="ArgumentException">O valor normalizado não possui 14 caracteres.</exception>
    public static string Format(string cnpj)
    {
        string normalized = RemoveMask(cnpj);

        if (normalized.Length != 14)
        {
            throw new ArgumentException("O CNPJ deve conter exatamente 14 caracteres.", nameof(cnpj));
        }

        return $"{normalized[..2]}.{normalized.Substring(2, 3)}.{normalized.Substring(5, 3)}/{normalized.Substring(8, 4)}-{normalized.Substring(12, 2)}";
    }
}
