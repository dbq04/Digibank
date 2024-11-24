using DigiBank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Pessoa
    {
        //atributos

        public string Nome { get; private set; }

        public string CPF { get; private set; }

        public string Senha { get; private set; }

        public  IConta Conta{get;set;}//tera todos contratos criados  na interface conta

        //criando os metodos

        public void SetNome(string nome) //recebe parametro string nome
        {
            this.Nome = nome;
        }

        public void SetCPF(string cpf)
        {
            this.CPF =cpf;
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }






    }
}
