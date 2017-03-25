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

namespace TestChartAndView
{
    public partial class Form2 : Form
    {
        private ToolTip tooptip = null;
        public Form2()
        {
            InitializeComponent();
            tooptip = new ToolTip();
            double[] dy = { 32, 43, 65, 76, 87, 98, 32, 65, 32, 5, 23, 43, 41, 76, 19, 47, 39, 18, 40, 58, 
                              12, 76, 39, 37, 59, 29, 48, 29, 58, 45, 38, 93, 12, 73, 62, 45, 69, 28, 12, 19};
            for (int i = 0; i < dy.Count(); i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, dy[i]);
            }

        }

        private void chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                //this.labelx.Text = dp.XValue.ToString();
                //this.labely.Text = dp.YValues[0].ToString();
                tooptip.Show("x:" + dp.XValue + " y:" + dp.YValues[0], this.chart1, e.X, e.Y);
                //if (!this.labelx.Text.Equals(e.X.ToString()) && !this.labely.Text.Equals(e.Y.ToString()))
                //{
                //    this.labelx.Text = e.X.ToString();
                //    this.labely.Text = e.Y.ToString();
                //    toolTip1.Show("x:" + e.X + " y:" + e.Y, button1);
                //}

            }
        }
    }
}
