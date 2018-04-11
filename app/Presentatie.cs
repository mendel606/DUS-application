using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace app
{
	public class Presentatie
	{
		SqlConnection connection;
		public string connectionstring;

		public string Naam;
		public DateTime Lengte;
		public string Gebruikersnaam;
		public int Aantal_Woorden;
		public int Aantal_stopwoorden;
		public string Stopwoord;
		public int Presentatie_ID;
		public int Stopwoord_ID = 0;
		public int Geluid_ID = 0;
		ListBox Presentaties = new ListBox();
		public List<string> Presentatielist = new List<string>();
		public List<int> AantalperStopwoord = new List<int>();
		public List<string> Stopwoorden = new List<string>();

		public Presentatie()
		{
			connectionstring = ConfigurationManager.ConnectionStrings
				["app.Properties.Settings.DUSdbConnectionString"].ConnectionString;
		}

		public Presentatie(string naam, DateTime lengte, int aantal, int totaal)
		{
			Naam = naam;
			Lengte = lengte;
			Aantal_Woorden = aantal;
			Aantal_stopwoorden = totaal;

			connectionstring = ConfigurationManager.ConnectionStrings
				["app.Properties.Settings.DUSdbConnectionString"].ConnectionString;
		}

		public Presentatie(string naam, string stopwoord, int aantal)
		{
			Naam = naam;
			Stopwoord = stopwoord;
			Aantal_Woorden = aantal;

			connectionstring = ConfigurationManager.ConnectionStrings
				["app.Properties.Settings.DUSdbConnectionString"].ConnectionString;
		}
		

		public void Getall()
		{
			int aantal;
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT COUNT(a.Stopwoord) FROM Stopwoorden a", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							aantal = reader.GetInt32(0);
						}
					}
				}
			}

			for(int i = 1; i < aantal + 1; i++)
			{
				try
				{
					string stopwoord;

					using (connection = new SqlConnection(connectionstring))
					{
						using (SqlCommand commend = new SqlCommand("SELECT a.Stopwoord FROM Stopwoorden a WHERE a.Stopwoord_ID = @Name", connection))
						{
							using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
							{
								connection.Open();

								commend.Parameters.AddWithValue("@Name", i);

								using (connection)
								using (var reader = commend.ExecuteReader())
								{
									reader.Read();
									stopwoord = reader.GetString(0);
								}
							}
						}
					}

					Stopwoorden.Add(stopwoord);
				}
				catch
				{

				}
			}
		}

		public void Add(string GN)
		{
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("INSERT INTO Presentatie VALUES (@Naam, @Lengte, @Aantal_Woorden, @Aantal_stopwoorden)", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Naam);
						commend.Parameters.AddWithValue("@Lengte", Lengte.ToLongTimeString());
						commend.Parameters.AddWithValue("@Aantal_Woorden", Aantal_Woorden);
						commend.Parameters.AddWithValue("@Aantal_stopwoorden", Aantal_stopwoorden);

						commend.ExecuteNonQuery();
					}
				}
			}

			int GID;
			int PID;

			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Gebruikers_ID FROM Gebruiker a WHERE Gebruikersnaam = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", GN);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							GID = reader.GetInt32(0);
						}
					}
				}
			}

			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Presentatie_ID FROM Presentatie a WHERE Naam = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Naam);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							PID = reader.GetInt32(0);
						}
					}
				}
			}

			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("INSERT INTO Gebruiker_Presentatie VALUES (@GID, @PID)", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@GID", GID);
						commend.Parameters.AddWithValue("@PID", PID);

						commend.ExecuteNonQuery();
					}
				}
			}
		}

		public void Sample()
		{
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Presentatie_ID FROM Presentatie a WHERE a.Naam = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Naam);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Presentatie_ID = reader.GetInt32(0);
						}
					}
				}
			}

			try
			{
				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT a.Stopwoord_ID FROM Stopwoorden a WHERE a.Stopwoord = @Naam", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("Naam", Stopwoord);

							using (connection)
							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								Stopwoord_ID = reader.GetInt32(0);
							}
						}
					}
				}

				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("INSERT INTO Sample_Presentatie VALUES (@PID, @SID, null, @Aantal)", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@PID", Presentatie_ID);
							commend.Parameters.AddWithValue("@SID", Stopwoord_ID);
							commend.Parameters.AddWithValue("@Aantal", Aantal_Woorden);
							
							commend.ExecuteNonQuery();
						}
					}
				}
			}
			catch
			{
				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT a.Geluid_ID FROM Geluiden a WHERE a.Geluid = @Naam", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@Naam", Naam);

							using (connection)
							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								Geluid_ID = reader.GetInt32(0);
							}
						}
					}
				}

				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("INSERT INTO Sample_Presentatie VALUES (@PID, @SID, @GID, @Aantal)", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@PID", Presentatie_ID);
							commend.Parameters.AddWithValue("@SID", null);
							commend.Parameters.AddWithValue("@GID", Geluid_ID);
							commend.Parameters.AddWithValue("@Aantal", Aantal_Woorden);

							commend.ExecuteNonQuery();
						}
					}
				}
			}

		}

		public void GetPresName(string GN)
		{
			int GID;
			int Aantal;
			int PID;
			List<int> IDs = new List<int>();

			

			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Gebruikers_ID FROM Gebruiker a WHERE Gebruikersnaam = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", GN);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							GID = reader.GetInt32(0);
						}
					}
				}
			}
			
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT COUNT(a.Presentatie_ID) FROM Gebruiker_Presentatie a WHERE Gebruiker_ID = @Naam", connection))
				{
					using (SqlDataAdapter a = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", GID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Aantal = reader.GetInt32(0);
						}
					}
				}
			}

			
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.ID FROM Gebruiker_Presentatie a WHERE Gebruiker_ID = @Naam", connection))
				{
					using (SqlDataAdapter a = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", GID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							int i = 0;
							while (reader.Read())
							{
								try
								{
									IDs.Add(reader.GetInt32(i));
									i++;
								}
								catch
								{

								}
								
							}
							
						}
					}
				}
			}

			for (int i = 0; i < Aantal; i++)
			{
				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT a.Presentatie_ID FROM Gebruiker_Presentatie a WHERE ID = @Naam", connection))
					{
						using (SqlDataAdapter a = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@Naam", IDs[i]);

							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								PID = reader.GetInt32(0);
							}
						}
					}
				}

				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT a.Naam FROM Presentatie a WHERE Presentatie_ID = @Naam", connection))
					{
						using (SqlDataAdapter a = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@Naam", PID);
							
							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								
								Presentatielist.Add(reader.GetString(0));
							}
						}
					}
				}
			}
		}

		public void GetPres(string PN)
		{
			// ID
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Presentatie_ID FROM Presentatie a WHERE a.Naam = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", PN);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Presentatie_ID = reader.GetInt32(0);
						}
					}
				}
			}

			// Gebruiker
			int GID;
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Gebruiker_ID FROM Gebruiker_Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
						    GID = reader.GetInt32(0);
						}
					}
				}
			}
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Gebruikersnaam FROM Gebruiker a WHERE a.Gebruikers_ID = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", GID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Gebruikersnaam = reader.GetString(0);
						}
					}
				}
			}

			//Lengte
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Lengte FROM Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Lengte = Convert.ToDateTime(reader.GetString(0));
						}
					}
				}
			}

			//Aantal woorden
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Aantal_woorden FROM Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Aantal_Woorden = reader.GetInt32(0);
						}
					}
				}
			}

			//Aantal stopwoorden
			using (connection = new SqlConnection(connectionstring))
			{
				using (SqlCommand commend = new SqlCommand("SELECT a.Aantal_stopwoorden FROM Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
				{
					using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
					{
						connection.Open();

						commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

						using (connection)
						using (var reader = commend.ExecuteReader())
						{
							reader.Read();
							Aantal_stopwoorden = reader.GetInt32(0);
						}
					}
				}
			}

			//Samples
				int aantal;
				int begin;
				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT COUNT(*) FROM Sample_Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

							using (connection)
							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								aantal = reader.GetInt32(0);
							}
						}
					}
				}
				using (connection = new SqlConnection(connectionstring))
				{
					using (SqlCommand commend = new SqlCommand("SELECT a.ID FROM Sample_Presentatie a WHERE a.Presentatie_ID = @Naam", connection))
					{
						using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
						{
							connection.Open();

							commend.Parameters.AddWithValue("@Naam", Presentatie_ID);

							using (connection)
							using (var reader = commend.ExecuteReader())
							{
								reader.Read();
								begin = reader.GetInt32(0);
							}
						}
					}
				}
				for (int i = begin; i < (aantal + begin); i++)
				{
					try
					{
						//stopwoord
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Stopwoord_ID FROM Sample_Presentatie a WHERE a.ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", i);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										Stopwoord_ID = reader.GetInt32(0);
									}
								}
							}
						}
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Stopwoord FROM Stopwoorden a WHERE a.Stopwoord_ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", Stopwoord_ID);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										Stopwoorden.Add(reader.GetString(0));
									}
								}
							}
						}

						// aantal keer gezegd
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Aantal FROM Sample_Presentatie a WHERE a.Stopwoord_ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", Stopwoord_ID);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										AantalperStopwoord.Add(reader.GetInt32(0));
									}
								}
							}
						}
					}
					catch
					{
						//Geluid
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Geluid_ID FROM Sample_Presentatie a WHERE a.ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", i);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										Geluid_ID = reader.GetInt32(0);
									}
								}
							}
						}
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Geluid FROM Geluiden a WHERE a.Geluid_ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", Geluid_ID);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										Stopwoorden.Add(reader.GetString(0));
									}
								}
							}
						}

						// aantal keer gezegd
						using (connection = new SqlConnection(connectionstring))
						{
							using (SqlCommand commend = new SqlCommand("SELECT a.Aantal FROM Sample_Presentatie a WHERE a.Geluid_ID = @Naam", connection))
							{
								using (SqlDataAdapter adapt = new SqlDataAdapter(commend))
								{
									connection.Open();

									commend.Parameters.AddWithValue("@Naam", Geluid_ID);

									using (connection)
									using (var reader = commend.ExecuteReader())
									{
										reader.Read();
										AantalperStopwoord.Add(reader.GetInt32(0));
									}
								}
							}
						}
					}
				}
		}
	}
}
