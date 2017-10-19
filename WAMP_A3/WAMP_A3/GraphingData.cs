/*
*	FILE		  : GraphingData.cs
*   PROJECT		  :	WAMP_A3 - Collection Times Analysis
*   PROGRAMMER	  : Wes Martin
*	FIRST VERSION : 13/10/17
*	DESCRIPTION	  : This file contains the GraphingData class, which is used to
*	              : generate the graphs, based off the average times, for the
*	              : various operation used on the different collections.
*/

using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WAMP_A3
{
    class GraphingData
    {
        
        static public void charting(double[,] results, string fileName)
        {
            // These lines of code split up the 2D array of results
            //   into four different one dimensional arrays which can then
            //   be used to plot the data to the graphs
            double[] listVals = new double[Constants.numOfDataPoints];
            System.Buffer.BlockCopy(results, 0, listVals, 0, Constants.numOfDataPoints * sizeof(double));

            double[] arrayListVals = new double[Constants.numOfDataPoints];
            System.Buffer.BlockCopy(results, Constants.numOfDataPoints * sizeof(double), arrayListVals, 0, Constants.numOfDataPoints * sizeof(double));

            double[] dictionaryVals = new double[Constants.numOfDataPoints];
            System.Buffer.BlockCopy(results, Constants.numOfDataPoints * sizeof(double) * 2, dictionaryVals, 0, Constants.numOfDataPoints * sizeof(double));

            double[] hashtableVals = new double[Constants.numOfDataPoints];
            System.Buffer.BlockCopy(results, Constants.numOfDataPoints * sizeof(double) * 3, hashtableVals, 0, Constants.numOfDataPoints * sizeof(double));

            // Pull the differnet X values for the points of data, based off the same values
            //   used to generate the number of elements in the tests
            var xvals = Constants.varyingElementCount;

            // Create the basic chart
            Chart chart = new Chart();
            chart.Size = new Size(1200, 600);

            // Generate the chart area and add it to the chart
            chart.ChartAreas.Add(createChartArea(fileName));

            // Create the different data series' that will represent the data
            createSeries(ref chart, "List", xvals, listVals);
            createSeries(ref chart, "Array List", xvals, arrayListVals);
            createSeries(ref chart, "Dictionary", xvals, dictionaryVals);
            createSeries(ref chart, "Hashtable", xvals, hashtableVals);

            // Force the chart to actually be drawn
            chart.Invalidate();

            // Create the file with the chart
            chart.SaveImage(fileName + ".png", ChartImageFormat.Png);
        }

        /**
        * \brief Creates the basic chart area
        *
        * <b>Description</b><br>
        * Creates the basic chart area. It applies some basic text formatting and creates the 
        * labels for the charts
        * 
        * <b>Details</b>
        *
        * \param					<b>string yAxis</b>	- The name of the yAxis to be created
        * \return		    		<b>ChartArea</b>	- The generated chart area
        */
        static ChartArea createChartArea(string yAxis)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "{0}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisX.Title = "Number of Elements in Collection";
            chartArea.AxisY.Title = "Average Times to Execute " + yAxis + " (milliseconds)";
            chartArea.AxisX.IsLogarithmic = true;
            chartArea.AxisY.IsLogarithmic = true;
            return chartArea;
        }


        /**
        * \brief Creates a series 
        *
        * <b>Description</b><br>
        * Creates a series and adds it to the chart. The series is the linking of the 
        * X and Y values. This function also creates a legend for each series and attaches it
        * to the series and the chart.
        *
        * <b>Details</b>
        *
        * \param					<b>ref Chart chart</b>	- The name of the yAxis to be created
        * \param					<b>string name</b>		- The name of the yAxis to be created
        * \param					<b>int[] xvals</b>		- The name of the yAxis to be created
        * \param					<b>double[] yvals</b>   - The name of the yAxis to be created
        */
        static void createSeries(ref Chart chart, string name, int[] xvals, double[] yvals)
        {
            chart.Legends.Add(new Legend(name));
            chart.Legends[name].Docking = Docking.Bottom;
            var series                  = new Series();
            series.Name                 = name;
            series.ChartType            = SeriesChartType.FastLine;
            series.XValueType           = ChartValueType.Double;
            chart.Series.Add(series);
            chart.Series[name].Points.DataBindXY(xvals, yvals);
            chart.Series[name].Legend = name;
            chart.Series[name].IsVisibleInLegend = true;
        }

    }
}
