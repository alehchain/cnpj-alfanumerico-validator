using Xunit;

namespace CnpjAlfanumericoValidator.Tests;

public class CnpjValidatorTests
{
    [Theory]
    [InlineData("VJ.CP5.LPN/0001-04")]
    [InlineData("VJCP5LPN000104")]
    [InlineData("11.444.777/0001-61")]
    public void IsValid_ShouldReturnTrue_ForValidCnpj(string cnpj)
    {
        Assert.True(CnpjValidator.IsValid(cnpj));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("00.000.000/0000-00")]
    [InlineData("VJ.CP5.LPN/0001-05")]
    [InlineData("12.345.678/0001-AA")]
    [InlineData("CNPJ inválido")]
    public void IsValid_ShouldReturnFalse_ForInvalidCnpj(string? cnpj)
    {
        Assert.False(CnpjValidator.IsValid(cnpj));
    }

    [Fact]
    public void CalculateCheckDigits_ShouldReturnOfficialExampleDigits()
    {
        Assert.Equal("04", CnpjValidator.CalculateCheckDigits("VJCP5LPN0001"));
    }

    [Fact]
    public void Format_ShouldApplyCnpjMask()
    {
        Assert.Equal("VJ.CP5.LPN/0001-04", CnpjFormatter.Format("vjcp5lpn000104"));
    }

    [Fact]
    public void Generate_ShouldCreateValidCnpj()
    {
        string generated = CnpjGenerator.Generate();

        Assert.True(CnpjValidator.IsValid(generated));
    }
}
