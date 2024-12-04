List<int> listaUm = [];
List<int> listaDois = [];

if (!File.Exists("input"))
    throw new InvalidOperationException("File not found.");

var input = await File.ReadAllLinesAsync("input");

Console.Write($"QUAL PARTE DO DESAFIO QUER RESOLVER? 1 OU 2? ");
var selecao = Console.ReadLine();

MontarListas(listaUm, listaDois, input);

if (selecao == "1") 
    ParteUm(listaUm, listaDois);
else if (selecao == "2") 
    ParteDois(listaUm, listaDois);

static void ParteUm(List<int> listaUm, List<int> listaDois)
{
    var um = listaUm.OrderByDescending(l => l).ToList();
    var dois = listaDois.OrderByDescending(l => l).ToList();

    var diferencas = um.Zip(dois, (um, dois) => Math.Abs(um - dois)).ToList();

    System.Console.WriteLine($"SOMA DA DIFERENÇA = {diferencas.Sum()}");
}

static void ParteDois(List<int> listaUm, List<int> listaDois)
{
    var similaridade = 0;
    foreach(var numero in listaUm)
    {
        var numRepeticao = listaDois.Where(l => l == numero).Count();
        similaridade += numero * numRepeticao;
    }

    System.Console.WriteLine($"SCORE DE SIMILARIDADE = {similaridade}");
}

static void MontarListas(List<int> listaUm, List<int> listaDois, string[] input)
{
    foreach (var linhas in input)
    {
        var divisaoListas = linhas.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (divisaoListas.Length == 2)
        {
            listaUm.Add(int.Parse(divisaoListas[0]));
            listaDois.Add(int.Parse(divisaoListas[1]));
        }
    }
}