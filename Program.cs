using System.Globalization;
using System.Text;
using Repositorio;

namespace AppClientes;

class Program
{
    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
    static void Main(string[] args)
    {

        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _clienteRepositorio.lerDadosClientes();

        while (true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void Menu()
    {

        Console.Clear();

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        escolherOpcao();
    }

    static void escolherOpcao()
    {
        Console.Write("Escolha uma opção: ");

        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _clienteRepositorio.CadastrarCliente();
                    Menu();
                    break;
                }
            case 2:
                {
                    _clienteRepositorio.exibirClientes();
                    Menu();
                    break;
                }
            case 3:
                {
                    _clienteRepositorio.editarCliente();
                    Menu();
                    break;
                }
            case 4:
                {
                    _clienteRepositorio.excluirCliente();
                    Menu();
                    break;
                }
            case 5:
                {
                    _clienteRepositorio.gravarDadosCliente();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida!");
                    break;
                }
        }
    }
}
