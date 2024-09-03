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
using static GestaoAlojamentoTuristico.Reserva;

namespace GestaoAlojamentoTuristico
{
    /// <summary>
    /// Classe que representa as reservas no sistema de gerenciamento de alocamentos turisticos.
    /// </summary>
    internal class Reserva
    {
        public static List<Reserva> ListaReservas = new List<Reserva>();

        #region ATRIBUTOS
        private int IdReserva;
        private string TipoReserva;
        private string DescricaoReserva;
        private DateTime InicioReserva;
        private DateTime FimReserva;
        private decimal Diaria;
        private decimal PrecoTotal;
        private Hospede? hospedeAtual;
        private StatusReserva estadoReserva;
        public enum StatusReserva
        {
            Confirmada,
            Cancelada,
            Concluida
        }
        #endregion

        #region CONSTRUTORES        
        /// <summary>
        /// Inicializa uma nova instancia da classe Reserva com valores padrões <see cref="Reserva"/>.
        /// </summary>
        public Reserva()
        {
            IdReserva = 0;
            TipoReserva = "";
            DescricaoReserva = "";
            Diaria = 0;
            PrecoTotal = 0;
            estadoReserva = StatusReserva.Confirmada;
            hospedeAtual = null;
        }

        /// <summary>
        /// Inicializa uma nova instancia da classe Reserva com valores especificos <see cref="Reserva"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="description">The description.</param>
        /// <param name="diaria">The diaria.</param>
        /// <param name="precototal">The precototal.</param>
        /// <param name="estadoreserva">The estadoreserva.</param>
        /// <param name="hospede">The hospede.</param>
        public Reserva(string type, string description, decimal diaria, decimal precototal, StatusReserva estadoreserva, Hospede hospede)
        {
            TipoReserva = type;
            DescricaoReserva = description;
            Diaria = diaria;
            PrecoTotal = precototal;
            HospedeAtual = hospede;
            hospedeAtual = null;

        }
        #endregion

        #region PROPRIEDADES
        public int ReservaId { get; set; }
        public string ReservaType { get; set; }
        public string ReservaDescription { get; set; }
        public DateTime ReservaInicio { get; set; }
        public DateTime ReservaFim { get; set; }
        public decimal PerNight { get; set; }
        public decimal TotalCost { get; set; }
        public Hospede HospedeAtual { get; set; }
        public StatusReserva EstadoReserva { get; set; }
        #endregion
    }

