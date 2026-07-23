namespace CnpjAlfanumericoValidator;

internal static class CharacterConverter
{
    public static bool IsAllowed(char character)
    {
        char normalized = char.ToUpperInvariant(character);
        return normalized is >= '0' and <= '9' or >= 'A' and <= 'Z';
    }

    public static int ToNumericValue(char character)
    {
        char normalized = char.ToUpperInvariant(character);

        if (!IsAllowed(normalized))
        {
            throw new ArgumentException($"O caractere '{character}' não é válido no CNPJ.", nameof(character));
        }

        // Regra oficial: valor numérico = código ASCII do caractere - 48.
        // Dessa forma, 0..9 resultam em 0..9 e A..Z resultam em 17..42.
        return normalized - '0';
    }
}
