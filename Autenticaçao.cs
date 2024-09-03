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

////namespace GestaoAlojamentoTuristico
////{
////    public class SistemaLogin
////    {
////        private string SenhaCriacaoFuncionario = "123ADMIN";

////        /// <summary>
////        /// Efetua login.
////        /// </summary>
////        /// <param name="username">The username.</param>
////        /// <param name="password">The password.</param>
////        /// <param name="nomeusuario">The nomeusuario.</param>
////        /// <param name="tipousuario">The tipousuario.</param>
////        /// <returns></returns>
////        public bool EfetuarLogin(string username, string password, out string nomeusuario, out string tipousuario)
////        {
////            foreach (var usuario in ListaUsuarios)
////            {
////                if (usuario.PessoaUsername == username && usuario.PessoaPassword == password)
////                {
////                    nomeusuario = usuario.PessoaName;
////                    tipousuario = usuario.PessoaTipo;
////                    return true;
////                }
////            }

////            Console.WriteLine("Usuário não encontrado. Deseja criar uma conta? (S/N)");

////            if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
////            {
////                CriarConta(out nomeusuario, out tipousuario);

////                Console.WriteLine("Deseja efetuar login agora? (S/N)");
////                if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
////                {
////                    return true;
////                }
////                else
////                {
////                    nomeusuario = null;
////                    tipousuario = null;
////                    return false;
////                }
////            }
////            else
////            {
////                nomeusuario = null;
////                tipousuario = null;
////                return false;
////            }
////        }

////        /// <summary>
////        /// Cria a conta de um hospede ou funcionario.
////        /// </summary>
////        /// <param name="nomeusuario">The nomeusuario.</param>
////        /// <param name="tipousuario">The tipousuario.</param>
////        public void CriarConta(out string nomeusuario, out string tipousuario)
////        {
////            Console.Write("Digite o tipo de usuário (Hospede/Funcionario): ");
////            string tipo = Console.ReadLine().Trim();

////            if (tipo == "Funcionario")
////            {
////                Console.Write("Digite a senha de criação de funcionário: ");
////                string senhaCriacao = Console.ReadLine().Trim();

////                if (senhaCriacao != SenhaCriacaoFuncionario)
////                {
////                    Console.WriteLine("Senha de criação de funcionário incorreta. Conta não criada.");
////                    nomeusuario = null;
////                    tipousuario = null;
////                    return;
////                }

////                string NovoNome = Menu.CriarFuncionario();
////                nomeusuario = NovoNome;
////                tipousuario = tipo;
////            }
////            else if (tipo == "Hospede")
////            {
////                string NovoNome = Menu.CriaHospede();
////                nomeusuario = NovoNome;
////                tipousuario = tipo;
////            }
////            else
////            {
////                Console.WriteLine("Tipo de usuário inválido. Conta não criada.");
////                nomeusuario = null;
////                tipousuario = null;
////            }
////        }
////    }
////}