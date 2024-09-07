using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
    public List<Cliente> clientes = new List<Cliente>();

    public void gravarDadosCliente()
    {
        var opcoes = new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = System.Text.Json.JsonSerializer.Serialize(clientes, opcoes);

        File.WriteAllText("clientes.txt", json);
        
    }

    public void lerDadosClientes()
    {
        if (File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");

            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

            clientes.AddRange(clientesArquivo);
        
        }

    }

    public void excluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        imprimirCliente(cliente);

        clientes.Remove(cliente);

        Console.WriteLine("Cliente removido com sucesso! [Enter]");

        Console.ReadKey();
    }

    public void editarCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        imprimirCliente(cliente);

        Console.Write("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var DataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        cliente.Nome = nome;
        cliente.DataNascimento = DataNascimento;
        cliente.Desconto = desconto;
        cliente.CadastroEm = DateTime.Now;

        Console.WriteLine("Cliente alterado com sucesso! [Enter]");
        imprimirCliente(cliente);
        Console.ReadKey();
    }

    public void CadastrarCliente()
    {
        Console.Clear();

        Console.Write("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var DataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var cliente = new Cliente();
        cliente.Id = clientes.Count + 1;
        cliente.Nome = nome;
        cliente.DataNascimento = DataNascimento;
        cliente.Desconto = desconto;
        cliente.CadastroEm = DateTime.Now;

        clientes.Add(cliente);

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        imprimirCliente(cliente);
        Console.ReadKey();
    }
    public void imprimirCliente(Cliente cliente)
    {
        Console.WriteLine("ID.............: " + cliente.Id);
        Console.WriteLine("Nome.............: " + cliente.Nome);
        Console.WriteLine("Desconto.............: " + cliente.Desconto.ToString("0.00"));
        Console.WriteLine("Data Nascimento.............: " + cliente.DataNascimento);
        Console.WriteLine("Data Cadastro.............: " + cliente.CadastroEm);
        Console.WriteLine("------------------------------------------------");
    }

    public void exibirClientes()
    {
        Console.Clear();

        foreach (var cliente in clientes)
        {
            imprimirCliente(cliente);
        }

        Console.ReadKey();
    }
}