using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntTVapi
{
	static public class ConnectionStrings
	{
		static private string sqlConnectionString = "Data Source =.; Initial Catalog = tvcoil; Integrated Security = True";

		static private string mySqlConnectionString = "server=localhost; user id = root; persistsecurityinfo=True; password=Rk14101981; database=tvcoil; UseAffectedRows=True";

		static public string GetSqlConnection()
		{
			return sqlConnectionString;
		}

		static public string GetMySqlConnection()
		{
			return mySqlConnectionString;
		}
	}
}
