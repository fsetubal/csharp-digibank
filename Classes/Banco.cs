using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Banco
    {
        public  Banco()
        {
            this.BankName = "DigiBank";
            this.BankCode = "030";
        }

        public string BankName { get; private set; }
        public string BankCode { get; private set; }
    }
}
