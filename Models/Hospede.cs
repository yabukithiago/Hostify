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
//    /// Classe derivada que representa hospedes.
//    /// </summary>
//    /// <seealso cref="GestaoAlojamentoTuristico.Hospede" />
//    internal class Hospede : Utilizador
//    {
//        #region ATRIBUTOS
//        private const string ArquivoHospedes= "Hospedes.csv";
//        public static List<Hospede> ListaHospedes { get; set; } = new List<Hospede>();
//        public static List<Reserva> reservas_Id;
//        #endregion

//        #region CONSTRUTORES
//        /// <summary>
//        /// Inicializa uma nova instancia da classe Hospede com valores especificos <see cref="Hospede"/>.
//        /// </summary>
//        /// <param name="username">The username.</param>
//        /// <param name="password">The password.</param>
//        /// <param name="nome">The nome.</param>
//        /// <param name="tipo">The tipo.</param>
//        public Hospede(string username, string password, string nome, string tipo) :  base(username, password, nome, tipo)
//        {
//        }
//        #endregion

//        #region MÉTODOS        

//        /// <summary>
//        /// Menus de um hospede nao logado.
//        /// </summary>
//        public static void Menu_Hospede_Nao_Logado()
//        {
//            string username, password;

//            do
//            {
//                Console.Write("Nome de usuário: ");
//                username = Console.ReadLine();

//                Console.Write("Senha: ");
//                password = Console.ReadLine();

//            } while (!Hospede.EfetuarLogin(username, password));
//            Console.Clear();
//        }

//        /// <summary>
//        /// Método para efetuar o login na plataforma.
//        /// </summary>
//        /// <param name="username">The username.</param>
//        /// <param name="password">The password.</param>
//        /// <returns></returns>
//        public static bool EfetuarLogin(string username, string password)
//        {
//            string? nomeusuario;
//            Hospede hospede = null;

//            // TO DO
//            //foreach (var hosp in ListaHospedes)
//            //{
//            //    if (hosp.UsernameUtilizador == username && hosp.PasswordUtilizador == password)
//            //    {
//            //        hospede = hosp;
//            //        return true;
//            //    }
//            //}

//            Console.WriteLine("Usuário não encontrado. Deseja criar uma conta? (S/N)");

//            if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
//            {
                
//                CriarContaHospede(out nomeusuario);

//                Console.WriteLine("Deseja efetuar login agora? (S/N)");
//                if (Console.ReadLine().Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
//                {
//                    // TO DO Menu_Hospede_Logado(hospede);
//                    return true;
//                }
//                else
//                {
//                    Menu_Hospede_Nao_Logado();
//                    nomeusuario = null;
//                    return false;
//                }
//            }

//            else
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Método para criar um novo hospede e adiciona-lo na lista de hospedes.
//        /// </summary>
//        /// <returns></returns>
//        public static string CriaHospede()
//        {
//            Console.Write("Digite o username do hospede: ");
//            string UsernameHospede = Console.ReadLine().Trim();

//            Console.Write("Digite a senha do hospede: ");
//            string PasswordHospede = Console.ReadLine().Trim();

//            Console.Write("Digite o nome do hospede: ");
//            string NomeHospede = Console.ReadLine().Trim();

//            string TipoHospede = "Hospede";

//            ListaHospedes.Add(new Hospede(UsernameHospede, PasswordHospede, NomeHospede, TipoHospede));

//            return NomeHospede;
//        }

//        /// <summary>
//        /// Método para criar a conta de um hospede.
//        /// </summary>
//        /// <param name="nomeusuario">The nomeusuario.</param>
//        public static void CriarContaHospede(out string nomeusuario)
//        {
//            string NovoNome = CriaHospede();
//            nomeusuario = NovoNome;
//        }

//        /// <summary>
//        /// Menu de um hospede logado.
//        /// </summary>
//        public static void Menu_Hospede_Logado(Hospede hospede)
//        {
//            bool continuar = true;

