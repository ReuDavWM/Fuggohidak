using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private List<Fuggohid> hidak = new List<Fuggohid>();
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("fuggohidak.csv", Encoding.UTF8);
            
                sr.ReadLine(); // fejléc átugrása
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    hidak.Add(new Fuggohid(sor));
                    listBox1.Items.Add(hidak[hidak.Count - 1].Nev);
                }
            

        }
        public List<Fuggohid> GetHidak()
        {
            return hidak;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kivalasztott = listBox1.SelectedItem.ToString();
            string kivalasztottNev = listBox1.SelectedItem.ToString();

            var hidAdatok = hidak.FirstOrDefault(h => h.Nev == kivalasztottNev);

          
                textBox2.Text = hidAdatok.Hely;
                textBox3.Text = hidAdatok.Orszag;
                textBox4.Text = hidAdatok.Hossz.ToString();
                textBox5.Text = hidAdatok.Ev.ToString();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var _2000elott = hidak.Where(h => h.Ev < 2000).ToList();

            listBox1.Items.Clear();
            _2000elott.Select(h => h.Nev).ToList()
                .ForEach(h =>
                {
                    listBox1.Items.Add(h);
                });

            textBox1.Text = _2000elott.Count.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var _2000utan = hidak.Where(h => h.Ev >= 2000).ToList();

            listBox1.Items.Clear();
            _2000utan.Select(h => h.Nev).ToList()
                .ForEach(h =>
                {
                    listBox1.Items.Add(h);
                });

            textBox1.Text = _2000utan.Count.ToString();
        }

        private void keresésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 kereses = new Form2(this);
            kereses.FormClosed += Kereses_FormClosed;
            kereses.Show();
        }
        // létre kell hozni ezt a függvényt
        private void Kereses_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
