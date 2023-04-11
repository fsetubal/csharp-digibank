using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Extrato
    {
        public Extrato(DateTime date, string description, double value)
        {
            this.Date = date;
            this.Description = description;
            this.Value = value;
        }

        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public double Value { get; private set; }
    }
}
