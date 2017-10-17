using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Diagnostics;

namespace WAMP_A3
{
    class GraphingData
    {
        static public void charting(double[,] results, string fileName)
        {
            // set up some data
            double[] listVals = new double[Constants.numOfXPoints];
            System.Buffer.BlockCopy(results, 0, listVals, 0, Constants.numOfXPoints * sizeof(double));

            double[] arrayListVals = new double[Constants.numOfXPoints];
            System.Buffer.BlockCopy(results, Constants.numOfXPoints * sizeof(double), arrayListVals, 0, Constants.numOfXPoints * sizeof(double));

            double[] dictionaryVals = new double[Constants.numOfXPoints];
            System.Buffer.BlockCopy(results, Constants.numOfXPoints * sizeof(double) * 2, dictionaryVals, 0, Constants.numOfXPoints * sizeof(double));

            double[] hashtableVals = new double[Constants.numOfXPoints];
            System.Buffer.BlockCopy(results, Constants.numOfXPoints * sizeof(double) * 3, hashtableVals, 0, Constants.numOfXPoints * sizeof(double));


            var xvals = Constants.varyingElementCount;

            // create the chart
            var chart = new Chart();
            chart.Size = new Size(1200, 600);

            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "{0}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisX.IsLogarithmic = true;
            chartArea.AxisY.IsLogarithmic = true;
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            series.XValueType = ChartValueType.Double;
            chart.Series.Add(series);

            var series2 = new Series();
            series2.Name = "Series2";
            series2.ChartType = SeriesChartType.FastLine;
            series2.XValueType = ChartValueType.Double;
            chart.Series.Add(series2);

            var series3 = new Series();
            series3.Name = "Series3";
            series3.ChartType = SeriesChartType.FastLine;
            series3.XValueType = ChartValueType.Double;
            chart.Series.Add(series3);

            var series4 = new Series();
            series4.Name = "Series4";
            series4.ChartType = SeriesChartType.FastLine;
            series4.XValueType = ChartValueType.Double;
            chart.Series.Add(series4);


            // bind the datapoints
            chart.Series["Series1"].Points.DataBindXY(xvals, listVals);
            chart.Series["Series2"].Points.DataBindXY(xvals, arrayListVals);
            chart.Series["Series3"].Points.DataBindXY(xvals, dictionaryVals);
            chart.Series["Series4"].Points.DataBindXY(xvals, hashtableVals);


            // draw!
            chart.Invalidate();

            // write out a file
            chart.SaveImage(fileName, ChartImageFormat.Png);
        }
    }
}
