using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EQIS
{
    class Tools
    {
        /* 设置chart的值
         * szDt：横坐标
         * dm：数据对象
         * i：表示数据源 0:数据源1; 1:数据源2; 2:数据源3
         * byte：区别不同的数据 1:PM2.5; 2:PM10; 3:温度; 4;湿度
         */
        public static void setAValueOfChart(Chart chart, String szDt, int i, DataModel dm, byte flag)
        {
            if (chart.InvokeRequired)
            {
                Action act = null;
                if (chart.Series[i].Points.Count > 20)
                {
                    act = () => chart.Series[i].Points.RemoveAt(0);
                }
                if (flag == 1) act = () => chart.Series[i].Points.AddXY(szDt, dm.Pm25);
                if (flag == 2) act = () => chart.Series[i].Points.AddXY(szDt, dm.Pm10);
                if (flag == 3)
                {
                    if (dm.Temperature.ToString().Equals("0"))
                    {
                        act = () => chart.Series[i].Points.AddXY(szDt, "21");
                    }
                    else
                    {
                        act = () => chart.Series[i].Points.AddXY(szDt, dm.Temperature);
                    }
                }
                if (flag == 4)
                {
                    if(dm.Humidity.ToString().Equals("0"))
                    {
                        act = () => chart.Series[i].Points.AddXY(szDt, "40");
                    }
                    else
                    {
                        act = () => chart.Series[i].Points.AddXY(szDt, dm.Humidity);
                    }
                }
                chart.BeginInvoke(act);
            }
        }
        /* 设置chart的值
         * szDt：横坐标
         * dm：数据对象
         */
        public static void setAValueOfChart(Chart chart, String szDt, DataModel dm)
        {
            if (chart.InvokeRequired)
            {
                Action act = null;
                if (chart.Series[0].Points.Count > 20)
                {
                    act = () =>
                        {
                            chart.Series[0].Points.RemoveAt(0);
                            chart.Series[1].Points.RemoveAt(0);
                            chart.Series[2].Points.RemoveAt(0);
                            chart.Series[3].Points.RemoveAt(0);
                        };
                    chart.BeginInvoke(act);
                }
                act = () =>
                    {
                        chart.Series[0].Points.AddXY(szDt, dm.Pm25);
                        chart.Series[1].Points.AddXY(szDt, dm.Pm10);
                        if(dm.Temperature.ToString().Equals("0"))
                        {
                            chart.Series[2].Points.AddXY(szDt, "21");
                        }
                        else
                        {
                            chart.Series[2].Points.AddXY(szDt, dm.Temperature);
                        }
                        if(dm.Humidity.ToString().Equals("0"))
                        {
                            chart.Series[3].Points.AddXY(szDt, "40");
                        }
                        else
                        {
                            chart.Series[3].Points.AddXY(szDt, dm.Humidity);
                        }
                    };
                chart.BeginInvoke(act);
            }
        }

        public static void setAValueOfChartToQuery(Chart chart, String szDt, DataModel dm)
        {
            chart.Series[0].Points.AddXY(szDt, dm.Pm25);
            chart.Series[1].Points.AddXY(szDt, dm.Pm10);
            if(dm.Temperature.ToString().Equals("0"))
            {
                chart.Series[2].Points.AddXY(szDt, "20");
            }
            else
            {
                chart.Series[2].Points.AddXY(szDt, dm.Temperature);
            }
            if(dm.Humidity.ToString().Equals("0"))
            {
                chart.Series[3].Points.AddXY(szDt, "40");
            }
            else
            {
                chart.Series[3].Points.AddXY(szDt, dm.Humidity);
            }
        }
        //设置PM2.5的标签
        public static void setPM25(Label l, DataModel dm)
        {
            if (l.InvokeRequired)
            {
                Action act = () => l.Text = dm.Pm25.ToString() + "";
                l.BeginInvoke(act);
            }
        }
        //设置PM10的标签
        public static void setPM10(Label l, DataModel dm)
        {
            if (l.InvokeRequired)
            {
                Action act = () => l.Text = dm.Pm10.ToString() + "";
                l.BeginInvoke(act);
            }
        }
        //设置温度的标签
        public static void setTmp(Label l, DataModel dm)
        {
            if (l.InvokeRequired)
            {
                if (dm.Temperature.ToString().Equals("0"))
                { 
                    Action act = () => l.Text = "21" + "";
                    l.BeginInvoke(act);
                }
                else 
                {
                    Action act = () => l.Text = dm.Temperature.ToString() + "";
                    l.BeginInvoke(act);
                }
            }
        }
        //设置湿度的标签
        public static void setHumidity(Label l, DataModel dm)
        {
            if (l.InvokeRequired)
            {
                if (dm.Humidity.ToString().Equals("0"))
                {
                    Action act = () => l.Text = "40" + "";
                    l.BeginInvoke(act);
                }
                else
                {
                    Action act = () => l.Text = dm.Humidity.ToString() + "";
                    l.BeginInvoke(act);
                }
            }
        }
    }
}
