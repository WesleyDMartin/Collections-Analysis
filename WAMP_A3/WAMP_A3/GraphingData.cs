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
        /**
        * \brief Creates charts based off input data
        *
        * <b>Description</b><br>
        * Creates a chart based off the passed in data. It configures the chart
        * and formats all the data to be displayed properly. It creates a .png
        * file type image that contains the fully formatted image.
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] results</b>    - A 2D array that contains
        *                                                           all the timed data for all
        *                                                           four collection types for 
        *                                                           one of the test types
        *                                                       
        * \param					<b>string fileName</b>		- The name of the chart
        * \param                    <b>bool log</b>             - Indicates whether the graph 
        *                                                           should have a vertical log scale
        */
        static public void charting(double[,] results, string fileName, bool log = false)
        {
            // Update the name to reflect the log scale if necessary
            if(log)
            {
                fileName += " - Log Scale";
            }

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
            Chart chart = new Chart
            {
                Size = new Size(1200, 600)
            };
            chart.Titles.Add("Title1");
            chart.Titles["Title1"].Text = fileName;

            // Generate the chart area and add it to the chart
            chart.ChartAreas.Add(createChartArea(fileName, log));

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
        * \param                    <b>bool log</b>     - Indicates whether the graph should have a vertical log scale
        * \return		    		<b>ChartArea</b>	- The generated chart area
        */
        static ChartArea createChartArea(string yAxis, bool log = false)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "{0}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 12);
            chartArea.AxisX.Title = "Number of Elements in Collection";
            chartArea.AxisY.Title = "Average Times to Execute " + yAxis + " (milliseconds)";
            chartArea.AxisX.IsLogarithmic = true;
            chartArea.AxisY.IsLogarithmic = log;
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
        * \param					<b>ref Chart chart</b>	- The chart that is being edited
        * \param					<b>string name</b>		- The name of the chart
        * \param					<b>int[] xvals</b>		- The value of the X points
        * \param					<b>double[] yvals</b>   - The value of the Y points
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
            chart.Series[name].Legend   = name;
            chart.Series[name].IsVisibleInLegend = true;
        }

    }
}
