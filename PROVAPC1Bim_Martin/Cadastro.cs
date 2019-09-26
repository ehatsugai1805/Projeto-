using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROVAPC1Bim_Martin
{
    class Cadastro
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Cidade { get; set; }
        public string Quantidade { get; set; }
        public float Preco { get; set;  }

        public override string ToString()
        {
            return "ID: " + Id + " |  Produto: " + Produto + " | Cidade: " + Cidade + " | Quantidade: " + Quantidade + " | Preco: " + Preco;
        }

    }
}
