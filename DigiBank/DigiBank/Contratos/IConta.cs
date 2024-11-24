using DigiBank.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Contratos
{
    public interface IConta
    {
        //criação dos contratos

        void Deposita(double valor);

        bool Saca(double valor);

        double ConsultaSaldo();

        string GetCodigoDoBanco();

        string GetNumeroAgencia();

        string GetNumeroConta();

        //lista de extrato
        List<Extrato> Extrato();
    }
}
