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

namespace Hostify
{
    /// <summary>
    /// Classe base que representa utilizador em um sistema de gestão de alocamentos turísticos.
    /// </summary>
    abstract public class Utilizador
    {
        #region ATRIBUTOS
        private int UtilizadorId;
        private int proximoutilizadorid = 0;
        private string UtilizadorUsername;
        private string UtilizadorPassword;
        private string UtilizadorName;
        private string UtilizadorTipo;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Inicializa uma nova instancia da classe Utilizador com valores padrões <see cref="Utilizador"/>.
        /// </summary>
        public Utilizador()
        {
            UtilizadorId = 0;
            UtilizadorUsername = "";
            UtilizadorPassword = "";
            UtilizadorName = "";
            UtilizadorTipo = "";
        }

        /// <summary>
        /// Inicializa uma nova instancia da classe Utilizador com valores especificos <see cref="Utilizador"/>.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public Utilizador(string username, string password, string name, string type)
        {
            UtilizadorId = proximoutilizadorid++;
            UtilizadorUsername = username;
            UtilizadorPassword = password;
            UtilizadorName = name;
            UtilizadorTipo = type;
        }
        #endregion

        #region PROPRIEDADES
        public int IdUtilizador { get; set; }
        public string UsernameUtilizador { get; set; }
        public string PasswordUtilizador { get; set; }
        public string NameUtilizador { get; set; }
        public string TypeUtilizador { get; set; }
        #endregion

        #region MÉTODOS

        #endregion
    }
}