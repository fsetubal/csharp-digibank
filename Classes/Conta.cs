using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.BranchNumber = "0001";
            Conta.TotalAccounts++;
            this.Transactions = new List<Extrato>();
        }

        public double Balance { get; protected set; }
        public string AccountNumber { get; protected set; }
        public string BranchNumber { get;  private set; }

        public static int TotalAccounts { get; private set; }

        private List<Extrato> Transactions;

        public double GetAccountBalance()
        {
            return this.Balance;
        }

        public string GetBankCode()
        {
            return this.BankCode;
        }
        public string GetAccountNumber()
        {
            return this.AccountNumber;
        }

        public string GetBranchNumber()
        {
            return this.BranchNumber;
        }

        public void Deposit(double valor)
        {
            DateTime nowDate = DateTime.Now;
            this.Transactions.Add(new Extrato(nowDate, "Deposit", valor));
            this.Balance += valor;
        }

        public bool Withdraw(double valor)
        {
            if (valor > this.GetAccountBalance())
                return false;

            DateTime nowDate = DateTime.Now;
            this.Transactions.Add(new Extrato(nowDate, "Withdraw", -valor));

            this.Balance -= valor;
            return true;
        }

        public List<Extrato> Extrato()
        {
            return this.Transactions;
        }
    }
}
