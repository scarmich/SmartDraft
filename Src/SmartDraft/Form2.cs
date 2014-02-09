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

namespace SmartDraft
{
    public partial class FrmStats : Form
    {
        public FrmStats()
        {
            InitializeComponent();
        }

        private void FrmStats_Load(object sender, EventArgs e)
        {
            ////Data arrays
            ////string[] seriesArray = {theirChamp, myChamp}
            ////int pointsArray ={}
            ////Set palette
            //this.chartStats.Palette = ChartColorPalette.EarthTones;

            ////Set Title
            //this.chartStats.Titles.Add("Stat filler title");

            ////Add series
            //for (int i = 0; i < seriesArray.Length; i++)
            //{
            //    //Add series
            //    Series series = this.chartStats.Series.Add(seriesArray[i]);
            //    //Add point
            //    series.Points.Add(pointsArray[i]);
            //}
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
