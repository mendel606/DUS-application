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
	public partial class Main : Form
	{
		string Gebruikersnaam;
		public Main(string GN)
		{
			Gebruikersnaam = GN;
			InitializeComponent();

			Presentatie pres = new Presentatie();
			pres.GetPresName(Gebruikersnaam);
			
			for(int i = 0; i < pres.Presentatielist.Count; i++)
			{
				listBox1.Items.Add(pres.Presentatielist[i].ToString());
			}
		}

		private void Main_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			record rec = new record(Gebruikersnaam);
			rec.Show();
			this.Hide();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Gegevens ge = new Gegevens(Gebruikersnaam, listBox1.SelectedIndex.ToString());
				ge.Show();
				this.Hide();
			}
			catch
			{

			}
			
		}
	}
}
