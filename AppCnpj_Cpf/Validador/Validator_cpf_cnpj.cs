using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Xceed.Wpf.Toolkit;
using System.Windows;

class Validator_cpf_cnpj
{

    public void alertaCPFInvalido()
    {
        //Insira CPF
        //var tx_NumeroCPF = "766.096.040-70"; //CPF valido
        var tx_NumeroCPF = "123.096.040-70"; //CPF invalido

        //Mensagem de Alerta
        var alertaCpfInvalido = "CPF fornecido é inválido";

        if (ValidadorCPF(tx_NumeroCPF) is false)
        {
            Console.WriteLine(tx_NumeroCPF + " - CPF invalido");
            Console.WriteLine(alertaCpfInvalido);
            MessageBoxResult result = System.Windows.MessageBox.Show(alertaCpfInvalido, "Alerta", MessageBoxButton.YesNo);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine(tx_NumeroCPF + " CPF é valido");
            Console.ReadKey();
        }
    }


    public void alertaCnpjInvalido()
    {
        //Insira CNPJ
        var tx_NumeroCNPJ = "01.928.374/6501-92"; //cnpj invalido para teste
        //var tx_NumeroCNPJ = "21.422.050/0001-37"; //cnpj valido

        //Mensagem de Alerta
        var alertaCnpjInvalido = "CNPJ fornecido é inválido";

        if (ValidadorCnpj(tx_NumeroCNPJ) is false)
        {
            Console.WriteLine(tx_NumeroCNPJ + " - CNPJ invalido");
            Console.WriteLine(alertaCnpjInvalido);
            MessageBoxResult result = System.Windows.MessageBox.Show(alertaCnpjInvalido, "Alerta", MessageBoxButton.YesNo);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine(tx_NumeroCNPJ + " CNPJ é valido");
            Console.ReadKey();
        }
    }

    //Validador CPF
    public static bool ValidadorCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string cpfSemDigito;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        cpfSemDigito = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(cpfSemDigito[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        cpfSemDigito = cpfSemDigito + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(cpfSemDigito[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }


    //Validador CNPJ
    public static bool ValidadorCnpj(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;
        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        tempCnpj = cnpj.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cnpj.EndsWith(digito);
    }
}
