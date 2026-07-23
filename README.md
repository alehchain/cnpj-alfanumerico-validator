# CNPJ Alfanumérico Validator

Validador de CNPJ alfanumérico desenvolvido em C# e .NET.

## Funcionalidades

- Normalização do CNPJ, removendo máscara e espaços.
- Validação de 14 caracteres alfanuméricos.
- Cálculo dos dois dígitos verificadores.
- Compatibilidade com CNPJ numérico e com o novo formato alfanumérico.
- Testes unitários com xUnit.
- Pipeline de build e testes com GitHub Actions.

## Estrutura

```text
cnpj-alfanumerico-validator/
├── src/
│   └── CnpjAlfanumericoValidator/
├── tests/
│   └── CnpjAlfanumericoValidator.Tests/
├── .github/workflows/
├── CnpjAlfanumericoValidator.sln
└── README.md
```

## Exemplo de uso

```csharp
using CnpjAlfanumericoValidator;

bool valido = CnpjValidator.IsValid("12.ABC.345/01DE-35");

Console.WriteLine(valido ? "CNPJ válido" : "CNPJ inválido");
```

## Executar localmente

```bash
dotnet restore
dotnet build
dotnet test
```

## Regra de conversão

Para o cálculo dos dígitos verificadores, cada caractere é convertido da seguinte forma:

- `0` a `9` correspondem aos valores `0` a `9`.
- `A` a `Z` correspondem aos valores `10` a `35`.

O cálculo utiliza módulo 11 e os pesos oficiais aplicados aos 12 primeiros caracteres e, em seguida, aos 13 caracteres.

## Licença

Distribuído sob a licença MIT.
