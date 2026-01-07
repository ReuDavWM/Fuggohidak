using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form2 : Form
    {
        private List<Fuggohid> hidak;
        private Form1 foForm;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            foForm = f1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hidak = foForm.GetHidak(); 

            listBox1.Items.Clear();
            foreach (var hid in hidak)
            {
                listBox1.Items.Add(hid.Nev);
            }

            comboBox1.Items.Clear();
            var orszagok = hidak.Select(h => h.Orszag).Distinct().ToList();
            foreach (var orszag in orszagok)
            {
                comboBox1.Items.Add(orszag);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string kivalasztott = comboBox1.SelectedItem.ToString();

            listBox1.Items.Clear();

            foreach (var item in hidak)
            {
                if (item.Orszag == kivalasztott)
                {
                    listBox1.Items.Add(item.Nev);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string kivalasztott = comboBox1.SelectedItem.ToString();

            listBox1.Items.Clear();

            foreach (var item in hidak)
            {
                if (item.Hossz >= 1000 && item.Orszag == kivalasztott)
                {
                    listBox1.Items.Add(item.Nev);
                }
            }
        }
    }
}
