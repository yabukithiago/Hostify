using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Globalization;

namespace GestaoAlojamentoTuristico
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Olá! Como deseja efetuar o login?");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Hotel");
            int tipo = int.Parse(Console.ReadLine().Trim());

            if (tipo == 1)
            {
                Hospede.Menu_Hospede_Nao_Logado();
            }

            if (tipo == 2)
            {
                Hotel.Menu_Hotel_Nao_Logado();
            }
        }
    }
}