public class Menu
{
    public static void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n === Desafios ===");
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Desafio 01");
            Console.WriteLine("2 - Desafio 02");
            Console.WriteLine("3 - Desafio 03");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    new ComissoesView().Start();
                    break;

                case "2":
                    new EstoqueView().Start();
                    break;

                case "3":
                    new JurosView().Start();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }


            Console.WriteLine("\n\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

    }
}