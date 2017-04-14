using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_submit_Click(object sender, EventArgs e)
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

        private bool CheckRange()
        {
            try
            {
                if (Convert.ToDouble(textBox_PB.Text) < Convert.ToDouble(textBox_PM.Text))
                    return false;
                if (Convert.ToDouble(textBox_PM.Text) < Convert.ToDouble(textBox_PS.Text))
                    return false;
                if (Convert.ToDouble(textBox_PS.Text) < Convert.ToDouble(textBox_ZR.Text))
                    return false;
                if (Convert.ToDouble(textBox_ZR.Text) < Convert.ToDouble(textBox_NS.Text))
                    return false;
                if (Convert.ToDouble(textBox_NS.Text) < Convert.ToDouble(textBox_NM.Text))
                    return false;
                if (Convert.ToDouble(textBox_NM.Text) < Convert.ToDouble(textBox_NB.Text))
                    return false;

                if (Convert.ToDouble(textBox_PB.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_PM.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_PS.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_ZR.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_NS.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_NM.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
                if (Convert.ToDouble(textBox_NB.Text) == Convert.ToDouble(textBox_X.Text))
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void CalculateMF()
        {
            int Scope = -1;
            List<Double> num = new List<double>();
            Double PB = Convert.ToDouble(textBox_PB.Text);
            Double PM = Convert.ToDouble(textBox_PM.Text);
            Double PS = Convert.ToDouble(textBox_PS.Text);
            Double ZR = Convert.ToDouble(textBox_ZR.Text);
            Double NS = Convert.ToDouble(textBox_NB.Text);
            Double NM = Convert.ToDouble(textBox_NM.Text);
            Double NB = Convert.ToDouble(textBox_NB.Text);
            Double X = Convert.ToDouble(textBox_X.Text);
            num.Add(PB);
            num.Add(PM);
            num.Add(PS);
            num.Add(ZR);
            num.Add(NS);
            num.Add(NM);
            num.Add(NB);
            Double line_a = 0, line_b = 0, curve_a = 0, curve_b = 0;
            for (int i = 0; i < num.Count - 1; i++)
            {
                if (num[i] > X && num[i + 1] < X)
                {
                    Scope = i + 1;
                    line_a = (num[i] - X) / (num[i] - num[i + 1]);
                    line_b = (X - num[i + 1]) / (num[i] - num[i + 1]);
                    Double tmp = 0;
                    if ((num[i] + num[i + 1]) <= X)
                    {
                        tmp = Math.Pow((X - num[i]) / (num[i] - num[i + 1]), 2) * 2;
                    }
                    else
                    {
                        tmp = Math.Pow((X - num[i + 1]) / (num[i] - num[i + 1]), 2) * 2;
                    }
                    curve_a = 1 - tmp;
                    curve_b = tmp;
                }
            }
            if (Scope == -1)
            {
                if (X > PB)
                {
                    Scope = 0;
                    line_a = 1;
                    line_b = 0;
                    curve_a = 1;
                    curve_b = 0;
                }
                else
                {
                    Scope = 9;
                    line_a = 0;
                    line_b = 1;
                    curve_a = 1;
                    curve_b = 0;
                }
            }
            String A, B;
            switch (Scope)
            {
                case 0: //X > PB
                    A = "pb";
                    B = "pb";
                    break;
                case 1: // PB > X > PM
                    A = "pb";
                    B = "pm";
                    break;
                case 2: // PM > X > PS
                    A = "pm";
                    B = "ps";
                    break;
                case 3: // PS > X > ZR
                    A = "ps";
                    B = "zr";
                    break;
                case 4: // ZR > X > NS
                    A = "zr";
                    B = "ns";
                    break;
                case 5: // NS > X > NM
                    A = "ns";
                    B = "nm";
                    break;
                case 6: // NM > X > NB
                    A = "nm";
                    B = "nb";
                    break;
                default: //NB > X
                    A = "nb";
                    B = "nb";
                    break;
            }
            richTextBox_out.Clear();
            richTextBox_out.Text = richTextBox_out.Text + "直線" + Environment.NewLine;
            richTextBox_out.Text = richTextBox_out.Text + "U" + A + " = " + line_a + Environment.NewLine;
            richTextBox_out.Text = richTextBox_out.Text + "U" + B + " = " + line_b + Environment.NewLine;
            richTextBox_out.Text = richTextBox_out.Text + "曲線" + Environment.NewLine;
            richTextBox_out.Text = richTextBox_out.Text + "U" + A + " = " + curve_a + Environment.NewLine;
            richTextBox_out.Text = richTextBox_out.Text + "U" + B + " = " + curve_b;
        }
    }
}
