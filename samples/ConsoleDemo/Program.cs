using CnpjAlfanumericoValidator;

const string cnpj = "VJ.CP5.LPN/0001-04";

Console.WriteLine($"CNPJ: {cnpj}");
Console.WriteLine($"Válido: {CnpjValidator.IsValid(cnpj)}");

string generated = CnpjGenerator.Generate(formatted: true);
Console.WriteLine($"CNPJ fictício gerado: {generated}");
Console.WriteLine($"CNPJ gerado é válido: {generated.IsValidCnpj()}");
