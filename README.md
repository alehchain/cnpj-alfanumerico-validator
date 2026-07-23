# CNPJ Alfanumérico Validator

[![Build and Test](https://github.com/alehchain/cnpj-alfanumerico-validator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/alehchain/cnpj-alfanumerico-validator/actions/workflows/dotnet.yml)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Biblioteca em C# para validar, formatar, calcular os dígitos verificadores e gerar CNPJs numéricos e alfanuméricos fictícios.

A implementação segue a regra técnica publicada pela Receita Federal para o novo CNPJ alfanumérico, preservando também a compatibilidade com o formato numérico tradicional.

## Funcionalidades

- Validação de CNPJ numérico e alfanumérico.
- Aceita valores com ou sem máscara.
- Normalização para caixa alta.
- Cálculo dos dois dígitos verificadores.
- Formatação no padrão `AA.AAA.AAA/AAAA-00`.
- Geração de CNPJs fictícios válidos para testes.
- Métodos de extensão para uso simplificado.
- Testes unitários com xUnit.
- Build e testes automáticos com GitHub Actions.

## Exemplo rápido

```csharp
using CnpjAlfanumericoValidator;

const string cnpj = "VJ.CP5.LPN/0001-04";

bool valido = CnpjValidator.IsValid(cnpj);
string semMascara = CnpjFormatter.RemoveMask(cnpj);
string formatado = CnpjFormatter.Format(semMascara);
string ficticio = CnpjGenerator.Generate(formatted: true);

Console.WriteLine(valido);
Console.WriteLine(formatado);
Console.WriteLine(ficticio);
```

Também é possível usar os métodos de extensão:

```csharp
bool valido = "VJ.CP5.LPN/0001-04".IsValidCnpj();
string formatado = "VJCP5LPN000104".ToCnpjFormat();
```

## Cálculo dos dígitos

Os caracteres são convertidos pela regra:

```text
valor numérico = código ASCII do caractere - 48
```

Assim:

- `0` a `9` resultam nos valores `0` a `9`.
- `A` a `Z` resultam nos valores `17` a `42`.

Depois, são aplicados os pesos do módulo 11:

```text
Primeiro DV: 5 4 3 2 9 8 7 6 5 4 3 2
Segundo DV:  6 5 4 3 2 9 8 7 6 5 4 3 2
```

A explicação completa está em [`docs/algorithm.md`](docs/algorithm.md).

## Estrutura do projeto

```text
cnpj-alfanumerico-validator/
├── src/
│   └── CnpjAlfanumericoValidator/
├── tests/
│   └── CnpjAlfanumericoValidator.Tests/
├── samples/
│   └── ConsoleDemo/
├── docs/
│   └── algorithm.md
├── .github/workflows/
├── CnpjAlfanumericoValidator.sln
└── README.md
```

## Executar localmente

Requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/alehchain/cnpj-alfanumerico-validator.git
cd cnpj-alfanumerico-validator
dotnet restore
dotnet build
dotnet test
```

Para executar o exemplo:

```bash
dotnet run --project samples/ConsoleDemo/ConsoleDemo.csproj
```

## Aviso sobre a geração

Os CNPJs produzidos por `CnpjGenerator` são fictícios e destinados exclusivamente a testes de software. A validade matemática dos dígitos não significa que exista uma empresa registrada com a inscrição gerada.

## Referências oficiais

- Página do projeto CNPJ Alfanumérico da Receita Federal.
- Manual de cálculo do dígito verificador do CNPJ alfanumérico.
- Simulador oficial de inscrições alfanuméricas.

## Contribuindo

Contribuições são bem-vindas. Abra uma issue descrevendo a melhoria ou envie um pull request com testes para o comportamento adicionado.

## Licença

Distribuído sob a licença MIT. Consulte o arquivo [`LICENSE`](LICENSE).
