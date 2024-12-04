using System.Text.RegularExpressions;

var dados = File.ReadAllText("input");

Console.Write($"QUAL PARTE DO DESAFIO QUER RESOLVER? 1 OU 2? ");
var selecao = Console.ReadLine();

if (selecao == "1")
    ParteUm(dados);
else if (selecao == "2")
    ParteDois(dados);

static void ParteUm(string dados)
{
    var mulSomada = 0;

    var resultados = PadraoRegexUm().Matches(dados);

    foreach (Match resultado in resultados)
    {
        int numUm = int.Parse(resultado.Groups[1].Value);
        int numDois = int.Parse(resultado.Groups[2].Value);

        mulSomada += numUm * numDois;
    }

    Console.WriteLine($"MULTIPLICACAO SOMADA: {mulSomada}");
}

static void ParteDois(string dados)
{
    var mulSomada = 0;

    var resultados = PadraoRegexDois().Matches(dados);

    var habilitado = true;

    foreach (Match resultado in resultados)
    {
        if (habilitado && resultado.Value.StartsWith("mul"))
        {
            var numUm = int.Parse(resultado.Groups[1].Value);
            var numDois = int.Parse(resultado.Groups[2].Value);

            mulSomada += numUm * numDois;
        }
        else if (resultado.Value.Equals("do()"))
            habilitado = true;
        else if (resultado.Value.Equals("don't()"))
            habilitado = false;
    }

    Console.WriteLine($"MULTIPLICACAO SOMADA: {mulSomada}");
}

partial class Program
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex PadraoRegexUm();

    [GeneratedRegex(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)")]
    private static partial Regex PadraoRegexDois();
}
