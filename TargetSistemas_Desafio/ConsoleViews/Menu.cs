public class Menu
{
    public static void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\n === Desafios ===");
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Desafio 01");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ComissoesView.Start();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }


            Console.WriteLine();
            Console.WriteLine("\n\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

    }
}