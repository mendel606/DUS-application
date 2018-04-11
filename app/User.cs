using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace app
{
	public class User
	{
		SqlConnection connection;
		public string connectionstring;

		public string Gebruikersnaam;
		public string Wachtwoord;

		public User()
		{

		}

		public User(string GN)
		{
			connectionstring = ConfigurationManager.ConnectionStrings
				["app.Properties.Settings.DUSdbConnectionString"].ConnectionString;
			Gebruikersnaam = GN;
		}

		public User(string GN, string WW)
		{
			connectionstring = ConfigurationManager.ConnectionStrings
				["app.Properties.Settings.DUSdbConnectionString"].ConnectionString;
			Gebruikersnaam = GN;
			Wachtwoord = WW;
		}

		public void Login()
		{
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Wachtwoord FROM Gebruiker a WHERE a.Gebruikersnaam = @Name", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Name", Gebruikersnaam);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Wachtwoord = reader.GetString(0);
						}
					}
				}
			}
		}

		public void Signup()
		{
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("INSERT INTO Gebruiker VALUES (@Gebruikersnaam, @Wachtwoord)", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Gebruikersnaam", Gebruikersnaam);
						commend.Parameters.AddWithValue("@Wachtwoord", Wachtwoord);

						commend.ExecuteNonQuery();
					}
				}
			}
		}
	}
}
