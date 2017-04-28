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

namespace MF_fifth
{
    public partial class Form1 : Form
    {
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

        public String[,] table ={
        { "NB", "NB", "NB", "NS", "PB" } ,
        { "NB", "NS", "NS", "PS", "PB" } ,
        { "NB", "NS", "ZE", "PS", "PB" } ,
        { "NB", "NS", "PS", "PS", "PB" } ,
        { "NB", "NS", "PB", "PB", "PB" } };
        public Double[] Single_pole = { -10, -5, 0, 5, 10 };
        public static Double D = 1;
        public Double[] Y = new Double[500];
        public Double[] U = new Double[500];
        public E[] e = new E[500];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.e[0] = new E(1, 0);
            Y[0] = 0;
            U[0] = 0;
            Double[] E_ = new Double[500];
            Double[] E_dot = new Double[500];
            E_[0] = this.e[0].e;
            E_dot[0] = this.e[0].e_dot;
            Y[1] = CalculateNextY(Y[0], U[0]);
            for (int i = 1; i < 400; i++)
            {
                this.e[i] = FuzzyControl(this.Y[i], this.e[i - 1].e);
                this.U[i] = CalculateMF(this.e[i].e, this.e[i].e_dot);
                Y[i + 1] = CalculateNextY(Y[i], U[i]);
                E_[i] = this.e[i].e;
                E_dot[i] = this.e[i].e_dot;
            }
            //標題 最大數值
            Series series1 = new Series("y", 1);
            Series series2 = new Series("e", 1);
            Series series3 = new Series("e_dot", 1);

            //設定線條顏色
            series1.Color = Color.Blue;
            series2.Color = Color.Red;
            series3.Color = Color.Green;


            //折線圖
            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Line;


            //將數值新增至序列
            for (int index = 0; index < 400; index++)
            {
                series1.Points.AddXY(index, Y[index]);
                series2.Points.AddXY(index, E_[index]);
                series3.Points.AddXY(index, E_dot[index]);
            }

            //將序列新增到圖上
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);

            //series1.IsValueShownAsLabel = true;
            //series2.IsValueShownAsLabel = true;

            //標題
            this.chart1.Titles.Add("Fuzzy_定位控制");
        }

        private Double Rank_NP(String str)
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

        private int Rank_D(Double x)
        {
            Double[] num = { -1, -0.22, 0, 0.22, 1 };
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

        private E FuzzyControl(Double y, Double e)
        {
            Double e_next, e_dot_next;
            e_next = D - y;
            e_dot_next = e_next - e;
            return new E(e_next, e_dot_next);
        }

        private Double CalculateMF(Double e, Double e_dot)
        {
            Double[] Y1 = { 1, 0, 1, 0, 1 };
            Double[] Y2 = { 0, 1, 0, 1, 0 };
            Double[] X = { -1, -0.22, 0, 0.22, 1 };
            int zone_e = -1, zone_e_dot = -1;
            Double u1, u2, u3, u4;
            /*for (int i = 0; i < X.Length - 1; i++)
            {
                if (e >= X[i] && e < X[i + 1]) zone_e = i;
                if (e_dot >= X[i] && e_dot < X[i + 1]) zone_e_dot = i;
            }
            if (e == X[4] ) zone_e = 3;
            if (e_dot == X[4] ) zone_e_dot = 3;*/
            zone_e = Rank_D(e);
            zone_e_dot = Rank_D(e_dot);
            if (Y1[zone_e] > Y1[zone_e + 1])
            {
                u1 = Math.Abs(e - X[zone_e + 1]) / Math.Abs(X[zone_e] - X[zone_e + 1]);
                u2 = 1 - u1;
            }
            else
            {
                u1 = 1 - Math.Abs(e - X[zone_e]) / Math.Abs(X[zone_e] - X[zone_e + 1]);
                u2 = 1 - u1;
            }
            if (Y2[zone_e_dot] > Y2[zone_e_dot + 1])
            {
                u3 = Math.Abs(e_dot - X[zone_e_dot + 1]) / Math.Abs(X[zone_e_dot] - X[zone_e_dot + 1]);
                u4 = 1 - u3;
            }
            else
            {
                u3 = 1 - Math.Abs(e_dot - X[zone_e_dot]) / Math.Abs(X[zone_e_dot] - X[zone_e_dot + 1]);
                u4 = 1 - u3;
            }
            /*u1 = Math.Abs(X[zone_e + 1] - e) / Math.Abs(X[zone_e] - X[zone_e + 1]);
            u2 = 1 - u1;
            u3 = Math.Abs(X[zone_e_dot + 1] - e_dot ) / Math.Abs(X[zone_e_dot] - X[zone_e_dot + 1]);
            u4 = 1 - u3;*/
            Double u13 = (u1 * u3), u23 = (u2 * u3), u14 = (u1 * u4), u24 = (u2 * u4);
            Double u = ((u13 * Rank_NP(table[zone_e_dot, zone_e]) + u23 * Rank_NP(table[zone_e_dot, zone_e + 1]) + u14 * Rank_NP(table[zone_e_dot + 1, zone_e]) + u24 * Rank_NP(table[zone_e_dot + 1, zone_e + 1])) / (u13 + u23 + u14 + u24));
            return u;
        }

        private Double CalculateNextY(Double y, Double u)
        {
            return (1.01 * y + 0.01 * Math.Pow(y, 2) + 0.03 * u);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
