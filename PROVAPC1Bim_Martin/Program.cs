using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PROVAPC1Bim_Martin
{
    class Program
    {
        
        private static List<Cadastro> listaCadastro = new List<Cadastro>();

        static void Main(string[] args)
        {
            Boolean continuar = true;

            ler();

            do
            {
                /* MENU com as opções: incluir, alterar, excluir, listar, pesquisar e sair */
                Console.WriteLine("Seja bem-vindo ao Menu de Cadastro!");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("01 - Incluir");
                Console.WriteLine("02 - Alterar");
                Console.WriteLine("03 - Excluir");
                Console.WriteLine("04 - Listar");
                Console.WriteLine("05 - Pesquisar");
                Console.WriteLine("09 - Salvar");
                Console.WriteLine("10 - Sair");
                Console.WriteLine("Lista de quantidade de itens cadastrados: " + listaCadastro.Count);
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {

                    /* INCLUIR */
                    case "01":
                        listaCadastro.Add(incluirCadastro());
                        break;

                    /* ALTERAR */
                    case "02":
                        Console.WriteLine("Insira o ID que deseja alterar");
                        int alterarCadastro = int.Parse(Console.ReadLine());
                        Cadastro buscaAlterar = listaCadastro.Find(x => x.Id == alterarCadastro);

                        if (buscaAlterar != null)
                        {
                            Console.WriteLine("Cadastro localizado: ");
                            Console.WriteLine(buscaAlterar);

                            listaCadastro.Remove(buscaAlterar);
                            listaCadastro.Add(incluirCadastro());

                            Console.WriteLine("Cadastro alterado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("ID não encontrado!");
                        }
                        break;

                    /* EXCLUIR */
                    case "03":
                        Console.Write("Digite o ID do cadastro que deseja excluir: ");
                        int excluirCadastro = int.Parse(Console.ReadLine());

                        Cadastro buscaExcluir = listaCadastro.Find(x => x.Id == excluirCadastro);

                        Console.WriteLine("Você tem certeza que deseja excluir? Digite 1 para SIM ou 2 para NÃO.");
                        int escolha = int.Parse(Console.ReadLine());

                        if ((escolha == 1) && (buscaExcluir != null))
                        {
                            listaCadastro.Remove(buscaExcluir);
                            Console.WriteLine("Cadastro excluído com sucesso!");
                        }
                        else if ((escolha == 2) && (buscaExcluir != null))
                        {
                            Console.WriteLine("O cadastro será mantido!");
                        }

                        else 
                        {
                            Console.WriteLine("ID não encontrado! Opção inválida.");
                        }
                        break;

                    /* LISTAR */
                    case "04":
                        Console.WriteLine("Lista de itens cadastrados: ");
                        foreach (Cadastro cadastro in listaCadastro)
                        {
                            Console.WriteLine(cadastro);
                        }
                        break;

                    /* PESQUISAR */
                    case "05":
                        Console.WriteLine("Digite o ID que deseja pesquisar: ");
                        int pesquisaId = int.Parse(Console.ReadLine());

                        Cadastro pesquisar = listaCadastro.Find(pesq => pesq.Id == pesquisaId);
                        if (pesquisar != null)
                        {
                            Console.WriteLine("Cadastro localizado: " + pesquisar);
                        }

                        else
                        {
                            Console.WriteLine("ATENÇÃO: o ID pesquisado não foi encontrado!");
                        }

                        break;

                    /* SALVAR */
                    case "09":
                        Console.WriteLine("Seu arquivo de texto foi salvo!");
                        salvar();
                        break;

                    /* SAIR - ok */
                    case "10":
                        Console.WriteLine("Até logo!");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente!");
                        break;
                }
            }

            while (continuar);

            Console.ReadKey();
        }


        private static Cadastro incluirCadastro()
        {
            Cadastro cadastro = new Cadastro();

            Console.WriteLine("ID da floricultura");
            Console.Write("ID: ");
            cadastro.Id = int.Parse(Console.ReadLine());
            Console.Write("Produto: ");
            cadastro.Produto = Console.ReadLine();
            Console.Write("Cidade: ");
            cadastro.Cidade = Console.ReadLine();
            Console.WriteLine("Quantidade: ");
            cadastro.Quantidade = Console.ReadLine();
            Console.WriteLine("Preco R$: ");
            cadastro.Preco = float.Parse(Console.ReadLine());

            return cadastro;
        }

        private static Cadastro salvar()
        {
            string json = JsonConvert.SerializeObject(listaCadastro.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"C:\Martin\teste.txt", json);

            return null;
        }

        private static Cadastro ler()
        {
            string jsonFilePath = @"C:\Martin\teste.txt";

            string json = System.IO.File.ReadAllText(jsonFilePath);

            Cadastro[] lista = JsonConvert.DeserializeObject<Cadastro[]>(json);

            listaCadastro = lista.ToList();
            Console.WriteLine();
            return null;
        }
    }
}

