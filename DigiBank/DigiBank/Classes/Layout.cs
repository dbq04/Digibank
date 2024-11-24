using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        //criando a lista de pessoas
        private static List<Pessoa>pessoas = new List<Pessoa>();//toda pessoa cadastrada  fica na variavel pessoas
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.WriteLine("                Digite a opção Desejada           ");
            Console.WriteLine("               ===================================");
            Console.WriteLine("               1-Criar Conta                      ");
            Console.WriteLine("               ===================================");
            Console.WriteLine("               2-Entrar com cpf e senha           ");
            Console.WriteLine("               ===================================");

            // Criando a variavel opção e realizando a converção
            opcao=int.Parse(Console.ReadLine());

            //fazendo a verificação de qual opção selecionou

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;

                case 2:
                    TelaLogin();
                    break;

                default:
                    Console.WriteLine("Opção Invalida");
                    break;

            }
        }

        public static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                                 ");
            Console.WriteLine("               Digite seu nome                   ");
            string nome = Console.ReadLine();
            Console.WriteLine("              ===================================");
            Console.WriteLine("               Digite seu  cpf                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("              ===================================");
            Console.WriteLine("               Digite sua senha                  ");
            string senha =Console.ReadLine();
            Console.WriteLine("              ===================================");

            

            // Criar uma conta

            ContaCorrente contaCorrente = new ContaCorrente();

            Pessoa pessoa = new Pessoa();//criando pessoa com os atributos criados

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            //criando uma conta corrente vinculando a pessoa
            pessoa.Conta=contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("               Conta criada com sucesso          ");
            Console.WriteLine("              ===================================");

            //fica em pausa por alguns segundos para ir para tela logada
            Thread.Sleep(1000);

            //chama para tela de conta logada
            TelaContaLogada(pessoa);

        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                  ");
            Console.WriteLine("                Digite  seu cpf                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("               ===================================");
            Console.WriteLine("                Digite sua senha                  ");
           string senha = Console.ReadLine();
            Console.WriteLine("               ===================================");

            //logar no sistema

            Pessoa pessoa = pessoas.FirstOrDefault(x=>x.CPF==cpf&& x.Senha==senha); //busca o primeiro ou unico registro da lista de pessoas
            if (pessoa != null)
            {
                //TELA DE BOAS VINDAS
                TelaBoasvindas(pessoa);
                TelaContaLogada(pessoa);

            }
            else
            {
                Console.Clear();

                Console.WriteLine("            Pessoa não cadastrada             ");
                Console.WriteLine("           ===================================");
                Console.WriteLine();
                Console.WriteLine();


            }

        }

        private static void TelaBoasvindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
           $"{pessoa.Nome}| Banco: {pessoa.Conta.GetCodigoDoBanco()}" +
           $"| Agencia:{pessoa.Conta.GetNumeroAgencia()}|" +
           $"Conta{pessoa.Conta.GetNumeroConta()}";
            Console.WriteLine("");
            Console.WriteLine($"       Seja bem vindo,{msgTelaBemVindo}");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {

            Console.Clear();
            TelaBoasvindas(pessoa);

            Console.WriteLine("             Digite a Opção desejada:              ");
            Console.WriteLine("            ===================================    ");
            Console.WriteLine("             1-Realizar Deposito:                  ");
            Console.WriteLine("            ===================================    ");
            Console.WriteLine("             2-Realizar um saque:                  ");
            Console.WriteLine("            ===================================    ");
            Console.WriteLine("             3-Consultar um saldo:                 ");
            Console.WriteLine("            ===================================    ");
            Console.WriteLine("             4-Extrato:                            ");
            Console.WriteLine("            ===================================    ");
            Console.WriteLine("             5-Sair:                                ");
            Console.WriteLine("            ===================================    ");

            opcao= int.Parse(Console.ReadLine());
            switch(opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;

                case 2:
                    TelaSaque(pessoa);
                    break;
                
                case 3:
                    TelaSaldo(pessoa);
                    break;
               
                case 4:
                    TelaExtrato(pessoa);
                    break;
               
                case 5:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("    Opção Invalida!                       ");
                    Console.WriteLine("   ===================================    ");
                    break;

                }
            }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            //chama a tela de boas vindas
            TelaBoasvindas(pessoa);

            Console.WriteLine("    Digite o valor do deposito                    ");
            //conversão do valor digitado em double
            double valor= double.Parse(Console.ReadLine());
            Console.WriteLine("    ============================                  ");
            //Deposita o valor que foi informado
            pessoa.Conta.Deposita(valor);

            Console.Clear();
            TelaBoasvindas(pessoa);

            Console.WriteLine("                                                 ");
            Console.WriteLine("                                                 ");
            Console.WriteLine("   Deposito realizado com  sucesso               ");
            Console.WriteLine("   ===============================               ");
            Console.WriteLine("                                                 ");

            OpcaoVoltarLogado(pessoa);





        }
        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            //chama a tela de boas vindas
            TelaBoasvindas(pessoa);

            Console.WriteLine("      Digite o valor do saque                      ");
            //conversão do valor digitado em double
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("      ============================                 ");
            //Saca o valor que foi informado
             bool okSaque=pessoa.Conta.Saca(valor);

            Console.Clear();
            TelaBoasvindas(pessoa);

            Console.WriteLine("                                                   ");
            Console.WriteLine("                                                   ");

            if (okSaque)//SEa condição dor true
            {
              Console.WriteLine("     Saque  realizado com  sucesso               ");
              Console.WriteLine("     ===============================             ");
            }
            else
            {
                Console.WriteLine("   Saldo Insuficiente na conta                 ");
                Console.WriteLine("   ===============================             ");

            }
            Console.WriteLine("                                                   ");

            OpcaoVoltarLogado(pessoa);





        }

        private static void TelaSaldo(Pessoa pessoa)
        {

            Console.Clear();
            TelaBoasvindas(pessoa);
            Console.WriteLine($"        Seu saldo é {pessoa.Conta.ConsultaSaldo()}");
            Console.WriteLine("         ===============================           ");
            Console.WriteLine("                                                   ");
            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {

            Console.Clear();
            TelaBoasvindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                //mostra extrato

                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                //exibir as movimentações
             foreach(Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                        ");
                    Console.WriteLine($"                    Data:{extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"                    Tipo de Movimentação:{extrato.Descricao}           ");
                    Console.WriteLine($"                    Valor:{extrato.Valor}                              ");
                    Console.WriteLine("                     =======================================  ");
                }

               Console.WriteLine("                                                                   ");
               Console.WriteLine("                                                                   ");
               Console.WriteLine($"                              SUB TOTAL : {total}                 ");
               Console.WriteLine("                          ======================================   ");



            }
            else
            {
                //mensagem que não tem extrato
                Console.WriteLine("        Não ha extrato para ser visualizado   ");
                Console.WriteLine("        ===================================   ");

            }

            OpcaoVoltarLogado(pessoa);
        }


        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                                                  ");
            Console.WriteLine("    =================================             ");
            Console.WriteLine("    1- Voltar para minha conta                    ");
            Console.WriteLine("    =================================             ");
            Console.WriteLine("     2- Sair                                      ");
            Console.WriteLine("    =================================             ");

            opcao= int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();

        }

        private static void Deslogado()
        {
            Console.WriteLine("    Entre com a opção citada abaixo               ");
            Console.WriteLine("    =================================             ");
            Console.WriteLine("    1- Voltar para menu principal                 ");
            Console.WriteLine("    =================================             ");
            Console.WriteLine("      2- Sair                                     ");
            Console.WriteLine("    =================================             ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
                TelaPrincipal();
            else
            {
                Console.WriteLine("  Opção Invalida!!                            ");
                Console.WriteLine("=================================             ");
            }
                

        }
    }
}
