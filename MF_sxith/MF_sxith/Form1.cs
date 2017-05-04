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

namespace MF_sxith
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            private static Double[] Single_pole = { -10, -5, 0, 5, 10 };
            private static Double[] Y1 = { 1, 0, 1, 0, 1 };
            private static Double[] Y2 = { 0, 1, 0, 1, 0 };
            private static Double[] num = { -1, -0.22, 0, 0.22, 1 };
            private static Double[] FF = { -1, -0.07, 0, 0.07, 1 };
            private static double D = 1;

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

            public static Double get_table(int i, int j)
            {
                return Convert_Function(table[i, j]);
            }

            public static int Rank_D_A(Double x)
            {
                Double[] distanse = new Double[5];
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
                if (index == 4) return 3;
                return (index);
            }


            public static int Rank_D_B(Double x)
            {
                Double[] distanse = new Double[5];
                for (int i = 0; i < 5; i++)
                {
                    distanse[i] = Math.Abs(x - FF[i]);
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

            public static E FuzzyControlA(Double y, Double e)
            {
                Double e_next, e_dot_next;
                e_next = D - y;
                e_dot_next = e_next - e;
                return new E(e_next, e_dot_next);
            }

            public static X FuzzyControl_X(Double x1, Double x2, Double u)
            {
                Double x1_next, x2_next;
                x1_next = (x1 + 0.01 * x2 + 0.01 * u);
                x2_next = 0.1 * x1 + 0.97 * x2;
                return new X(x1_next, x2_next);
            }

            public static Double CalculateA(Double e, Double e_dot, Double u_previos)
            {
                int zone_e = -1, zone_e_dot = -1;
                Double u1, u2, u3, u4;
                zone_e = Rank_D_A(e);
                zone_e_dot = Rank_D_A(e_dot);
                if (Y1[zone_e] > Y1[zone_e + 1])
                {
                    u1 = Math.Abs(e - num[zone_e + 1]) / Math.Abs(num[zone_e] - num[zone_e + 1]);
                    u2 = 1 - u1;
                }
                else
                {
                    u1 = 1 - Math.Abs(e - num[zone_e]) / Math.Abs(num[zone_e] - num[zone_e + 1]);
                    u2 = 1 - u1;
                }
                if (Y2[zone_e_dot] > Y2[zone_e_dot + 1])
                {
                    u3 = Math.Abs(e_dot - num[zone_e_dot + 1]) / Math.Abs(num[zone_e_dot] - num[zone_e_dot + 1]);
                    u4 = 1 - u3;
                }
                else
                {
                    u3 = 1 - Math.Abs(e_dot - num[zone_e_dot]) / Math.Abs(num[zone_e_dot] - num[zone_e_dot + 1]);
                    u4 = 1 - u3;
                }
                Double u13 = (u1 * u3), u23 = (u2 * u3), u14 = (u1 * u4), u24 = (u2 * u4);
                Double u = ((u13 * get_table(zone_e_dot, zone_e) + u23 * get_table(zone_e_dot, zone_e + 1) + u14 * get_table(zone_e_dot + 1, zone_e) + u24 * get_table(zone_e_dot + 1, zone_e + 1)) / (u13 + u23 + u14 + u24));
                u = u + u_previos;
                if (u >= 10.0) u = 10.0;
                else if (u <= -10.0) u = -10.0;
                //if (u < 0.0) u = u * -1.0;
                return u;
            }

            public static Double CalculateB(Double e, Double e_dot, Double u_previos)
            {
                int zone_e = -1, zone_e_dot = -1;
                Double u1, u2, u3, u4;
                zone_e = Rank_D_B(e);
                zone_e_dot = Rank_D_B(e_dot);
                if (Y1[zone_e] > Y1[zone_e + 1])
                {
                    u1 = Math.Abs(e - FF[zone_e + 1]) / Math.Abs(FF[zone_e] - FF[zone_e + 1]);
                    u2 = 1 - u1;
                }
                else
                {
                    u1 = 1 - Math.Abs(e - FF[zone_e]) / Math.Abs(FF[zone_e] - FF[zone_e + 1]);
                    u2 = 1 - u1;
                }
                if (Y2[zone_e_dot] > Y2[zone_e_dot + 1])
                {
                    u3 = Math.Abs(e_dot - FF[zone_e_dot + 1]) / Math.Abs(FF[zone_e_dot] - FF[zone_e_dot + 1]);
                    u4 = 1 - u3;
                }
                else
                {
                    u3 = 1 - Math.Abs(e_dot - FF[zone_e_dot]) / Math.Abs(FF[zone_e_dot] - FF[zone_e_dot + 1]);
                    u4 = 1 - u3;
                }
                Double u13 = (u1 * u3), u23 = (u2 * u3), u14 = (u1 * u4), u24 = (u2 * u4);
                Double u = ((u13 * get_table(zone_e_dot, zone_e) + u23 * get_table(zone_e_dot, zone_e + 1) + u14 * get_table(zone_e_dot + 1, zone_e) + u24 * get_table(zone_e_dot + 1, zone_e + 1)) / (u13 + u23 + u14 + u24));
                u = u + u_previos;
                if (u > 10.0) u = 10.0;
                else if (u < -10.0) u = -10.0;
                //if (u < 0.0) u = u * -1.0;
                return u;
            }

            public static Double CalculateNextY(Double y, Double u)
            {
                return (1.01 * y + 0.01 * Math.Pow(y, 2) + 0.03 * u);
            }

            public static Double CalculateNextY(Double x)
            {
                return x;
            }
        }

        public static Double D = 1;


        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Fuzzy_like PID定位控制";
            System1(chart1);
            System2(chart2);
        }

        private void System1(Chart chart)
        {
            Double[] Y = new Double[500];
            Double[] U = new Double[500];
            E[] e = new E[500];
            e[0] = new E(1, 0);
            Y[0] = 0;
            U[0] = 0;
            Double[] E_ = new Double[500];
            Double[] E_dot = new Double[500];
            E_[0] = e[0].e;
            E_dot[0] = e[0].e_dot;
            for (int i = 1; i < 400; i++)
            {
                Y[i] = Fuzzy.CalculateNextY(Y[i - 1], U[i - 1]);
                e[i] = Fuzzy.FuzzyControlA(Y[i], e[i - 1].e);
                U[i] = Fuzzy.CalculateA(e[i].e, e[i].e_dot, U[i - 1]);

                E_[i] = e[i].e;
                E_dot[i] = e[i].e_dot;
            }
            //標題 最大數值
            Series series1 = new Series("y", 1);
            Series series2 = new Series("e", 1);
            Series series3 = new Series("e_dot", 1);
            Series series4 = new Series("u", 1);

            //設定線條顏色
            series1.Color = Color.Blue;
            series2.Color = Color.Red;
            series3.Color = Color.Green;
            series4.Color = Color.Yellow;


            //折線圖
            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Line;
            series4.ChartType = SeriesChartType.Line;


            //將數值新增至序列
            for (int index = 0; index < 400; index++)
            {
                series1.Points.AddXY(index, Y[index]);
                series2.Points.AddXY(index, E_[index]);
                series3.Points.AddXY(index, E_dot[index]);
                series4.Points.AddXY(index, U[index]);
            }

            //將序列新增到圖上
            chart.Series.Add(series1);
            //this.chart1.Series.Add(series2);
            //this.chart1.Series.Add(series3);
            //this.chart1.Series.Add(series4);

            //series1.IsValueShownAsLabel = true;
            //series2.IsValueShownAsLabel = true;

            //標題
            chart.Titles.Add("System1");
        }

        private void System2(Chart chart)
        {
            Double[] Y = new Double[500];
            Double[] U = new Double[500];
            E[] e = new E[500];
            X[] x = new X[500];
            e[0] = new E(1, 0);
            x[0] = new X(0, 0);
            Y[0] = 0;
            U[0] = 0;
            Double[] E_ = new Double[500];
            Double[] E_dot = new Double[500];
            E_[0] = e[0].e;
            E_dot[0] = e[0].e_dot;
            for (int i = 1; i < 400; i++)
            {
                x[i] = Fuzzy.FuzzyControl_X(x[i - 1].x1, x[i - 1].x2, U[i - 1]);
                Y[i] = Fuzzy.CalculateNextY(x[i].x1);
                e[i] = Fuzzy.FuzzyControlA(Y[i], e[i - 1].e);
                U[i] = Fuzzy.CalculateB(e[i].e, e[i].e_dot, U[i - 1]);

                E_[i] = e[i].e;
                E_dot[i] = e[i].e_dot;
            }
            //標題 最大數值
            Series series1 = new Series("y", 1);
            Series series2 = new Series("e", 1);
            Series series3 = new Series("e_dot", 1);
            Series series4 = new Series("u", 1);

            //設定線條顏色
            series1.Color = Color.Blue;
            series2.Color = Color.Red;
            series3.Color = Color.Green;
            series4.Color = Color.Yellow;


            //折線圖
            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Line;
            series4.ChartType = SeriesChartType.Line;


            //將數值新增至序列
            for (int index = 0; index < 400; index++)
            {
                series1.Points.AddXY(index, Y[index]);
                series2.Points.AddXY(index, E_[index]);
                series3.Points.AddXY(index, E_dot[index]);
                series4.Points.AddXY(index, U[index]);
            }

            //將序列新增到圖上
            chart.Series.Add(series1);
            //chart.Series.Add(series2);
            //chart.Series.Add(series3);
            //chart.Series.Add(series4);

            //series1.IsValueShownAsLabel = true;
            //series2.IsValueShownAsLabel = true;

            //標題
            chart.Titles.Add("System2");
        }
    }
}
