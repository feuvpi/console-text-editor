using System;
using System.IO;

internal class Program
{
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Escolha o que deseja fazer:");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("0 - Sair");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 0: Console.Clear(); System.Environment.Exit(0); break;
            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;

        }

    }

    static void Editar()
    {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair):");
        Console.WriteLine("------------------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
        Salvar(text);
    }

    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("Insira o caminho do arquivo a ser aberto:");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);
        }
        Console.WriteLine("");
        Console.ReadLine();
        Menu();

    }

    static void Salvar(string text)
    {
        Console.Clear();
        Console.WriteLine("Escolher caminho para salvar o arquivo:");
        var path = Console.ReadLine();
        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }
        Console.WriteLine($"Arquivo salvo com sucesso em {path}!");
        Menu();

    }



    private static void Main(string[] args)
    {
        Menu();
    }
}