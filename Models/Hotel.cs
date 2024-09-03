using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestaoAlojamentoTuristico
{
    /// <summary>
    /// Classe derivada que representa hoteis.
    /// </summary>
    /// <seealso cref="GestaoAlojamentoTuristico.Utilizador" />
    internal class Hotel : Utilizador
    {
        private const string ArquivoHoteis = "Hoteis.csv";
        public static List<Hotel> ListaHoteis { get; set; } = new List<Hotel>();

        #region CONSTRUTORES
        /// <summary>
        /// Inicializa uma nova instancia da classe Hotel com valores especificios <see cref="Hotel"/>.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="nome">The nome.</param>
        /// <param name="tipo">The tipo.</param>
        public Hotel(string username, string password, string nome,  string tipo) : base(username, password, nome, tipo)
        {
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Menu do hotel quando não esta logado.
        /// </summary>
        public static void Menu_Hotel_Nao_Logado()
        {
            string username, password, nome;

            do
            {
                Console.Write("Nome de usuário: ");
                username = Console.ReadLine();

                Console.Write("Senha: ");
                password = Console.ReadLine();

            } while (!EfetuarLogin(username, password, out nome));
            Console.Clear();
        }

        /// <summary>
        /// Método para efetuar o login na plataforma.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="nomeusuario">The nomeusuario.</param>
        /// <param name="tipousuario">The tipousuario.</param>
        /// <returns></returns>
        public static bool EfetuarLogin(string username, string password, out string nomeusuario)
        {
            foreach (var usuario in ListaHoteis)
            {
                if (usuario.UsernameUtilizador == username && usuario.PasswordUtilizador == password)
                {
                    nomeusuario = usuario.NameUtilizador;
                    return true;
                }
            }

            Console.WriteLine("Usuário não encontrado. Deseja criar uma conta? (S/N)");

            if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                CriarContaHotel(out nomeusuario);

                Console.WriteLine("Deseja efetuar login agora? (S/N)");
                if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    nomeusuario = null;
                    return false;
                }
            }
            else
            {
                nomeusuario = null;
                return false;
            }
        }

        /// <summary>
        /// Método para criar um novo hotel e adicioná-lo à lista de hoteis.
        /// </summary>
        /// <returns></returns>
        public static string CriarHotel()
        {
            Console.Write("Digite o username do hotel: ");
            string UsernameHotel = Console.ReadLine().Trim();

            Console.Write("Digite a senha do hotel: ");
            string PasswordHotel = Console.ReadLine().Trim();

            Console.Write("Digite a matricula do hotel: ");
            int IdHotel = int.Parse(Console.ReadLine().Trim());

            Console.Write("Digite o nome do hotel: ");
            string NomeHotel = Console.ReadLine().Trim();

            string TipoHotel = "Hotel";

            Hotel.ListaHoteis.Add(new Hotel(UsernameHotel, PasswordHotel, NomeHotel, TipoHotel));
            SalvarHotelEmArquivo();
            return NomeHotel;
        }

        /// <summary>
        /// Método para criar a conta de um hotel.
        /// </summary>
        /// <param name="nomeusuario">The nomeusuario.</param>
        /// <param name="tipousuario">The tipousuario.</param>
        public static void CriarContaHotel(out string nomeusuario)
        {
            string SenhaCriacaoHotel = "123ADMIN";
            Console.Write("Digite a senha de criação de hotel: ");
            string senhaCriacao = Console.ReadLine().Trim();
            
            if (senhaCriacao != SenhaCriacaoHotel)
            {
                Console.WriteLine("Senha de criação de funcionário incorreta. Conta não criada.");
                nomeusuario = null;
                return;
            }
            
            string NovoNome = CriarHotel();
            nomeusuario = NovoNome;
        }

        /// <summary>
        /// Menu de um hotel logado.
        /// </summary>
        public void Menu_Hotel_Logado(Hotel hotel)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("+-------------------------------------------+");
                Console.WriteLine("|               Menu Principal              |");
                Console.WriteLine("+-------------------------------------------+");
                Console.WriteLine("| Bem-vindo, {0}!                           |", hotel.NameUtilizador);
                Console.WriteLine("|                                           |");
                Console.WriteLine("| Escolha uma opção:                        |");
                Console.WriteLine("| 1. Criar quartos                          |");
                Console.WriteLine("| 2. Editar quartos                         |");
                Console.WriteLine("| 3. Excluir quartos                        |");
                Console.WriteLine("| 4. Listar quartos                         |");
                Console.WriteLine("| 5. Listar usuários presentes na plataforma|");
                Console.WriteLine("| 6.                                        |");
                Console.WriteLine("| 7. Listar usuários salvos em um arquivo   |");
                Console.WriteLine("| 8. Criar reservas                         |");
                Console.WriteLine("| 9. Listar as reservas realizadas          |");
                Console.WriteLine("| 10. Sair                                  |");
                Console.WriteLine("+-------------------------------------------+");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        GestaoQuarto.CriaQuarto();
                        break;
                    case 2:
                        GestaoQuarto.EditaQuarto();
                        break;
                    case 3:
                        GestaoQuarto.ExcluiQuarto();
                        break;
                    case 4:

                        break;
                    case 5:
                        Menu.ListarPessoas();
                        break;
                    case 6:
                        //Menu.ExcluiHospede();
                        break;
                    case 7:
                        
                        break;
                    case 8:
                        GestaoReserva.CriaReserva();
                        break;
                    case 9:
                        GestaoReserva.ListarReservas();
                        break;
                    case 10:
                        continuar = false;
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Por favor, digite uma opção válida.");
                        break;
                }
            }
        }

        /// <summary>
        /// Método para editar um hotel.
        /// </summary>
        public static void EditaHotel()
        {
            Console.Write("Digite o ID do hotel que deseja editar: ");
            int IDHotelEdit = int.Parse(Console.ReadLine().Trim());

            Hotel hotelEdit = ListaHoteis.Find(hotel => hotel.IdUtilizador == IDHotelEdit && hotel.TypeUtilizador == "Hotel");

            if (hotelEdit != null)
            {
                Console.Write("Digite a nova matrícula do hotel: ");
                hotelEdit.IdUtilizador = int.Parse(Console.ReadLine().Trim());

                Console.Write("Digite o novo nome do hotel: ");
                hotelEdit.NameUtilizador = Console.ReadLine().Trim();

                SalvarHotelEmArquivo();
                Console.WriteLine("Hotel editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Hotel não encontrado.");
            }
        }

        /// <summary>
        /// Método para excluir um hotel.
        /// </summary>
        public static void ExcluiHotel()
        {
            Hotel DeleteHotel = null;
            Console.WriteLine("Digite o id do hotel que deseja excluir: ");
            int HotelId = int.Parse(Console.ReadLine().Trim());

            foreach (var hoteis in ListaHoteis)
            {
                if (hoteis.IdUtilizador == HotelId)
                {
                    DeleteHotel = (Hotel)hoteis;
                    break;
                }
            }

            if (DeleteHotel != null)
            {
                ListaHoteis.Remove(DeleteHotel);
                SalvarHotelEmArquivo();
                Console.WriteLine($"Hotel {HotelId} excluído com sucesso.");
            }
            else
            {
                Console.WriteLine($"Hotel {HotelId} não encontrado. Nenhuma exclusão realizada.");
            }
        }

        /// <summary>
        /// Método para salvar as informações dos hoteis em arquivo .CSV.
        /// </summary>
        public static void SalvarHotelEmArquivo()
        {
            List<string> linhasExistentes = File.ReadAllLines(ArquivoHoteis).ToList();

            using (StreamWriter writer = new StreamWriter(ArquivoHoteis, true))
            {
                foreach (var usuario in ListaHoteis)
                {
                    string linha = $"{usuario.UsernameUtilizador}, {usuario.PasswordUtilizador}, {usuario.IdUtilizador}, {usuario.NameUtilizador}";

                    if (!linhasExistentes.Contains(linha))
                    {
                        writer.WriteLine(linha);
                        linhasExistentes.Add(linha);
                    }
                }
            }

            Console.WriteLine("Hoteis adicionados com sucesso no arquivo.");
        }
        #endregion
    }
}
