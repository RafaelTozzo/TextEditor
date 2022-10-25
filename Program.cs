namespace TextEditor
{
    class Program
    {
        static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.Write("O que você deseja fazer?\n 1 - Abrir arquivo\n 2 - Criar novo arquivo\n 0 - Sair\n ");
            byte option = byte.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 0: ExitProgram(); break;
                case 1: OpenFile(); break;
                case 2: CreateNewFile(); break;
                default: Menu(); break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo deseja abrir?");
            string path = Console.ReadLine()!;

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadLine();
            Menu();
        }

        static void SalveFile(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path!))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadKey();
            Menu();
        }

        static void CreateNewFile()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - ");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalveFile(text);
        }

        static void ExitProgram()
        {
            Console.WriteLine("Editor de texto encerrado.");
            System.Environment.Exit(0);
        }
    }
}