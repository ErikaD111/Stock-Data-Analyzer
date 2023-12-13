using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP4931Proj2
{
    // SmartCandlestick class inherits from the Candlestick class
    public class SmartCandlestick : Candlestick
    {
        // Additional properties for higher-level candlestick analysis
        public Decimal range { get; set; }
        public Decimal bodyRange { get; set; }
        public Decimal upperTail { get; set; }
        public Decimal lowerTail { get; set; }
        public Decimal topPrice { get; set; }
        public Decimal bottomPrice { get; set; }

        // Properties indicating various candlestick patterns
        public bool IsBullish { get; private set; }
        public bool IsBearish { get; private set; }
        public bool IsNeutral { get; private set; }
        public bool IsMarubozu { get; private set; }
        public bool IsDoji { get; private set; }
        public bool IsDragonFlyDoji { get; private set; }
        public bool IsGravestoneDoji{ get; private set; }
        public bool IsHammer { get; private set; }
        public bool IsInvertedHammer { get; private set; }

        // Constructor for SmartCandlestick using CSV data
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            ComputeHigherLevelProperties();
            ComputePatterns();
        }

        // Copy constructor to convert Candlestick to SmartCandlestick
        public SmartCandlestick(Candlestick cs) : base(cs.date, cs.open, cs.high, cs.low, cs.close, cs.volume)
        {
            ComputeHigherLevelProperties();
            ComputePatterns();
        }

        // Method to compute higher-level properties based on candlestick data
        public void ComputeHigherLevelProperties()
        {
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            upperTail = high - topPrice;
            lowerTail = bottomPrice - low;
            range = high - low;
            bodyRange = topPrice - bottomPrice;
        }

        // Method to compute various candlestick patterns based on candlestick data
        public void ComputePatterns()
        {
            IsBullish = close > open;
            IsBearish = close < open;
            IsNeutral = !IsBearish && !IsBullish;
            IsMarubozu = bodyRange == range;
            IsDoji = bodyRange <= 0.03m * open;
            IsDragonFlyDoji = bodyRange <= 0.03m * open && bottomPrice < close;
            IsGravestoneDoji = bodyRange <= 0.03m * open && topPrice > close;
            IsHammer = bodyRange <= 0.03m * range && bottomPrice < close;
            IsInvertedHammer = bodyRange <= 0.03m * range && topPrice > close;
        }
        
    }
}