    /// <summary>
    /// Classe responsável por gerir as reservas no sistema de gerenciamento de alocamentos turisticos.
    /// </summary>
    public class GestaoReserva
    {
        #region MÉTODOS
        /// <summary>
        /// Método para criar uma nova reserva com base nas informações fornecidas pelo usuário.
        /// </summary>
        public static void CriaReserva()
        {
            Console.WriteLine("Digite o tipo da reserva: ");
            string tiporeserva = Console.ReadLine().Trim();

            Console.WriteLine("Por favor, descreva o {0}: ", tiporeserva);
            string descricaoreserva = Console.ReadLine().Trim();

            Console.WriteLine("Digite a data inicial da reserva (XX/XX/XXXX): ");
            string inicio = Console.ReadLine().Trim();
            DateTime datainicio = DateTime.ParseExact(inicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Digite a data limite da reserva (XX/XX/XXXX): ");
            string fim = Console.ReadLine().Trim();
            DateTime datafim = DateTime.ParseExact(fim, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Digite o preço da diária: ");
            decimal diaria = int.Parse(Console.ReadLine().Trim());

            decimal precoTotal = CalcularPrecoTotal(datainicio, datafim, diaria);
            Console.WriteLine("Preço total da estadia: " + precoTotal);

            Console.WriteLine("Atribua o hospede: ");
            int id = int.Parse(Console.ReadLine().Trim());

            Hospede hospedeSelecionado = Hospede.EncontrarHospedeId(id);

            if (hospedeSelecionado != null)
            {
                ListaReservas.Add(new Reserva(tiporeserva, descricaoreserva, diaria, precoTotal, Reserva.StatusReserva.Confirmada, hospedeSelecionado)) ;
                Console.WriteLine("Reserva criada com sucesso!");
            }
            else
            {
                Console.WriteLine("Hospede não encontrado. A reserva não foi criada.");
            }
        }

        /// <summary>
        /// Método para editar uma reserva.
        /// </summary>
        public static void EditaReserva()
        {
            Console.Write("Digite o ID da Reserva que deseja editar: ");
            int IdReservaEdit = int.Parse(Console.ReadLine().Trim());

            Reserva ReservaEdit = ListaReservas.Find(u => u.ReservaId == IdReservaEdit);

            if (ReservaEdit != null)
            {
                Console.Write("Digite o novo tipo da reserva: ");
                ReservaEdit.ReservaType = Console.ReadLine().Trim();

                Console.Write("Digite a nova descrição da reserva: ");
                ReservaEdit.ReservaDescription = Console.ReadLine().Trim();

                Console.Write("Digite o novo valor da diária da reserva: ");
                ReservaEdit.PerNight = int.Parse(Console.ReadLine().Trim());

                Console.WriteLine("Reserva editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }
        }

        /// <summary>
        /// Método para cancelar uma reserva.
        /// </summary>
        public static void CancelaReserva()
        {
            Console.WriteLine("Digite o ID da reserva que deseja cancelar: ");
            int IdReserva = int.Parse(Console.ReadLine().Trim());

            Reserva CancelaReservaEdit = ListaReservas.Find(u => u.ReservaId == IdReserva);

            if (CancelaReservaEdit != null)
            {
                StatusReserva novoEstado = StatusReserva.Cancelada;
                CancelaReservaEdit.EstadoReserva = novoEstado;
                Console.WriteLine($"Reserva {IdReserva} cancelada com sucesso. Novo estado: {novoEstado}");
            }
            else
            {
                Console.WriteLine($"Reserva {IdReserva} não encontrada. Nenhuma alteração realizada.");
            }
        }

        /// <summary>
        /// Método para calcular o preço total da estadia.
        /// </summary>
        /// <param name="dataInicio">The data inicio.</param>
        /// <param name="dataFim">The data fim.</param>
        /// <param name="precoDiaria">The preco diaria.</param>
        /// <returns></returns>
        public static decimal CalcularPrecoTotal(DateTime dataInicio, DateTime dataFim, decimal precoDiaria)
        {
            TimeSpan duracaoEstadia = dataFim - dataInicio;
            int diasEstadia = duracaoEstadia.Days;

            decimal precoTotal = diasEstadia * precoDiaria;

            return precoTotal;
        }

        /// <summary>
        /// Método para listar as reservas de um hotel.
        /// </summary>
        public static void ListarReservas()
        {
            Console.WriteLine("Lista de Reservas:");
            foreach (var reserva in ListaReservas)
            {
                Console.WriteLine("Tipo: {0}\t | Descrição: {1}\t | Status: {2}\t | Data Inicio: {3}\t | Data Fim: {4}\t | Diária: {5}\t | Preço Total: {6}\t |",
                reserva.ReservaType, reserva.ReservaDescription, reserva.EstadoReserva, reserva.ReservaInicio, reserva.ReservaFim, reserva.PerNight, reserva.TotalCost);

                if (reserva.HospedeAtual != null)
                {
                    Console.WriteLine("ID do Hospede: {0}\t | Nome do Hospede: {1}\t |", reserva.HospedeAtual.IdUtilizador, reserva.HospedeAtual.NameUtilizador);
                }
                else
                {
                    Console.WriteLine("Hospede não associado à reserva.");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Listar as reservas de um hospede.
        /// </summary>
        /// <param name="idHospede">The identifier hospede.</param>
        public static void ListarReservasPorHospede(int idHospede)
        {
            Console.WriteLine($"Suas reservas: ");

            foreach (var reserva in ListaReservas)
            {
                if (reserva.HospedeAtual != null && reserva.HospedeAtual.IdUtilizador == idHospede)
                {
                    Console.WriteLine("Tipo: {0}\t | Descrição: {1}\t | Status: {2}\t | Data Inicio: {3}\t | Data Fim: {4}\t | Diária: {5}\t | Preço Total: {6}\t |",
                        reserva.ReservaType, reserva.ReservaDescription, reserva.EstadoReserva, reserva.ReservaInicio, reserva.ReservaFim, reserva.PerNight, reserva.TotalCost);

                    Console.WriteLine("ID do Hospede: {0}\t | Nome do Hospede: {1}\t |", reserva.HospedeAtual.IdUtilizador, reserva.HospedeAtual.NameUtilizador);
                    Console.WriteLine();
                }
            }

            if (!ListaReservas.Any(reserva => reserva.HospedeAtual != null && reserva.HospedeAtual.IdUtilizador == idHospede))
            {
                Console.WriteLine("Nenhuma reserva encontrada para o Hóspede com ID {0}.", idHospede);
            }
        }

        #endregion
    }
}