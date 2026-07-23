using System.Security.Cryptography;

namespace CnpjAlfanumericoValidator;

/// <summary>
/// Gera inscrições fictícias válidas para testes de software.
/// </summary>
public static class CnpjGenerator
{
    private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Gera um CNPJ alfanumérico fictício e válido.
    /// </summary>
    public static string Generate(bool formatted = false)
    {
        Span<char> baseCnpj = stackalloc char[12];

        for (int index = 0; index < baseCnpj.Length; index++)
        {
            baseCnpj[index] = Alphabet[RandomNumberGenerator.GetInt32(Alphabet.Length)];
        }

        string value = new string(baseCnpj) + CnpjValidator.CalculateCheckDigits(new string(baseCnpj));
        return formatted ? CnpjFormatter.Format(value) : value;
    }
}
