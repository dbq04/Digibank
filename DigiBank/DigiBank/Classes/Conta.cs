using DigiBank.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    //CLASSE CONTA HERDA DO BANCO E CRIA A IMPLEMENTAÇÃO DO CONTRATO CONTA
    public abstract class Conta : Banco, IConta
    {
        //construtor

        public Conta() {

            //quando criar a conta o numero sera 001
            this.NumeroAgencia = "0001";
            Conta.NumeroDaContaSequencial++;//toda vez quando instancia a classe ira acresentar mais um no num da conta

            //Inicialização da Movimentação extrato
            this.Movimentacoes = new List<Extrato>();

        
        }
        //atributos

        public double Saldo { get;protected set; }
        public string NumeroAgencia { get; private set; }//qualquer classe pode pegar a informação porem so class conta pode setar

        public string NumeroConta{ get; protected set; }

        public static int NumeroDaContaSequencial { get; private set; }

        //propriedade do extrato
        private List<Extrato> Movimentacoes;



        //implementação dos metodos
        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual,"Deposito",valor));
            this.Saldo += valor;
        }

        public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

            this.Saldo-=valor;
            return true;
        }

        public string GetCodigoDoBanco()
        {
           return this.CodigoDoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}
