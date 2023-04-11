using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public class Pessoa
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Password { get; private set; }
        public IConta Conta { get; set; }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetCPF(string cpf)
        {
            this.CPF = cpf;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}
