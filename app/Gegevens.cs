using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
	public partial class Gegevens : Form
	{
		string Gebruikersnaam;
		string Presentatienaam;
		List<int> AantalG = new List<int>();

		public Gegevens(string GN, string PN)
		{
			Gebruikersnaam = GN;
			Presentatienaam = PN;
			InitializeComponent();
			groupBox1.Text = PN;
			Write();
		}

		public void Write()
		{
			Presentatie pres = new Presentatie();
			
			pres.GetPres(Presentatienaam);
			AantalG.AddRange(pres.AantalperStopwoord);
			Gebruiker.Text = pres.Gebruikersnaam;
			Lengte.Text = pres.Lengte.ToShortTimeString();
			Aantal_woorden.Text = pres.Aantal_Woorden.ToString();
			Aantal_stopwoorden.Text = pres.Aantal_stopwoorden.ToString();

			for(int i = 0; i < pres.Stopwoorden.Count; i++)
			{
				listBox1.Items.Add(pres.Stopwoorden[i]);
			}
			
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Aantal.Text = AantalG[listBox1.SelectedIndex].ToString();
			}
			catch
			{
				listBox1.SelectedItem = null;
			}
			
		}
	}
}
