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
	public partial class record : Form
	{
		DateTime time = new DateTime();
		public List<string> stopwoorden = new List<string>();
		public List<int> aantalstopwoorden = new List<int>();
		string Gebruikersnaam;

		public record(string GN)
		{
			Gebruikersnaam = GN;
			InitializeComponent();
			Presentatie pres = new Presentatie();
			pres.Getall();
			for(int i = 0; i < pres.Stopwoorden.Count; i++)
			{
				checkedListBox1.Items.Add(pres.Stopwoorden[i]);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for(int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
			{
				stopwoorden.Add(checkedListBox1.CheckedItems[i].ToString());
			}

			timer1.Start();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Gegevens.Enabled = true;
			timer1.Stop();
			label1.Text = time.ToShortTimeString();
			Generate();
		}

		private void Gegevens_Click(object sender, EventArgs e)
		{
			Gegevens ge = new Gegevens(Gebruikersnaam, textBox1.Text);
			ge.Show();
			this.Hide();
		}


		private void timer1_Tick(object sender, EventArgs e)
		{
			time = time.AddSeconds(1);
			label1.Text = time.ToShortTimeString();
		}

		private void Generate()
		{
			int totaal = 0;
			int count = 0;
			string text = "hallo ik ben mendel en ik heet mendel maar en dus oke uhm en waardoor ik wil en dus maar maar uhm uhm uhm oke doei"; //eigenlijk omgezette tekst
			for(int i = 0; i < stopwoorden.Count; i++)
			{
				if (text.Contains(stopwoorden[i]))
				{
					count = (text.Length - text.Replace(stopwoorden[i], "").Length) / stopwoorden[i].Length;
					totaal = totaal + count;
				}
				else
				{
					count = 0;
				}
				aantalstopwoorden.Add(count);
			}

			char[] delimiters = new char[] { ' '};
			int aantal = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

			Presentatie pres = new Presentatie(textBox1.Text, time, aantal, totaal);
			pres.Add(Gebruikersnaam);

			for (int i = 0; i < aantalstopwoorden.Count; i++)
			{
				Presentatie sample = new Presentatie(textBox1.Text, stopwoorden[i], aantalstopwoorden[i]);
				sample.Sample();
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Main main = new Main(Gebruikersnaam);
			main.Show();
			this.Hide();
		}
	}
}
