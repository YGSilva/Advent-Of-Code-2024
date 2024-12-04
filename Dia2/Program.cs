var relatorios = File.ReadAllLines("input").ToList();

Console.Write($"QUAL PARTE DO DESAFIO QUER RESOLVER? 1 OU 2? ");
var selecao = Console.ReadLine();

if (selecao == "1")
    ParteUm(relatorios);
else if (selecao == "2")
    ParteDois(relatorios);

static void ParteUm(List<string> relatorios)
{
    int relatoriosSeguros = 0;

    foreach (var linhaRelatorio in relatorios)
    {
        var relatorio = linhaRelatorio.Split(' ').Select(int.Parse).ToList();

        if (ValidarRelatorios(relatorio))
            relatoriosSeguros++;
    }

    Console.WriteLine($"TOTAL RELATORIOS SEGUDOS: {relatoriosSeguros}");
}

static void ParteDois(List<string> relatorios)
{
    int relatoriosSeguros = 0;

    foreach (var linhaRelatorio in relatorios)
    {
        var relatorio = linhaRelatorio.Split(' ').Select(int.Parse).ToList();

        if (SeguroComReducaoDoNivel(relatorio))
            relatoriosSeguros++;
    }

    Console.WriteLine($"TOTAL RELATORIOS SEGUDOS: {relatoriosSeguros}");
}

static bool ValidarRelatorios(List<int> relatorio)
{
    //List<int> diferencas = [];
    // for (int i = 0; i < relatorio.Count - 1; i++)
    //     diferencas.Add(relatorio[i] - relatorio[i + 1]);

    // O SKIP CRIA UMA LISTA DO RELATORIO, PORÉM PULANDO O PRIMERIO INDICE
    // APOS ISSO O ZIP COMPARA O PRIMEIRO ELEMENTO DE RELATORIO COM O PRIMEIRO DA LISTA CRIADA PELO SKIP
    // COM ISSO RETORNANDO A DIFERENCA ENTRE OS DOIS
    var diferencas = relatorio
        .Zip(relatorio.Skip(1), (numRelatorio, numSkip) => numRelatorio - numSkip)
        .ToList();

    var ordenado = diferencas.All(d => d > 0) || diferencas.All(d => d < 0);

    var validas = diferencas.All(d => Math.Abs(d) >= 1 && Math.Abs(d) <= 3);

    return ordenado && validas;
}

static bool SeguroComReducaoDoNivel(List<int> relatorio)
{
    for (int i = 0; i < relatorio.Count; i++)
    {
        var relatorioReduzido = new List<int>(relatorio);
        relatorioReduzido.RemoveAt(i);

        if (ValidarRelatorios(relatorioReduzido))
            return true;
    }
    return false;
}
