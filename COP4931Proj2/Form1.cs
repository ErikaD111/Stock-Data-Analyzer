using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4931Proj2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // initializing the starting directory for the openfiledialogue to the stock data folder in the debug folder
            string stockDataFolderPath = Path.Combine(Application.StartupPath, "Stock Data");
            openFileDialog_stockLoader.InitialDirectory = stockDataFolderPath;
        }
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_stockLoader.ShowDialog();
        }
        private void openFileDialog_stockLoader_FileOk(object sender, CancelEventArgs e)
        {
            List<List<SmartCandlestick>> allListsOfCandlesticks = loadStocks(openFileDialog_stockLoader.FileNames);
            openDisplayChartForms(openFileDialog_stockLoader.FileNames, allListsOfCandlesticks);
        }
        private void openDisplayChartForms(string[] filenames, List<List<SmartCandlestick>> listOfListofCandlesticks)
        {
            // Go through all the filenames and their list of candlesticks
            for (int i = 0; i < filenames.Count(); ++i)
            {
                // Construct a new Form_displayChart to display each stock
                Form_displayChart displayForm = new Form_displayChart(filenames[i], listOfListofCandlesticks[i], dateTimePicker_startDate.Value, dateTimePicker_endDate.Value);
                // Showing the new form
                displayForm.Show();
            }
        }
        private List<List<SmartCandlestick>> loadStocks(string[] arrayOfFilenames)
        {
            List<string> listOfFilenames = arrayOfFilenames.ToList<string>();
            return loadStocks(listOfFilenames);
        }

        private List<List<SmartCandlestick>> loadStocks(List<string> listOfFilenames)
        {
            // Instantiate a List of Lists with capacity for numberOfFilenames
            List<List<SmartCandlestick>> ListOfListsOfCandlesticks = new List<List<SmartCandlestick>>(listOfFilenames.Count());
            // Now go load each filename
            // Use a foreach loop to go through each filename in the filenames array
            foreach (String filename in listOfFilenames)
            {
                // Go read the candlesticks stored in the file named filename
                List<SmartCandlestick> listOfCandlesticks = loadStockFromFile(filename);
                // Add the resulting list of candlesticks to the list of candlesticks
                ListOfListsOfCandlesticks.Add(listOfCandlesticks);
            }

            // Return the list of lists of candlesticks
            return ListOfListsOfCandlesticks;
        }
        public List<SmartCandlestick> loadStockFromFile(string filename)
        {
            // Create a list with initial capactity of 1024, which should be enough
            // This list will hold all the candlesticks and will be the result
            List<SmartCandlestick> listOfCandlesticks = new List<SmartCandlestick>(1024);

            String referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

            //Open the current file with a Stream reader
            using (StreamReader sr = new StreamReader(filename))
            {
                //First read the header
                string header = sr.ReadLine();
                // Make sure the header is correct
                if (header == referenceString)
                {
                    //Declare a string variable to hold the lines we read
                    string line;
                    // Readlines from the file until the end of the file is reached
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Instantiate a new candlestick from the line string
                        SmartCandlestick cs = new SmartCandlestick(line);
                        // Add the candlestick to the list
                        listOfCandlesticks.Add(cs);
                    }
                    // Don't forget to reverse the list
                    listOfCandlesticks.Reverse();
                }
            }
            return listOfCandlesticks;
        }
        
    }
}
