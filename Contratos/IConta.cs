using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.Classes;

namespace DigiBank.Contratos
{
    public interface IConta
    {
        void Deposit(double valor);
        bool Withdraw(double valor);
        double GetAccountBalance();
        string GetBankCode();
        string GetBranchNumber();
        string GetAccountNumber();
        List<Extrato> Extrato();


    }
}
