using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCnpj_Cpf
{
    class Program
    {

        static void Main(string[] args)
        {
            
            //Pesquisar CNPJ
            Validator_cpf_cnpj alertaCnpjInvaido = new Validator_cpf_cnpj();
            alertaCnpjInvaido.alertaCnpjInvalido();
            

            /*
            //Pesquisar CPF
            Validator_cpf_cnpj alertaCPFInvalido = new Validator_cpf_cnpj();
            alertaCPFInvalido.alertaCPFInvalido();
            */
        }
    }
}
