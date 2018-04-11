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
	public partial class Signup : Form
	{
		public Signup()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Login sign = new Login();
			sign.Show();
			this.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			User signup = new User(textBox1.Text, textBox2.Text);
			signup.Signup();
			Main main = new Main(textBox1.Text);
			main.Show();
			this.Hide();
		}
	}
}
