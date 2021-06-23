using System;
using CadastroSeries.classes;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsusario = ObterOpcaoUsuario();

            while(opcaoUsusario.ToUpper() != "X")
            {
                switch(opcaoUsusario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsusario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);

        }

        private static void ExcluirSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.Write("Digite o ID da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero),i));
            }
            System.Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string entradaDoTitulo = Console.ReadLine();

            System.Console.WriteLine("Entre com o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaDoTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
            
                System.Console.WriteLine("#ID {0}: . {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero),i));
            }
            System.Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string entradaDoTitulo = Console.ReadLine();

            System.Console.WriteLine("Entre com o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaDoTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Dio séries a seu dspor!!!!");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpr tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
