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
            Chart chart = new Chart();
            chart.Size = new Size(1200, 600);

            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "{0}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisX.Title = "Number of Elements in Collection";
            chartArea.AxisY.Title = "Average Times to Execute " + fileName + " (milliseconds)";
            chartArea.AxisX.IsLogarithmic = true;
            chartArea.AxisY.IsLogarithmic = true;
            chart.ChartAreas.Add(chartArea);

            // Create the series
            createSeries(ref chart, "List", xvals, listVals);
            createSeries(ref chart, "Array List", xvals, arrayListVals);
            createSeries(ref chart, "Dictionary", xvals, dictionaryVals);
            createSeries(ref chart, "Hashtable", xvals, hashtableVals);

            // draw!
            chart.Invalidate();

            // write out a file
            chart.SaveImage(fileName + ".png", ChartImageFormat.Png);
        }

        static Series createSeries(ref Chart chart, string name, int[] xvals, double[] yvals)
        {

            chart.Legends.Add(new Legend(name));
            chart.Legends[name].Docking = Docking.Bottom;
            var series = new Series();
            series.Name = name;
            series.ChartType = SeriesChartType.FastLine;
            series.XValueType = ChartValueType.Double;
            chart.Series.Add(series);
            chart.Series[name].Points.DataBindXY(xvals, yvals);

            chart.Series[name].Legend = name;
            chart.Series[name].IsVisibleInLegend = true;

            return series;
        }

    }
}
