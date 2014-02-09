namespace SmartDraft
{
    partial class FrmStats
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStats.Legends.Add(legend1);
            this.chartStats.Location = new System.Drawing.Point(1, 1);
            this.chartStats.Name = "chartStats";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "theirChamp";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.LabelBackColor = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "myChamp";
            this.chartStats.Series.Add(series1);
            this.chartStats.Series.Add(series2);
            this.chartStats.Size = new System.Drawing.Size(362, 307);
            this.chartStats.TabIndex = 0;
            this.chartStats.Text = "which stats do i take?";
            this.chartStats.Click += new System.EventHandler(this.chart1_Click);
            // 
            // FrmStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 308);
            this.Controls.Add(this.chartStats);
            this.Name = "FrmStats";
            this.Text = "Pictures/Graph Stats!";
            this.Load += new System.EventHandler(this.FrmStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats;
    }
}