//            while (continuar)
//            {
//                Console.WriteLine("+-------------------------------------------+");
//                Console.WriteLine("|               Menu Principal              |");
//                Console.WriteLine("+-------------------------------------------+");
//                Console.WriteLine("| Bem-vindo, {0}!                        |", hospede.NameUtilizador);
//                Console.WriteLine("| Escolha uma opção:                        |");
//                Console.WriteLine("| 1. Fazer uma nova Reserva                 |");
//                Console.WriteLine("| 2. Visualizar suas Reservas               |");
//                Console.WriteLine("| 3. Realizar Check in                      |");
//                Console.WriteLine("| 4. Realizar Check out                     |");
//                Console.WriteLine("| 5. Editar Informações                     |");
//                Console.WriteLine("| 6. Excluir Conta                          |");
//                Console.WriteLine("| 7.                                        |");
//                Console.WriteLine("| 8.                                        |");
//                Console.WriteLine("| 9.                                        |");
//                Console.WriteLine("| 10. Sair                                  |");
//                Console.WriteLine("+-------------------------------------------+");

//                int escolha = int.Parse(Console.ReadLine());
//                switch (escolha)
//                {
//                    case 1:
//                        // TO DO FAZER UMA NOVA RESERVA
//                        // hospede.Fazer_Reserva(hospede);
//                        break;
//                    case 2:
//                        // TO DO VISUALIZAR SUAS RESERVAS
                        
//                        break;
//                    case 3:
//                        // TO DO REALIZAR CHECK INT
//                        break;
//                    case 4:
//                        //TO DO REALIZAR CHECK OUT
//                        break;
//                    case 10:
//                        continuar = false;
//                        Console.WriteLine("Saindo do programa...");
//                        break;
//                    default:
//                        Console.WriteLine("Por favor, digite uma opção válida");
//                        break;
//                }
//            }
//        }

//        /// <summary>
//        /// Método para editar um hospede.
//        /// </summary>
//        public static void EditaHospede()
//        {
//            Console.Write("Digite o username do hospede que deseja editar: ");
//            string UsernameHospedeEdit = Console.ReadLine().Trim();

//            Hospede HospedeEdit = ListaHospedes.Find(u => u.NameUtilizador == UsernameHospedeEdit && u.TypeUtilizador == "Hospede");

//            if (HospedeEdit != null)
//            {
//                Console.Write("Digite o novo número do hospede: ");
//                HospedeEdit.IdUtilizador = int.Parse(Console.ReadLine().Trim());

//                Console.Write("Digite o novo nome do hospede: ");
//                HospedeEdit.NameUtilizador = Console.ReadLine().Trim();

//                SalvarHospedesEmArquivo();
//                Console.WriteLine("Hospede editado com sucesso!");
//            }
//            else
//            {
//                Console.WriteLine("Hospede não encontrado.");
//            }
//        }

//        /// <summary>
//        /// Método para excluir um hospede.
//        /// </summary>
//        public static void ExcluiHospede()
//        {
//            Hospede DeleteHospede = null;
//            Console.WriteLine("Digite o id do hospede que deseja excluir: ");
//            int IdHospede = int.Parse(Console.ReadLine().Trim());

//            foreach (var hospede in ListaHospedes)
//            {
//                if (hospede.IdUtilizador == IdHospede)
//                {
//                    DeleteHospede = (Hospede)hospede;
//                    break;
//                }
//            }

//            if (DeleteHospede != null)
//            {
//                ListaHospedes.Remove(DeleteHospede);
//                SalvarHospedesEmArquivo();
//                Console.WriteLine($"Hospede {IdHospede} excluído com sucesso.");
//            }
//            else
//            {
//                Console.WriteLine($"Hospede {IdHospede} não encontrado. Nenhuma exclusão realizada.");
//            }
//        }

//        /// <summary>
//        /// Método para encontrar o hospede pelo identificador.
//        /// </summary>
//        /// <param name="id">The identifier.</param>
//        /// <returns></returns>
//        internal static Hospede EncontrarHospedeId(int id)
//        {
//            Hospede? hospedeEncontrado = ListaHospedes.Find(u => u is Hospede && ((Hospede)u).IdUtilizador == id) as Hospede;

//            return hospedeEncontrado;
//        }

//        /// <summary>
//        /// Realiza o check-in de uma reserva
//        /// </summary>
//        /// <param name="idReserva"></param>
//        public static void FazerCheckIn(int idReserva)
//        {
//            var reserva = reservas_Id.FirstOrDefault(r => r.ReservaId == idReserva);

