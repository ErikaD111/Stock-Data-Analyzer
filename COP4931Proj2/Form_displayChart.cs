using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace COP4931Proj2
{
    public partial class Form_displayChart : Form
    {
        // Class-level variables
        private List<SmartCandlestick> sourceCandlesticks;
        private BindingList<SmartCandlestick> candlesticks;

        // Constructor for the chart display form
        public Form_displayChart(string sourceFilename, List<SmartCandlestick> sourceCandlesticks, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            // Initialize form controls and class variables
            this.sourceCandlesticks = sourceCandlesticks;
            dateTimePicker_startDate.Value = startDate;
            dateTimePicker_endDate.Value = endDate;
            candlesticks = new BindingList<SmartCandlestick>();

            // Clear existing chart titles and set a new title based on the source filename
            chart_stock.Titles.Clear();
            chart_stock.Titles.Add(Path.GetFileNameWithoutExtension(sourceFilename));

            // Configure the OHLC series in the chart
            chart_stock.Series["series_OHLC"]["ShowOpenClose"] = "Both";
            chart_stock.DataManipulator.IsStartFromFirst = true;

            // Filter and display candlesticks based on date range
            filterCandlesticksByDate();
        }

        // Method to filter candlesticks based on selected date range
        public void filterCandlesticksByDate()
        {
            // Clear existing candlesticks before adding new ones
            candlesticks.Clear();

            // Here we should make sure the candlesticks are in range
            foreach (SmartCandlestick cs in sourceCandlesticks)
            {
                // As soon as we pass the endDate, we are done
                if (cs.date > dateTimePicker_endDate.Value)
                    break;

                //Filter out the bad candlesticks, keep only the ones at or after the start date
                if (cs.date >= dateTimePicker_startDate.Value)
                    candlesticks.Add(cs);
            }
            // Setting chart data for volume and candlesticks to the candlesticks list
            chart_stock.DataSource = candlesticks;
            chart_stock.DataBind();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // Update the displayed candlesticks based on the selected date range
            filterCandlesticksByDate();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Annotate the chart based on the selected pattern
            annotateChart(comboBox_Patterns.Text);
        }

        private void button__Click(object sender, EventArgs e)
        {
            // Clear all annotations from the chart
            chart_stock.Annotations.Clear();
        }
        public void annotateChart(string patternName)
        {
            Recognizer patternRecognizer = null;

            // Check for the specified pattern
            switch (patternName)
                {
                    case "Bearish":
                        patternRecognizer = new BearishRecognizer();
                        break;
                    case "Bullish":
                        patternRecognizer = new BullishRecognizer();
                        break;
                    case "Neutral":
                        patternRecognizer = new NeutralRecognizer();
                        break;
                    case "Marubozu":
                        patternRecognizer = new MarubozuRecognizer();
                        break;
                    case "Doji":
                        patternRecognizer = new DojiRecognizer();
                        break;
                    case "Dragonfly Doji":
                        patternRecognizer = new DragonFlyDojiRecognizer();
                        break;
                    case "Gravestone Doji":
                        patternRecognizer = new GravestoneDojiRecognizer();
                        break;
                    case "Hammer":
                        patternRecognizer = new HammerRecognizer();
                        break;
                    case "Inverted Hammer":
                        patternRecognizer = new InvertedHammerRecognizer();
                        break;
                    case "Bullish Engulfing":
                        patternRecognizer = new BullishEngulfingRecognizer();
                        break;
                    case "Bearish Engulfing":
                        patternRecognizer = new BearishEngulfingRecognizer();
                        break;
                    case "Bullish Harami":
                        patternRecognizer = new BullishHaramiRecognizer();
                        break;
                    case "Bearish Harami":
                        patternRecognizer = new BearishHaramiRecognizer();
                        break;
                    case "Peak":
                        patternRecognizer = new PeakRecognizer();
                        break;
                    case "Valley":
                        patternRecognizer = new ValleyRecognizer();
                        break;
                default:
                        // Handle unknown pattern
                        break;
                }

            if (patternRecognizer == null)
            {
                // Handle the case when the pattern recognizer is not initialized
                return;
            }

            // Convert BindingList to List before passing to Recognize
            List<SmartCandlestick> candlesticksList = candlesticks.ToList();

            // Use the Recognizer to get the list of indexes
            List<int> patternIndexes = patternRecognizer.Recognize(candlesticksList);

            // Iterate through the recognized indexes
            foreach (int index in patternIndexes)
            {
                // Add box annotation to the chart for each recognized pattern
                AddBoxAnnotation(index, patternName);
            }
        }

        // Method to add a box annotation to the chart at a specified index
        public void AddBoxAnnotation(int index, string patternName)
        {
            // Ensure the index is within the valid range
            if (index >= 0 && index < chart_stock.Series[0].Points.Count)
            {
                // Get the data point at the specified index
                DataPoint dataPoint = chart_stock.Series[0].Points[index];

                // Initialize the annotation
                RectangleAnnotation rectangle = new RectangleAnnotation();
                rectangle.AxisX = chart_stock.ChartAreas["area_OHLC"].AxisX;
                rectangle.AxisY = chart_stock.ChartAreas["area_OHLC"].AxisY;
                rectangle.IsSizeAlwaysRelative = false;

                // Set the position of the rectangle based on the data point
                rectangle.Y = dataPoint.YValues[1]; // Use the low value as the Y position
                rectangle.X = dataPoint.XValue - (chart_stock.Series[0].Points[1].XValue - chart_stock.Series[0].Points[0].XValue)/2; // Set the X position to the data point's X value

                // Use the width and height properties to determine the end position of the annotation.
                double high = dataPoint.YValues[0];
                double low = dataPoint.YValues[1];
                rectangle.Height = Math.Abs(high - low);
                rectangle.Width = chart_stock.Series[0].Points[1].XValue - chart_stock.Series[0].Points[0].XValue;
                rectangle.LineColor = Color.Black;
                rectangle.BackColor = Color.Transparent;

                // Add the rectangle annotation to the chart
                chart_stock.Annotations.Add(rectangle);

                // Add a text annotation for the candlestick type
                TextAnnotation textAnnotation = new TextAnnotation();
                textAnnotation.AxisX = chart_stock.ChartAreas["area_OHLC"].AxisX;
                textAnnotation.AxisY = chart_stock.ChartAreas["area_OHLC"].AxisY;
                textAnnotation.AnchorX = rectangle.X + (rectangle.Width / 2); // Center justify the text
                textAnnotation.AnchorY = rectangle.Y + 10;
                textAnnotation.Text = patternName;
                textAnnotation.ForeColor = Color.Black;
                textAnnotation.Font = new Font("Arial", 8);
                textAnnotation.Alignment = ContentAlignment.MiddleCenter;

                chart_stock.Annotations.Add(textAnnotation);
            }
        }

    }
}
