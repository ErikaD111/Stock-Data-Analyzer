namespace COP4931Proj2
{
    partial class Form_displayChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_stock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_Patterns = new System.Windows.Forms.ComboBox();
            this.label_CandlestickPatterns = new System.Windows.Forms.Label();
            this.button_ = new System.Windows.Forms.Button();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.button_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stock)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stock
            // 
            chartArea3.AlignWithChartArea = "area_Volume";
            chartArea3.Name = "area_OHLC";
            chartArea4.Name = "area_Volume";
            this.chart_stock.ChartAreas.Add(chartArea3);
            this.chart_stock.ChartAreas.Add(chartArea4);
            legend2.Name = "Legend1";
            this.chart_stock.Legends.Add(legend2);
            this.chart_stock.Location = new System.Drawing.Point(12, 12);
            this.chart_stock.Name = "chart_stock";
            series3.ChartArea = "area_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series3.Legend = "Legend1";
            series3.Name = "series_OHLC";
            series3.XValueMember = "Date";
            series3.YValueMembers = "High,Low,Open,Close";
            series3.YValuesPerPoint = 4;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "area_Volume";
            series4.Legend = "Legend1";
            series4.Name = "series_Volume";
            series4.XValueMember = "Date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueMembers = "Volume";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart_stock.Series.Add(series3);
            this.chart_stock.Series.Add(series4);
            this.chart_stock.Size = new System.Drawing.Size(814, 615);
            this.chart_stock.TabIndex = 0;
            this.chart_stock.Text = "chart_stocks";
            // 
            // comboBox_Patterns
            // 
            this.comboBox_Patterns.FormattingEnabled = true;
            this.comboBox_Patterns.Items.AddRange(new object[] {
            "Bearish",
            "Bullish",
            "Neutral",
            "Marubozu",
            "Doji",
            "Dragonfly Doji",
            "Gravestone Doji",
            "Hammer",
            "Inverted Hammer",
            "Bullish Engulfing",
            "Bearish Engulfing",
            "Bullish Harami",
            "Bearish Harami",
            "Peak",
            "Valley"});
            this.comboBox_Patterns.Location = new System.Drawing.Point(835, 327);
            this.comboBox_Patterns.MaxDropDownItems = 9;
            this.comboBox_Patterns.Name = "comboBox_Patterns";
            this.comboBox_Patterns.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Patterns.TabIndex = 1;
            this.comboBox_Patterns.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_CandlestickPatterns
            // 
            this.label_CandlestickPatterns.AutoSize = true;
            this.label_CandlestickPatterns.Location = new System.Drawing.Point(832, 311);
            this.label_CandlestickPatterns.Name = "label_CandlestickPatterns";
            this.label_CandlestickPatterns.Size = new System.Drawing.Size(106, 13);
            this.label_CandlestickPatterns.TabIndex = 2;
            this.label_CandlestickPatterns.Text = "Candlestick patterns:";
            // 
            // button_
            // 
            this.button_.Location = new System.Drawing.Point(835, 452);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(81, 39);
            this.button_.TabIndex = 3;
            this.button_.Text = "Clear Annotations";
            this.button_.UseVisualStyleBackColor = true;
            this.button_.Click += new System.EventHandler(this.button__Click);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(832, 60);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(58, 13);
            this.label_startDate.TabIndex = 4;
            this.label_startDate.Text = "Start Date:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(832, 140);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(55, 13);
            this.label_endDate.TabIndex = 5;
            this.label_endDate.Text = "End Date:";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(832, 76);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startDate.TabIndex = 6;
            this.dateTimePicker_startDate.Value = new System.DateTime(2021, 3, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(832, 156);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 7;
            this.dateTimePicker_endDate.Value = new System.DateTime(2023, 11, 10, 0, 0, 0, 0);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(835, 241);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 8;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // Form_displayChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 639);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.button_);
            this.Controls.Add(this.label_CandlestickPatterns);
            this.Controls.Add(this.comboBox_Patterns);
            this.Controls.Add(this.chart_stock);
            this.Name = "Form_displayChart";
            this.Text = "Form_displayChart";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stock;
        private System.Windows.Forms.ComboBox comboBox_Patterns;
        private System.Windows.Forms.Label label_CandlestickPatterns;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Button button_update;
    }
}