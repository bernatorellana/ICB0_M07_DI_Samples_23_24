using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComptaParaules.Model
{
    internal class Parell
    {
        private String clau;
        private int valor;

        public Parell(string clau, int valor)
        {
            Clau = clau;
            Valor = valor;
        }

        public string Clau { get => clau; set => clau = value; }
        public int Valor { get => valor; set => valor = value; }
    }
}
