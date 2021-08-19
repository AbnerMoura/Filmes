using Filmes;
using System;

namespace Filmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilmes();
						break;
					case "3":
						AtualizarFilmes();
						break;
					case "4":
						ExcluirFilmes();
						break;
					case "5":
						VisualizarFilmes();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluirfilme()
		{
			Console.Write("Digite o id da filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void Atualizarfilme()
		{
			Console.Write("Digite o id da filme: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes atualizaFilmes = new Filmes(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaFilmes);
		}
        private static void Listarfilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma filme cadastrado.");
				return;
			}

			foreach (var filmes in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserirfilme()
		{
			Console.WriteLine("Inserir nova série");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o Diretor da filme: ");
			string diretor = Console.ReadLine();

			Console.Write("Digite o Autor principal da filme: ");
			string autorPrincipal = Console.ReadLine();

			Console.Write("Digite a Descrição da filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes novaSerie = new Filmes(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir nova filme");
			Console.WriteLine("3- Atualizar filmes");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filmes");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }		
		
}
