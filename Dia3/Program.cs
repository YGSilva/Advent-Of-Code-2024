using System.Text.RegularExpressions;

var dados = File.ReadAllText("input");

Console.Write($"QUAL PARTE DO DESAFIO QUER RESOLVER? 1 OU 2? ");
var selecao = Console.ReadLine();

var regex = PadraoRegex();

if (selecao == "1")
    ParteUm(dados, regex);
else if (selecao == "2")
    ParteDois(dados);

static void ParteUm(string dados, Regex regex)
{
    int soma = 0;

    var resultados = regex.Matches(dados);

    foreach (Match resultado in resultados)
    {
        int numUm = int.Parse(resultado.Groups[1].Value);
        int numDois = int.Parse(resultado.Groups[2].Value);

        soma += numUm * numDois;
    }

    Console.WriteLine($"A soma total das multiplicações é: {soma}");
}

static void ParteDois(string dados) { }

partial class Program
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex PadraoRegex();
}