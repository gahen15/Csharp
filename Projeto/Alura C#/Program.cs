using System.Linq.Expressions;
using Microsoft.VisualBasic;
// Cria uma lista do tipo STRING com nome LISTADEBANDAS
//List<String> listaDeBandas = new List<string> { "7 Minutoz", "Nova Trupe", "VMZ", "Player Tauz", "Iron Master" };

Dictionary<string, List<double>> avaliacaoDeBanda = new Dictionary<string, List<double>>();
avaliacaoDeBanda.Add("7 minutoz", new List<double> { 10, 9, 8.5, 9.8, 9.9 });
avaliacaoDeBanda.Add("VMZ", new List<double>());


void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

Boas Vindas ao Screen Sound!
");
    ExibirOpcoesDoMenu();
}

void ExibirOpcoesDoMenu()
{

    Console.WriteLine("\tDigite 1 para registrar uma banda\n\tDigite 2 para mostrar todas as bandas\n\tDigite 3 para avaliar uma banda\n\tDigite 4 para exibir a média de uma banda○\n\tDigite 0 para Sair");
    Console.Write("\nDigite a sua opção: ");
    String opcaoEscolhida = Console.ReadLine()!;

    switch (opcaoEscolhida)
    {
        case "1":
            RegistrarBanda();
            break;

        case "2":
            ExibirListaDeBandas();
            break;

        case "3":
            AvaliarBanda();
            break;

        case "4":
            MediaBandas();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Tchau! 8-)");
            break;

        default:
            Console.Clear();
            ExibirMensagemDeBoasVindas();
            ExibirOpcoesDoMenu();
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    asterisco("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    //listaDeBandas.Add(nomeDaBanda);
    avaliacaoDeBanda.Add(nomeDaBanda, new List<double>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!\n");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMensagemDeBoasVindas();

}

void ExibirListaDeBandas()
{
    Console.Clear();
    asterisco("Lista de Bandas");
    /* for (int i = 0; i < listaDeBandas.Count; i++)
     {
         Console.WriteLine($"Banda: {listaDeBandas[i]}");
     }
     */

    /*foreach (string banda in listaDeBandas)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    */

    foreach (var banda in avaliacaoDeBanda)
    {
        string nomeBanda = banda.Key;
        List<double> notas = banda.Value;

        // Converte a lista de notas para uma string formatada
        string notasFormatadas = notas.Count > 0 ? string.Join(" | ", notas) : "Nenhuma nota registrada.";

        Console.WriteLine($"Banda: {nomeBanda} [Notas: {notasFormatadas}]");
    }


    Console.WriteLine("\n\tAperte qualquer tecla para retornar...");
    Console.ReadKey();
    Console.Clear();
    ExibirMensagemDeBoasVindas();
}

void AvaliarBanda()
{
    Console.Clear();
    asterisco("Avaliar banda");
    Console.WriteLine("Qual banda você deseja avaliar?");
    string bandaQueSeraAvaliada = Console.ReadLine()!;
    if (avaliacaoDeBanda.ContainsKey(bandaQueSeraAvaliada))
    {
        Console.WriteLine($"\nQual nota que deseja atribuir a banda {bandaQueSeraAvaliada}?");
        double nota = double.Parse(Console.ReadLine()!);
        avaliacaoDeBanda[bandaQueSeraAvaliada].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi atribuida com sucesso à banda {bandaQueSeraAvaliada}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMensagemDeBoasVindas();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaQueSeraAvaliada} não foi encontrada!!!");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirMensagemDeBoasVindas();
    }

}

void MediaBandas()
{
    Console.Clear();
    asterisco("Média das Bandas");
    foreach (var bandas in avaliacaoDeBanda)
    {
        string nomeBanda = bandas.Key;
        List<double> valores = bandas.Value;
        if (valores.Count > 0)
        {
            double mediaBanda = valores.Average();
            Console.WriteLine($"Banda: {nomeBanda} | Média: {mediaBanda}");
        }
        else
        {
            Console.WriteLine($"Banda: {nomeBanda} | Média: Está banda não possui notas o suficiente");
        }

    }
    Console.WriteLine("\n\tAperte qualquer tecla para retornar...");
    Console.ReadKey();
    Console.Clear();
    ExibirMensagemDeBoasVindas();
}

void asterisco(string titulo)
{

    int tamanho = titulo.Length;
    string asterisco = String.Empty.PadLeft(tamanho, '*');
    Console.WriteLine(asterisco + "\n" + titulo + "\n" + asterisco + "\n");

}


ExibirMensagemDeBoasVindas();
