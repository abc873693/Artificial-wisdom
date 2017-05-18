using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MF_eighth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Double D = 1;
        public static int MAX = 700;

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "作業八-Fuzzy 強健性控制";
            System1(chart_out);
        }

        public class E
        {
            public Double e = 0;
            public Double e_dot = 0;
            public E(Double e, Double e_dot)
            {
                this.e = e;
                this.e_dot = e_dot;
            }
            public E()
            {
                this.e = 0;
                this.e_dot = 0;
            }
        }

        public class X
        {
            public Double x1 = 0;
            public Double x2 = 0;
            public X(Double e, Double e_dot)
            {
                this.x1 = e;
                this.x2 = e_dot;
            }
            public X()
            {
                this.x1 = 0;
                this.x2 = 0;
            }
        }

        public class Fuzzy
        {
            private static String[,] table ={
            { "NB", "NB", "NB", "NS", "PB" } ,
            { "NB", "NS", "NS", "PS", "PB" } ,
            { "NB", "NS", "ZE", "PS", "PB" } ,
            { "NB", "NS", "PS", "PS", "PB" } ,
            { "NB", "NS", "PB", "PB", "PB" } };
            public static Double[] Single_pole = { -10, -0.8, 0, 0.8, 10 };
            private static Double[] Y1 = { 1, 0, 1, 0, 1 };
            private static Double[] Y2 = { 0, 1, 0, 1, 0 };
            private static Double[] num_A = { -1, -0.5, 0, 0.5, 1 };
            private static Double[] num_A_dot = { -0.3, -0.1, 0, 0.1, 0.3 };

            public static Double Convert_Function(String str)
            {
                switch (str)
                {
                    case "NB":
                        return Single_pole[0];
                    case "NS":
                        return Single_pole[1];
                    case "ZE":
                        return Single_pole[2];
                    case "PS":
                        return Single_pole[3];
                    case "PB":
                        return Single_pole[4];
                    default:
                        return Single_pole[0];
                }
            }

            public static Double get_table_A(int i, int j)
            {
                return Convert_Function(table[i, j]);
            }

            public static int Rank_D_A(Double x)
            {
                Double[] distanse = new Double[5];
                for (int i = 0; i < 5; i++)
                {
                    distanse[i] = Math.Abs(x - num_A[i]);
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
                if (index == 4) return 3;
                return (index);
            }

            public static int Rank_D_A_dot(Double x)
            {
                Double[] distanse = new Double[5];
                for (int i = 0; i < 5; i++)
                {
                    distanse[i] = Math.Abs(x - num_A_dot[i]);
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
                if (index == 4) return 3;
                return (index);
            }

            public static E FuzzyControl_A(int k, Double y_next, Double e)
            {
                Double e_next, e_dot_next;
                e_next = CalculateNextK_A(k) - y_next;
                e_dot_next = e_next - e;
                return new E(e_next, e_dot_next);
            }

            public static Double CalculateU_A(Double e, Double e_dot, Double u_previos)
            {
                int zone_e = -1, zone_e_dot = -1;
                Double u1, u2, u3, u4;
                zone_e = Rank_D_A(e);
                zone_e_dot = Rank_D_A_dot(e_dot);
                if (Y1[zone_e] > Y1[zone_e + 1])
                {
                    if (e_dot <= num_A[0]) u1 = 1;
                    else if (e_dot >= num_A[4]) u1 = 0;
                    else u1 = Math.Abs(e - num_A[zone_e + 1]) / Math.Abs(num_A[zone_e] - num_A[zone_e + 1]);
                    u2 = 1 - u1;
                }
                else
                {
                    u2 = Math.Abs(e - num_A[zone_e]) / Math.Abs(num_A[zone_e] - num_A[zone_e + 1]);
                    u1 = 1 - u2;
                }
                if (Y1[zone_e_dot] > Y1[zone_e_dot + 1])
                {
                    if (e_dot <= num_A_dot[0]) u3 = 1;
                    else if (e_dot >= num_A_dot[4]) u3 = 0;
                    else u3 = Math.Abs(e_dot - num_A_dot[zone_e_dot + 1]) / Math.Abs(num_A_dot[zone_e_dot] - num_A_dot[zone_e_dot + 1]);
                    u4 = 1 - u3;
                }
                else
                {
                    u4 = Math.Abs(e_dot - num_A_dot[zone_e_dot]) / Math.Abs(num_A_dot[zone_e_dot] - num_A_dot[zone_e_dot + 1]);
                    u3 = 1 - u4;
                }
                Double u13 = (u1 * u3), u23 = (u2 * u3), u14 = (u1 * u4), u24 = (u2 * u4);
                Double u = ((u13 * get_table_A(zone_e_dot, zone_e) + u23 * get_table_A(zone_e_dot, zone_e + 1) + u14 * get_table_A(zone_e_dot + 1, zone_e) + u24 * get_table_A(zone_e_dot + 1, zone_e + 1)) / (u13 + u23 + u14 + u24));
                u = u + u_previos;
                if (u >= 10.0) u = 10.0;
                else if (u <= -10.0) u = -10.0;
                //if (u < 0.0) u = u * -1.0;
                return u;
            }

            public static Double CalculateNextY(Double y_previos, Double u_previos, Double num)
            {
                return (1.01 * y_previos + 0.01 * Math.Pow(y_previos, 2.0) + num * u_previos);
            }

            public static Double CalculateNextY(Double x)
            {
                return x;
            }

            public static Double CalculateNextK_A(Double k)
            {
                if (0 <= k && k <= 200) return 1;
                else if (201 <= k && k <= 400) return 2;
                else return -1;
            }

             public static Double CalculateNextK_B(Double k)
            {
                return Math.Sin(2 * Math.PI * k / 200.0);
            }

        }

        private void System1(Chart chartY)
        {
            Double[] D = new Double[MAX];
            Double[] num = { 0.03, 0.02, 0.01 };
            Color[] colors= { Color.Blue, Color.Green,Color.Red,Color.Gray };

            for (int i = 0; i < 600; i++)
            {
                D[i + 1] = Fuzzy.CalculateNextK_A(i);
            }
            //標題 最大數值
            Series series_D = new Series("D", 1);

            //設定線條顏色
            series_D.Color = Color.Yellow;
        
            //折線圖
            series_D.ChartType = SeriesChartType.Line;


            //將數值新增至序列
            for (int index = 0; index < MAX; index++)
            {
                series_D.Points.AddXY(index, D[index]);
            }

            //將序列新增到圖上
            chart_out.Series.Add(series_D);

            for (int index = 0; index < num.Length; index++)
            {
                int max = 0;
                Double[] Y = new Double[MAX];
                Double[] U = new Double[MAX];
                E[] e = new E[MAX];
                e[0] = new E(0, 0);
                Y[0] = 0;
                U[0] = 0;
                Double[] E_ = new Double[MAX];
                Double[] E_dot = new Double[MAX];
                E_[0] = e[0].e;
                E_dot[0] = e[0].e_dot;
                for (int i = 0; i < 600; i++)
                {
                    try
                    {
                        e[i + 1] = Fuzzy.FuzzyControl_A(i, Y[i], e[i].e);
                        U[i + 1] = Fuzzy.CalculateU_A(e[i + 1].e, e[i + 1].e_dot, U[i]);
                        Y[i + 1] = Fuzzy.CalculateNextY(Y[i], U[i + 1], num[index]);
                        E_[i] = e[i].e;
                        E_dot[i] = e[i].e_dot;
                        max = i;
                        if (Y[i + 1] >= 2.4) {
                            i = -1;
                            Fuzzy.Single_pole[1] -= 0.1;
                            Fuzzy.Single_pole[3] += 0.1;
                            textBox1.Text = "";
                            foreach (double pole in Fuzzy.Single_pole)
                            {
                                textBox1.Text += pole + " ";
                            }
                            continue;
                            //break;
                        }
                    }
                    catch(Exception ex)
                    {
                        break;
                    }
                    
                }
                //標題 最大數值
                Series series1 = new Series(num[index].ToString(), 1);

                //設定線條顏色
                series1.Color = colors[index];


                //折線圖
                series1.ChartType = SeriesChartType.Line;


                //將數值新增至序列
                for (int x = 0; x < max; x++)
                {
                    series1.Points.AddXY(x, Y[x]);
                }

                //將序列新增到圖上
                chartY.Series.Add(series1);

                //series1.IsValueShownAsLabel = true;
                //series2.IsValueShownAsLabel = true;
            }

            //標題
            chartY.Titles.Add("System1");
        }
    }
}
