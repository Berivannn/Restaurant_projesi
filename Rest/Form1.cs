using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        cGenel gnl = new cGenel();
        private void btngiris_Click(object sender, EventArgs e)
        {
                cPersoneller p = new cPersoneller();
                bool result = p.PersonelEntryControl(textBox1.Text,gnl._personelid);

                if (result)
                {
                    this.Hide();
                    formMenu menu = new formMenu();
                    menu.Show();
                }
         }
        private void Form1_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.PersonelGetbyInformation(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)comboBox1.SelectedItem;
            gnl._personelid = p.Personelid;
            gnl._gorevid = p.Personelgorevid;
        }
    }
}
