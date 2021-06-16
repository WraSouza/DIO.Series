using System;
using DIO.Series;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {           

           string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
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
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceEntrada = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceEntrada);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceEntrada = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceEntrada);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o Gênero entre as Opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();
            

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);           

        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }            
                foreach (var serie in lista)
                {
                    var excluido = serie.RetornaExcluido();
                    if(excluido)
                {
                    Console.WriteLine("#Id:{0}: - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), excluido ? "Excluído" : "");
                }
                else
                {
                    Console.WriteLine("#Id:{0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
                }
                    
                }
                       
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a Opção Desejada");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
