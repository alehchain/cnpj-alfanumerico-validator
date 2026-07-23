# Algoritmo do CNPJ alfanumérico

O CNPJ mantém 14 posições: 12 caracteres de base e 2 dígitos verificadores numéricos.

## Conversão dos caracteres

Cada caractere da base é convertido pelo valor ASCII menos 48:

- `0` a `9` resultam em `0` a `9`.
- `A` a `Z` resultam em `17` a `42`.

Exemplos:

| Caractere | ASCII | Valor usado |
|---|---:|---:|
| `0` | 48 | 0 |
| `9` | 57 | 9 |
| `A` | 65 | 17 |
| `Z` | 90 | 42 |

## Primeiro dígito

Pesos aplicados às 12 posições:

```text
5 4 3 2 9 8 7 6 5 4 3 2
```

Após somar os produtos, calcula-se o resto da divisão por 11. Se o resto for menor que 2, o dígito é zero; caso contrário, o dígito é `11 - resto`.

## Segundo dígito

O primeiro dígito é anexado à base e são usados os pesos:

```text
6 5 4 3 2 9 8 7 6 5 4 3 2
```

A mesma regra de módulo 11 é aplicada.

## Referência

A implementação segue o manual técnico e os arquivos de referência publicados pela Receita Federal do Brasil.
