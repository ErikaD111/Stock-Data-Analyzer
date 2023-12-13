using COP4931Proj2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4931Proj2
{
    public class Candlestick
    {
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal close { get; set; }
        public long volume { get; set; }
        public DateTime date { get; set; }

        // Constructor to convert a row of CSV data into a Candlestick object
        public Candlestick(string rowOfData)
        {
            char[] separators = new char[] { ',', ' ', '"', '-' };
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Rebuild the date string so that we can send it to DateTime.Parse
            string dateString = subs[2] + " " + subs[3] + ", " + subs[4];
            // Parse the date
            date = DateTime.Parse(dateString);

            decimal temp;
            bool success = decimal.TryParse(subs[5], out temp);
            open = temp;

            success = decimal.TryParse(subs[6], out temp);
            high = temp;

            success = decimal.TryParse(subs[7], out temp);
            low = temp;

            success = decimal.TryParse(subs[8], out temp);
            close = temp;

            long tempVolume;
            success = long.TryParse(subs[9], out tempVolume);
            volume = tempVolume;


        }

        // Constructor to create a Candlestick object with specified OHLCV values
        public Candlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }
    }
}

