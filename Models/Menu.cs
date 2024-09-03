//using CsvHelper;
//using CsvHelper.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Formats.Asn1;
//using System.Globalization;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace GestaoAlojamentoTuristico
//{
//    /// <summary>
//    /// Classe responsável por gerenciar o menu do sistema
//    /// </summary>
//    public class Menu
//    {
//        private const string ArquivoUsuarios = "Usuarios.csv";
//        private string SenhaCriacaoFuncionario = "123ADMIN";
//        List<Hotel> listahoteis = Hotel.ListaHoteis;
//        List<Hospede> listahospedes = Hospede.ListaHospedes;

//        #region MÉTODOS
//        /// <summary>
//        /// Método para listar todas as pessoas (hospedes e funcionários) cadastradas no sistema.
//        /// </summary>
//        public static void ListarPessoas()
//        {
//            Console.WriteLine("Lista de Pessoas:");
//            foreach (var pessoa in Hotel.ListaHoteis)
//            {
//                Console.WriteLine($"{pessoa.NameUtilizador}");
//                if (pessoa is Hospede)
//                {
//                    Console.WriteLine($"Tipo: Hospede, Número do Hospede: {pessoa.IdUtilizador}");
//                }
//                else if (pessoa is Hotel)
//                {
//                    Console.WriteLine($"Tipo: Hotel, Número do Hotel: {((Hotel)pessoa).IdUtilizador}");
//                }
//                Console.WriteLine();
//            }
//        }

//        /// <summary>
//        /// Método para salvar os usuários (hospedes e funcionários) em um arquivo CSV.
//        /// </summary>
//        public static void SalvarHotelEmArquivo()
//        {
//            List<string> linhasExistentes = File.ReadAllLines(ArquivoUsuarios).ToList();

//            using (StreamWriter writer = new StreamWriter(ArquivoUsuarios, true))
//            {
//                foreach (var usuario in Hotel.ListaHoteis)
//                {
//                    string linha = $"{usuario.IdUtilizador},{usuario.NameUtilizador},{usuario.TypeUtilizador}";

//                    if (!linhasExistentes.Contains(linha))
//                    {
//                        writer.WriteLine(linha);
//                        linhasExistentes.Add(linha);
//                    }
//                }
//            }

//            Console.WriteLine("Hoteis adicionados com sucesso no arquivo.");
//        }

//        /// <summary>
//        /// Método para carregar os usuários (hospedes e funcionários) do arquivo CSV.
//        /// </summary>
//        public static void CarregarHoteisEmArquivo()
//        {
//            if (File.Exists(ArquivoUsuarios))
//            {
//                Hotel.ListaHoteis.Clear();

//                using (StreamReader reader = new StreamReader(ArquivoUsuarios))
//                {
//                    string linha;
//                    while ((linha = reader.ReadLine()) != null)
//                    {
//                        string[] dados = linha.Split(',');
//                        if (dados.Length == 5)
//                        {
//                            string username = dados[0];
//                            string password = dados[1];
//                            string nome = dados[2];
//                            string tipo = dados[3];
//                            Hotel.ListaHoteis.Add(new Hotel(username, password, nome, tipo));
//                        }
//                    }
//                }
//            }
//            Console.WriteLine("Hoteis carregados com sucesso do arquivo.");
//        }

//        ///// <summary>
//        ///// Método para listar os usuários (hospedes e funcionários) carregados do arquivo CSV.
//        ///// </summary>
//        //public static void ListarUsuariosCarregados()
//        //{
//        //    if (SistemaLogin.ListaUsuarios.Count > 0)
//        //    {
//        //        Console.WriteLine("Usuários carregados do arquivo:");
//        //        foreach (var usuario in SistemaLogin.ListaUsuarios)
//        //        {
//        //            Console.WriteLine($"Tipo: {usuario.PessoaTipo}");
//        //            Console.WriteLine($"Username: {usuario.PessoaUsername}");
//        //            Console.WriteLine($"ID: {usuario.PessoaId}");
//        //            Console.WriteLine($"Nome: {usuario.PessoaName}");
//        //            Console.WriteLine();
//        //        }
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("Nenhum usuário carregado do arquivo.");
//        //    }
//        //}
//        #endregion
//    }
//}