//            if (reserva != null && reserva.EstadoReserva == Reserva.StatusReserva.Confirmada)
//            {
//                reserva.EstadoReserva = Reserva.StatusReserva.Confirmada;

//                Console.WriteLine($"Check-in realizado com sucesso para a reserva {idReserva}.");
//            }
//            else
//            {
//                Console.WriteLine($"Não foi possível realizar o check-in para a reserva {idReserva}. Verifique o estado da reserva.");
//            }
//        }

//        /// <summary>
//        /// Realiza o check-out de uma reserva
//        /// </summary>
//        /// <param name="idReserva"></param>
//        public static void FazerCheckOut(int idReserva)
//        {
//            var reserva = reservas_Id.FirstOrDefault(r => r.ReservaId == idReserva);

//            if (reserva != null && reserva.EstadoReserva == Reserva.StatusReserva.Confirmada)
//            {
//                // Realizar as operações de check-out, por exemplo, atualizar o estado da reserva
//                reserva.EstadoReserva = Reserva.StatusReserva.Concluida;

//                Console.WriteLine($"Check-out realizado com sucesso para a reserva {idReserva}.");
//            }
//            else
//            {
//                Console.WriteLine($"Não foi possível realizar o check-out para a reserva {idReserva}. Verifique o estado da reserva.");
//            }
//        }


//        /// <summary>
//        /// Método para salvar os hospedes em arquivo.
//        /// </summary>
//        public static void SalvarHospedesEmArquivo()
//        {
//            List<string> linhasExistentes = File.ReadAllLines(ArquivoHospedes).ToList();

//            using (StreamWriter writer = new StreamWriter(ArquivoHospedes, true))
//            {
//                foreach (var hospede in ListaHospedes)
//                {
//                    string linha = $"{hospede.UsernameUtilizador},{hospede.PasswordUtilizador},{hospede.IdUtilizador},{hospede.NameUtilizador},{hospede.TypeUtilizador}";

//                    if (!linhasExistentes.Contains(linha))
//                    {
//                        writer.WriteLine(linha);
//                        linhasExistentes.Add(linha);
//                    }
//                }
//            }

//            Console.WriteLine("Hospedes adicionados com sucesso no arquivo.");
//        }

//        /// <summary>
//        /// Método para carregar os hospedes do arquivo.
//        /// </summary>
//        public static void CarregarHospedesDoArquivo()
//        {
//            if (File.Exists(ArquivoHospedes))
//            {
//                ListaHospedes.Clear();

//                using (StreamReader reader = new StreamReader(ArquivoHospedes))
//                {
//                    string linha;
//                    while ((linha = reader.ReadLine()) != null)
//                    {
//                        string[] dados = linha.Split(',');
//                        if (dados.Length == 5)
//                        {
//                            string username = dados[0];
//                            string password = dados[1];
//                            int id = int.Parse(dados[2]);
//                            string nome = dados[3];
//                            string tipo = dados[4];

//                            if (tipo == "Hospede")
//                            {
//                                ListaHospedes.Add(new Hospede(username, password, nome, tipo));
//                            }
//                        }
//                    }
//                }
//                //remover
//                Console.WriteLine("Hospedes carregados com sucesso do arquivo.");
//            }
//            else
//            {
//                Console.WriteLine("Arquivo de hospedes não encontrado. A lista de hospedes permanecerá vazia.");
//            }
//        }

//        /// <summary>
//        /// Método para listar os usuarios de um arquivo carregado.
//        /// </summary>
//        public static void ListarUsuariosCarregados()
//        {
//            if (ListaHospedes.Count > 0)
//            {
//                Console.WriteLine("Hospedes carregados do arquivo:");
//                foreach (var usuario in ListaHospedes)
//                {
//                    Console.WriteLine($"Tipo: {usuario.TypeUtilizador}");
//                    Console.WriteLine($"Username: {usuario.UsernameUtilizador}");
//                    Console.WriteLine($"ID: {usuario.IdUtilizador}");
//                    Console.WriteLine($"Nome: {usuario.NameUtilizador}");
//                    Console.WriteLine();
//                }
//            }
//            else
//            {
//                Console.WriteLine("Nenhum hospedes carregado do arquivo.");
//            }
//        }
//        #endregion
//    }
//}
