using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int[,] dizi = new int[9, 9];
        int Alan, puan = 0;
        bool hamle = false;

        public Form1()
        {
            InitializeComponent();
        }
        public void Sifirla()
        {
            for (int i = 0; i < Alan; i++)
            {
                tableLayoutPanel1.Controls[i].BackColor = Color.White;
            }
            hamle = false;
        }
        public void Hamleler(Button btn)
        {  int i;
           for(i=0; i<Alan;i++)
            {
                if (puan.ToString() == tableLayoutPanel1.Controls[i].Text)
                    break;
            }
            if ( 0 <= ( i - (2 * tableLayoutPanel1.ColumnCount) + 1) && (tableLayoutPanel1.ColumnCount-1)-(i%tableLayoutPanel1.ColumnCount) >=1 && tableLayoutPanel1.Controls[(i - (2 * tableLayoutPanel1.ColumnCount) + 1)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i - (2 * tableLayoutPanel1.ColumnCount) + 1].Enabled = true;
                tableLayoutPanel1.Controls[i - (2 * tableLayoutPanel1.ColumnCount) + 1].BackColor = Color.Orange;
                hamle = true;
            }
            if (0 <= (i - (2 * tableLayoutPanel1.ColumnCount) - 1) && (i%tableLayoutPanel1.ColumnCount)>=1 && tableLayoutPanel1.Controls[(i - (2 * tableLayoutPanel1.ColumnCount) - 1)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i - (2 * tableLayoutPanel1.ColumnCount) - 1].Enabled = true;
                tableLayoutPanel1.Controls[i - (2 * tableLayoutPanel1.ColumnCount) - 1].BackColor = Color.Orange;
                hamle = true;
            }
            if (  (i + (2 * tableLayoutPanel1.ColumnCount) + 1) < tableLayoutPanel1.ColumnCount* tableLayoutPanel1.ColumnCount && (tableLayoutPanel1.ColumnCount - 1) - (i % tableLayoutPanel1.ColumnCount) >= 1 && tableLayoutPanel1.Controls[(i + (2 * tableLayoutPanel1.ColumnCount) + 1)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i + (2 * tableLayoutPanel1.ColumnCount) + 1].Enabled = true;
                tableLayoutPanel1.Controls[i + (2 * tableLayoutPanel1.ColumnCount) + 1].BackColor = Color.Orange;
                hamle = true;
            }
            if ((i + (2 * tableLayoutPanel1.ColumnCount) - 1) < tableLayoutPanel1.ColumnCount * tableLayoutPanel1.ColumnCount && (i%tableLayoutPanel1.ColumnCount)>=1 && tableLayoutPanel1.Controls[(i + (2 * tableLayoutPanel1.ColumnCount) - 1)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i + (2 * tableLayoutPanel1.ColumnCount) - 1].Enabled = true;
                tableLayoutPanel1.Controls[i + (2 * tableLayoutPanel1.ColumnCount) - 1].BackColor = Color.Orange;
                hamle = true;
            }
            if(2<= (i% tableLayoutPanel1.ColumnCount) && 0 <= (i - tableLayoutPanel1.ColumnCount - 2) && tableLayoutPanel1.Controls[(i - tableLayoutPanel1.ColumnCount - 2)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i - tableLayoutPanel1.ColumnCount - 2].Enabled = true;
                tableLayoutPanel1.Controls[i - tableLayoutPanel1.ColumnCount - 2].BackColor = Color.Orange;
                hamle = true;
            }
            if ((tableLayoutPanel1.ColumnCount-1)-(i%tableLayoutPanel1.ColumnCount) >=2 && 0 <= (i - tableLayoutPanel1.ColumnCount + 2) && tableLayoutPanel1.Controls[(i - tableLayoutPanel1.ColumnCount + 2)].Tag.ToString() == 0.ToString()) 
            {
                tableLayoutPanel1.Controls[i - tableLayoutPanel1.ColumnCount + 2].Enabled = true;
                tableLayoutPanel1.Controls[i - tableLayoutPanel1.ColumnCount + 2].BackColor = Color.Orange;
                hamle = true;
            }
            if (2 <= (i % tableLayoutPanel1.ColumnCount) && tableLayoutPanel1.ColumnCount*tableLayoutPanel1.ColumnCount > (i + tableLayoutPanel1.ColumnCount - 2) && tableLayoutPanel1.Controls[(i + tableLayoutPanel1.ColumnCount - 2)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i + tableLayoutPanel1.ColumnCount - 2].Enabled = true;
                tableLayoutPanel1.Controls[i + tableLayoutPanel1.ColumnCount - 2].BackColor = Color.Orange;
                hamle = true;
            }
            if ((tableLayoutPanel1.ColumnCount - 1) - (i % tableLayoutPanel1.ColumnCount) >= 2 && tableLayoutPanel1.ColumnCount*tableLayoutPanel1.ColumnCount > (i + tableLayoutPanel1.ColumnCount + 2) && tableLayoutPanel1.Controls[(i + tableLayoutPanel1.ColumnCount + 2)].Tag.ToString() == 0.ToString())
            {
                tableLayoutPanel1.Controls[i + tableLayoutPanel1.ColumnCount + 2].Enabled = true;
                tableLayoutPanel1.Controls[i + tableLayoutPanel1.ColumnCount + 2].BackColor = Color.Orange;
                hamle = true;
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            puan = 0;
            label1.Text = "Puan : 0";
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 5;
            label2.Text = "Size : " + tableLayoutPanel1.ColumnCount + " * " + tableLayoutPanel1.ColumnCount;
            Alan = 25;
            for (int i = 0; i < Alan; i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Tag = 0;
                button.Click += Button_Click;
                tableLayoutPanel1.Controls.Add(button);
                button.BackColor = Color.White;
            }
            this.Size = new Size(tableLayoutPanel1.ColumnCount * 45, tableLayoutPanel1.ColumnCount * 50 + 65);
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            puan++;
            label1.Text = "Puan : " + puan;
            tiklanan.Text = puan.ToString();
            Sifirla();
            for (int i = 0; i < Alan; i++)
            {
                tableLayoutPanel1.Controls[i].Enabled = false;
            }
            tiklanan.Enabled = false;
            tiklanan.Tag = 1;
            Hamleler(tiklanan);
            if (!hamle)
            {
                if (puan == Alan)
                {
                    MessageBox.Show("Kazandınız :)");
                }
                else
                {
                    MessageBox.Show("Kaybettiniz :(");
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            label1.Text = "Puan : 0";
            puan = 0;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 6;
            label2.Text = "Size : " + tableLayoutPanel1.ColumnCount + " * " + tableLayoutPanel1.ColumnCount;
            Alan = 36;
            for (int i = 0; i < Alan; i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Tag = 0;
                button.Click += Button_Click;
                tableLayoutPanel1.Controls.Add(button);
            }
            this.Size = new Size(tableLayoutPanel1.ColumnCount * 44, tableLayoutPanel1.ColumnCount * 50 + 55);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            label1.Text = "Puan : 0";
            puan = 0;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 7;
            label2.Text = "Size : " + tableLayoutPanel1.ColumnCount + " * " + tableLayoutPanel1.ColumnCount;
            Alan = 49;
            for (int i = 0; i < Alan; i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Tag = 0;
                button.Click += Button_Click;
                tableLayoutPanel1.Controls.Add(button);
            }
            this.Size = new Size(tableLayoutPanel1.ColumnCount * 43, tableLayoutPanel1.ColumnCount * 50 + 45);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            label1.Text = "Puan : 0";
            puan = 0;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 8;
            label2.Text = "Size : " + tableLayoutPanel1.ColumnCount + " * " + tableLayoutPanel1.ColumnCount;
            Alan = 64;
            for (int i = 0; i < Alan; i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Tag = 0;
                button.Click += Button_Click;
                tableLayoutPanel1.Controls.Add(button);
            }
            this.Size = new Size(tableLayoutPanel1.ColumnCount * 42, tableLayoutPanel1.ColumnCount * 50 +35);
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            label1.Text = "Puan : 0";
            puan = 0;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 9;
            label2.Text = "Size : " + tableLayoutPanel1.ColumnCount + " * " + tableLayoutPanel1.ColumnCount;
            Alan = 81;
            for (int i = 0; i < Alan; i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 50);
                button.Tag = 0;
                button.Click += Button_Click;
                tableLayoutPanel1.Controls.Add(button);
            }
            this.Size = new Size(tableLayoutPanel1.ColumnCount *40, tableLayoutPanel1.ColumnCount * 50+25);
        }
    }
}
