using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF_fourth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String[,] table ={ 
        { "NB", "NB", "NB", "NS", "PB" } ,
        { "NB", "NS", "NS", "ZZ", "PB" } ,
        { "NB", "NS", "ZZ", "PS", "PB" } ,
        { "NB", "ZZ", "PN", "PS", "PB" } ,
        { "ZB", "PS", "PB", "PB", "PB" } };
        public Double[] Single_pole = { -10, -5, 0, 5, 10 };

        private void Form1_Load(object sender, EventArgs e)
        {
            int N = 5;

            richTextBox_table_out.AppendText("    ");
            for (int i = 0; i < N; i++)
            {
                richTextBox_table_out.AppendText(String.Format("{0,4}", RankCovert(i)));

            }
            richTextBox_table_out.AppendText("\n");
            for (int i = 0; i < N; i++)
            {
                richTextBox_table_out.AppendText(String.Format("{0,4}", RankCovert(i)));
                for (int j = 0; j < N; j++)
                {
                    richTextBox_table_out.AppendText(String.Format("{0,4}", table[i, j]));
                }
                richTextBox_table_out.AppendText("\n");
            }
        }

        private int Rank_D(Double x)
        {
            Double[] num = { 0, 0.25, 0.5, 0.75, 1 };
            Double[] distanse = { 0, 0.25, 0.5, 0.75, 1 };
            for (int i = 0; i < 5; i++)
            {
                distanse[i] = Math.Abs(x - num[i]);
            }
            Double min = distanse[0];
            int index = 0;
            for (int i = 1; i < 5; i++)
            {
                if (distanse[i] < min)
                {
                    min = distanse[i];
                    index = i;
                }
            }
            return (index + 1);
        }

        private String Rank_NP(Double x)
        {
            Double[] num = { -10, -5, 0, 5, 10 };
            Double[] distanse = new double[5];
            for (int i = 0; i < 5; i++)
            {
                distanse[i] = Math.Abs(x - num[i]);
            }
            Double min = distanse[0];
            int index = 0;
            for (int i = 1; i < 5; i++)
            {
                if (distanse[i] < min)
                {
                    min = distanse[i];
                    index = i;
                }
            }
            switch (index)
            {
                case 0:
                    return "NB";
                case 1:
                    return "NS";
                case 2:
                    return "ZZ";
                case 3:
                    return "PS";
                case 4:
                    return "PB";
                default:
                    return "PB";
            }
        }

        private Double Rank_NP(String str)
        {
            switch (str)
            {
                case "NB":
                    return Single_pole[0];
                case "NS":
                    return Single_pole[1];
                case "ZZ":
                    return Single_pole[2];
                case "PS":
                    return Single_pole[3];
                case "PB":
                    return Single_pole[4];
                default:
                    return Single_pole[0];
            }
        }

        private String RankCovert(int i)
        {
            switch (i)
            {
                case 0: return "Vs";
                case 1: return "S";
                case 2: return "M";
                case 3: return "L";
                case 4: return "VL";
                default: return "";
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (CheckRange())
            {
                CalculateMF();
            }
            else
            {
                MessageBox.Show("數值範圍錯誤", "錯誤");
            }
        }

        private void CalculateMF()
        {
            Double[] Y2 = { 1, 0, 1, 0, 1 };
            Double[] Y1 = { 0, 1, 0, 1, 0 };
            Double[] X = { -1, -0.25, 0, 0.25, 1 };
            Double e = Convert.ToDouble(textBox_X1.Text);
            Double e_dot = Convert.ToDouble(textBox_X2.Text);
            int zone_e = -1, zone_e_dot = -1;
            Double u1, u2, u3, u4;
            for (int i = 0; i < X.Length - 1; i++)
            {
                if (e >= X[i] && e < X[i + 1]) zone_e = i;
                if (e_dot >= X[i] && e_dot < X[i + 1]) zone_e_dot = i;
            }
            if (Y1[zone_e] > Y1[zone_e + 1])
            {
                u1 = (e - X[zone_e]) / 0.25;
                u2 = 1 - u1;
            }
            else
            {
                u1 = 1 - (e - X[zone_e]) / 0.25;
                u2 = 1 - u1;
            }
            if (Y2[zone_e_dot] > Y2[zone_e_dot + 1])
            {
                u3 = (e_dot - X[zone_e_dot]) / 0.25;
                u4 = 1 - u3;
            }
            else
            {
                u3 = 1 - (e_dot - X[zone_e_dot]) / 0.25;
                u4 = 1 - u3;
            }
            Double u13 = (u1 * u3), u23 = (u2 * u3), u14 = (u1 * u4), u24 = (u2 * u4);
            richTextBox_MF_out.Text += "U1 =   " + u1.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U2 =   " + u2.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U3 =   " + u3.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U4 =   " + u4.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U13 =   " + u13.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U23 =   " + u23.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U14 =   " + u14.ToString("0.00") + "\n";
            richTextBox_MF_out.Text += "U24 =   " + u24.ToString("0.00") + "\n";
            Double U = (u13 * Rank_NP(table[zone_e_dot, zone_e]) + u23 * Rank_NP(table[zone_e_dot, zone_e]) + u14 * Rank_NP(table[zone_e_dot + 1, zone_e]) + u24 * Rank_NP(table[zone_e_dot + 1, zone_e + 1])) / (u13 + u23 + u14 + u24);
            richTextBox_MF_out.Text += "U =   " + U;
        }

        private bool CheckRange()
        {
            try
            {
                if (Convert.ToDouble(textBox_X1.Text) < -1)
                    return false;
                if (Convert.ToDouble(textBox_X1.Text) > 1)
                    return false;
                if (Convert.ToDouble(textBox_X2.Text) < -1)
                    return false;
                if (Convert.ToDouble(textBox_X2.Text) > 1)
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
