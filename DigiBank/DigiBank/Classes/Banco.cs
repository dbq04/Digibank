using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public abstract class Banco
    {
        //criando construtor(inicializar os atributos)
        public Banco() {

            this.NomeDoBanco = "Digibank";
            this.CodigoDoBanco = "025";
        }

        // 
        public string NomeDoBanco { get; private set; } //qualquer classe pode pegar a informação porem so class banco pode setar

        public string CodigoDoBanco { get; private set; }

    }
}
