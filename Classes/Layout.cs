using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void MainScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Clear();
            
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                            ######    DIGIBANK    ######                     ");
            Console.WriteLine("                            ============================                     ");

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                             Select an option:                               ");
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                             1 - Create an account                           ");
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                             2 - Sign in to DigiBank                         ");
            Console.WriteLine("                            ============================                     ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: NewAccountScreen(); 
                    break;
                case 2: SignInScreen();
                    break;
                default:
                    Console.WriteLine("                          ");
                    Console.WriteLine("Invalid option. Try again.");

                    Thread.Sleep(2000);

                    MainScreen();
                    break;
            }
                        
        }

        private static void NewAccountScreen()
        {

            Console.Clear();

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                             Full Name:                                      ");
            string name = Console.ReadLine();
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                             CPF(Numbers only):                              ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                             Password:                                       ");
            string password = Console.ReadLine();
            Console.WriteLine("                            ============================                     ");

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetName(name);
            pessoa.SetCPF(cpf);
            pessoa.SetPassword(password);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();

            Console.WriteLine("                             Account has been successfully registered.                      ");
            Console.WriteLine("                            ===========================================                     ");
            Console.WriteLine("                                    ## PRESS ENTER TO LOGIN ##                              ");
            Console.ReadLine();
            
            SignInScreen();
        }

        private static void SignInScreen()
        {
            Console.Clear();

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                             CPF(Numbers only):                              ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                            ============================                     ");
            Console.WriteLine("                             Password:                                       ");
            string password = Console.ReadLine();
            Console.WriteLine("                            ============================                     ");

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Password == password);

            if(pessoa != null)
            {
                WelcomeScreen(pessoa);
                AccountScreen(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("                             Not a valid account.                      ");
                Console.WriteLine("                            ======================                     ");

                NewAccOrSignIn();

                Console.WriteLine();
                Console.WriteLine();


            }


             

        }

        private static void WelcomeScreen(Pessoa pessoa)
        {
            string msgWelcomeScreen =
                $"{pessoa.Name} | Account: {pessoa.Conta.GetAccountNumber()} | Branch: {pessoa.Conta.GetBranchNumber()} | " +
                $"Bank: {pessoa.Conta.GetBankCode()}";
            Console.WriteLine("");
            Console.WriteLine($"        Welcome, {msgWelcomeScreen}");
            Console.WriteLine("");
        }
        private static void AccountScreen(Pessoa pessoa)
        {
            Console.Clear();

            WelcomeScreen(pessoa);

            Console.WriteLine("                            ======================                     ");
            Console.WriteLine("                             Menu:                                     ");
            Console.WriteLine("                            ======================                     ");
            Console.WriteLine("                             1 - Deposit                               ");
            Console.WriteLine("                             2 - Withdraw                              ");
            Console.WriteLine("                             3 - Account balance                       ");
            Console.WriteLine("                             4 - Bank statement                        ");
            Console.WriteLine("                             5 - Exit                                  ");
            Console.WriteLine("                            ======================                     ");

            opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1: 
                    DepositScreen(pessoa);
                    break;
                case 2:
                    WithdrawlScreen(pessoa);
                    break;
                case 3:
                    AccountBalanceScreen(pessoa);
                    break;
                case 4:
                    StatementScreen(pessoa);
                    break;
                case 5:
                    MainScreen();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                             Not a valid option.                      ");
                    Console.WriteLine("                            ======================                    ");
                    break;
            }

        }

        private static void MenuOrExitScreen(Pessoa pessoa)
        {
            Console.WriteLine("                             Select an option:                               ");
            Console.WriteLine("                             =================                               ");
            Console.WriteLine("                             1 - Menu                                        ");
            Console.WriteLine("                             2 - Exit                                        ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                AccountScreen(pessoa);
            }
            else
            {
                MainScreen();
            }

        }

        private static void NewAccOrSignIn()
        {
            Console.WriteLine("                             Select an option:                               ");
            Console.WriteLine("                            ======================                           ");
            Console.WriteLine("                             1 - Create an account                           ");
            Console.WriteLine("                             2 - Sign In                                     ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                NewAccountScreen();
            }
            else
            {
                SignInScreen();
            }
        }


        private static void DepositScreen(Pessoa pessoa)
        {
            Console.Clear();

            WelcomeScreen(pessoa);

            Console.WriteLine("                                    Deposit amount:                     ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                                    ================                    ");

            pessoa.Conta.Deposit(valor);

            Console.Clear();

            WelcomeScreen(pessoa);

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                             Successfully deposited.                         ");
            Console.WriteLine("                             =======================                         ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");

            MenuOrExitScreen(pessoa);

        }

        private static void WithdrawlScreen(Pessoa pessoa)
        {
            Console.Clear();

            WelcomeScreen(pessoa);

            Console.WriteLine("                                    Withdrawal amount:                       ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                                   ====================                      ");

            bool okWithdraw = pessoa.Conta.Withdraw(valor);

            Console.Clear();

            WelcomeScreen(pessoa);

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");

            if (okWithdraw)
            {
                Console.WriteLine("                                                                             ");
                Console.WriteLine("                             Successfully withdrawal.                        ");
                Console.WriteLine("                            ==========================                       ");
                Console.WriteLine("                                                                             ");
                Console.WriteLine("                                                                             ");
            }
            else
            {
                Console.WriteLine("                                                                             ");
                Console.WriteLine("                             Insufficient funds.                             ");
                Console.WriteLine("                            =====================                            ");
                Console.WriteLine("                                                                             ");
                Console.WriteLine("                                                                             ");
            }

            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");

            MenuOrExitScreen(pessoa);
        }

        private static void AccountBalanceScreen(Pessoa pessoa)
        {
            Console.Clear();

            WelcomeScreen(pessoa);

            double accountBalance = pessoa.Conta.GetAccountBalance();

            Console.WriteLine("                             ============================                    ");
            Console.Write($"                             Account balance: {accountBalance.ToString("C")}    ");
            Console.WriteLine();
            Console.WriteLine("                             ============================                    ");
            Console.WriteLine();

            MenuOrExitScreen(pessoa);
        }

        private static void StatementScreen(Pessoa pessoa)
        {
            Console.Clear();

            WelcomeScreen(pessoa);

            if(pessoa.Conta.Extrato().Any())
            {
                //Show statement

                double total = pessoa.Conta.Extrato().Sum(x => x.Value);

                foreach(Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine($"                            Date:{extrato.Date.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"                            Transaction type:{extrato.Description}             ");
                    Console.WriteLine($"                            Amount:{extrato.Value.ToString("C")}               ");
                    Console.WriteLine("                            =======================                             ");
                }

                Console.WriteLine("                                                                                ");
                Console.WriteLine($"                            Transactions amount:{total.ToString("C")}          ");
                Console.WriteLine("                            =======================                             ");
            }
            else
            {
                // Show error message

                Console.WriteLine("                                                                                ");
                Console.WriteLine($"                            Nothing to see here...                             ");
                Console.WriteLine("                            =======================                             ");


            }

            Console.WriteLine();
            
            MenuOrExitScreen(pessoa);
        }
    }

    
}
