namespace LearnSerialPort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labKL10 = new System.Windows.Forms.Label();
            this.labKL1_0 = new System.Windows.Forms.Label();
            this.labPM10 = new System.Windows.Forms.Label();
            this.labPM10CF1 = new System.Windows.Forms.Label();
            this.labKL5_0 = new System.Windows.Forms.Label();
            this.labKL0_5 = new System.Windows.Forms.Label();
            this.labPM2_5 = new System.Windows.Forms.Label();
            this.labPM2_5CF1 = new System.Windows.Forms.Label();
            this.labKL2_5 = new System.Windows.Forms.Label();
            this.labKL0_3 = new System.Windows.Forms.Label();
            this.labPM1_0 = new System.Windows.Forms.Label();
            this.labPM1_0CF1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.折线图 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.折线图.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labKL10);
            this.groupBox1.Controls.Add(this.labKL1_0);
            this.groupBox1.Controls.Add(this.labPM10);
            this.groupBox1.Controls.Add(this.labPM10CF1);
            this.groupBox1.Controls.Add(this.labKL5_0);
            this.groupBox1.Controls.Add(this.labKL0_5);
            this.groupBox1.Controls.Add(this.labPM2_5);
            this.groupBox1.Controls.Add(this.labPM2_5CF1);
            this.groupBox1.Controls.Add(this.labKL2_5);
            this.groupBox1.Controls.Add(this.labKL0_3);
            this.groupBox1.Controls.Add(this.labPM1_0);
            this.groupBox1.Controls.Add(this.labPM1_0CF1);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时状况";
            // 
            // labKL10
            // 
            this.labKL10.AutoSize = true;
            this.labKL10.Location = new System.Drawing.Point(113, 292);
            this.labKL10.Name = "labKL10";
            this.labKL10.Size = new System.Drawing.Size(11, 12);
            this.labKL10.TabIndex = 5;
            this.labKL10.Text = "0";
            // 
            // labKL1_0
            // 
            this.labKL1_0.AutoSize = true;
            this.labKL1_0.Location = new System.Drawing.Point(113, 226);
            this.labKL1_0.Name = "labKL1_0";
            this.labKL1_0.Size = new System.Drawing.Size(11, 12);
            this.labKL1_0.TabIndex = 5;
            this.labKL1_0.Text = "0";
            // 
            // labPM10
            // 
            this.labPM10.AutoSize = true;
            this.labPM10.Location = new System.Drawing.Point(114, 152);
            this.labPM10.Name = "labPM10";
            this.labPM10.Size = new System.Drawing.Size(11, 12);
            this.labPM10.TabIndex = 5;
            this.labPM10.Text = "0";
            // 
            // labPM10CF1
            // 
            this.labPM10CF1.AutoSize = true;
            this.labPM10CF1.Location = new System.Drawing.Point(114, 71);
            this.labPM10CF1.Name = "labPM10CF1";
            this.labPM10CF1.Size = new System.Drawing.Size(11, 12);
            this.labPM10CF1.TabIndex = 5;
            this.labPM10CF1.Text = "0";
            // 
            // labKL5_0
            // 
            this.labKL5_0.AutoSize = true;
            this.labKL5_0.Location = new System.Drawing.Point(113, 269);
            this.labKL5_0.Name = "labKL5_0";
            this.labKL5_0.Size = new System.Drawing.Size(11, 12);
            this.labKL5_0.TabIndex = 4;
            this.labKL5_0.Text = "0";
            // 
            // labKL0_5
            // 
            this.labKL0_5.AutoSize = true;
            this.labKL0_5.Location = new System.Drawing.Point(113, 203);
            this.labKL0_5.Name = "labKL0_5";
            this.labKL0_5.Size = new System.Drawing.Size(11, 12);
            this.labKL0_5.TabIndex = 4;
            this.labKL0_5.Text = "0";
            // 
            // labPM2_5
            // 
            this.labPM2_5.AutoSize = true;
            this.labPM2_5.Location = new System.Drawing.Point(114, 129);
            this.labPM2_5.Name = "labPM2_5";
            this.labPM2_5.Size = new System.Drawing.Size(11, 12);
            this.labPM2_5.TabIndex = 4;
            this.labPM2_5.Text = "0";
            // 
            // labPM2_5CF1
            // 
            this.labPM2_5CF1.AutoSize = true;
            this.labPM2_5CF1.Location = new System.Drawing.Point(114, 48);
            this.labPM2_5CF1.Name = "labPM2_5CF1";
            this.labPM2_5CF1.Size = new System.Drawing.Size(11, 12);
            this.labPM2_5CF1.TabIndex = 4;
            this.labPM2_5CF1.Text = "0";
            // 
            // labKL2_5
            // 
            this.labKL2_5.AutoSize = true;
            this.labKL2_5.Location = new System.Drawing.Point(114, 248);
            this.labKL2_5.Name = "labKL2_5";
            this.labKL2_5.Size = new System.Drawing.Size(11, 12);
            this.labKL2_5.TabIndex = 3;
            this.labKL2_5.Text = "0";
            // 
            // labKL0_3
            // 
            this.labKL0_3.AutoSize = true;
            this.labKL0_3.Location = new System.Drawing.Point(114, 182);
            this.labKL0_3.Name = "labKL0_3";
            this.labKL0_3.Size = new System.Drawing.Size(11, 12);
            this.labKL0_3.TabIndex = 3;
            this.labKL0_3.Text = "0";
            // 
            // labPM1_0
            // 
            this.labPM1_0.AutoSize = true;
            this.labPM1_0.Location = new System.Drawing.Point(115, 108);
            this.labPM1_0.Name = "labPM1_0";
            this.labPM1_0.Size = new System.Drawing.Size(11, 12);
            this.labPM1_0.TabIndex = 3;
            this.labPM1_0.Text = "0";
            // 
            // labPM1_0CF1
            // 
            this.labPM1_0CF1.AutoSize = true;
            this.labPM1_0CF1.Location = new System.Drawing.Point(114, 27);
            this.labPM1_0CF1.Name = "labPM1_0CF1";
            this.labPM1_0CF1.Size = new System.Drawing.Size(11, 12);
            this.labPM1_0CF1.TabIndex = 3;
            this.labPM1_0CF1.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(31, 292);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "10um颗粒物：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 226);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 2;
            this.label17.Text = "1.0um颗粒物：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "PM10（E）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "PM10（CF=1）：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(25, 269);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 12);
            this.label22.TabIndex = 1;
            this.label22.Text = "5.0um颗粒物：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "0.5um颗粒物：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "PM2.5（E）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PM2.5（CF=1）：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(25, 248);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "2.5um颗粒物：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "0.3um颗粒物：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "PM1.0（E）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "PM1.0（CF=1）：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.折线图);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(208, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 510);
            this.tabControl1.TabIndex = 1;
            // 
            // 折线图
            // 
            this.折线图.Controls.Add(this.chart1);
            this.折线图.Location = new System.Drawing.Point(4, 22);
            this.折线图.Name = "折线图";
            this.折线图.Padding = new System.Windows.Forms.Padding(3);
            this.折线图.Size = new System.Drawing.Size(676, 484);
            this.折线图.TabIndex = 0;
            this.折线图.Text = "PM浓度";
            this.折线图.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 0);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.MarkerBorderColor = System.Drawing.Color.Black;
            series13.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series13.Name = "PM1.0（CF=1）";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series14.Name = "PM2.5（CF=1）";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series15.Name = "PM10（CF=1）";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series16.Name = "PM1.0（大气）";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series17.Name = "PM2.5（大气）";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series18.Name = "PM10（大气）";
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Series.Add(series17);
            this.chart1.Series.Add(series18);
            this.chart1.Size = new System.Drawing.Size(692, 478);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(676, 484);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "颗粒物个数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(5, 6);
            this.chart2.Name = "chart2";
            series19.ChartArea = "ChartArea1";
            series19.Legend = "Legend1";
            series19.Name = "0.3um颗粒数";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "0.5um颗粒数";
            series21.ChartArea = "ChartArea1";
            series21.Legend = "Legend1";
            series21.Name = "1.0um颗粒数";
            series22.ChartArea = "ChartArea1";
            series22.Legend = "Legend1";
            series22.Name = "2.5um颗粒数";
            series23.ChartArea = "ChartArea1";
            series23.Legend = "Legend1";
            series23.Name = "5.0um颗粒数";
            series24.ChartArea = "ChartArea1";
            series24.Legend = "Legend1";
            series24.Name = "10um颗粒数";
            this.chart2.Series.Add(series19);
            this.chart2.Series.Add(series20);
            this.chart2.Series.Add(series21);
            this.chart2.Series.Add(series22);
            this.chart2.Series.Add(series23);
            this.chart2.Series.Add(series24);
            this.chart2.Size = new System.Drawing.Size(667, 467);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(676, 484);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "技术简介";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(680, 488);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage4.BackgroundImage")));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(676, 484);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "创新点";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "关于";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(754, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "0000-00-00 00：00：00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(683, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "当前时间：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(95, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(14, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "历史记录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(12, 435);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 99);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "质检标准";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(95, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 73);
            this.button4.TabIndex = 1;
            this.button4.Text = "PM2.5检测网空气质量新标准";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Info;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(14, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 73);
            this.button3.TabIndex = 0;
            this.button3.Text = "世界卫生组织2005年《空气质量准则》";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(904, 546);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "环境质量实时监测系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.折线图.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPM10CF1;
        private System.Windows.Forms.Label labPM2_5CF1;
        private System.Windows.Forms.Label labPM1_0CF1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 折线图;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labKL10;
        private System.Windows.Forms.Label labKL1_0;
        private System.Windows.Forms.Label labPM10;
        private System.Windows.Forms.Label labKL5_0;
        private System.Windows.Forms.Label labKL0_5;
        private System.Windows.Forms.Label labPM2_5;
        private System.Windows.Forms.Label labKL2_5;
        private System.Windows.Forms.Label labKL0_3;
        private System.Windows.Forms.Label labPM1_0;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

