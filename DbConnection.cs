using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace Hostify
{
	public class DbConnection
	{
		public static SqlConnection DBConnection()
		{
			string connString = String.Format(
				"Server = localhost; Database = AAD; Trusted_Connection=true; TrustServerCertificate=true;");
			SqlConnection conn = new SqlConnection(connString);
			return conn;
		}
	}
}