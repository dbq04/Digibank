using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class ContaCorrente :Conta //herda da classe conta
    {
        //criando o construtor 

        public ContaCorrente() { 
           
            this.NumeroConta ="00" + Conta.NumeroDaContaSequencial;//contator quando cria a conta//gerando automatico o numero da conta
        
        }



    }
}
