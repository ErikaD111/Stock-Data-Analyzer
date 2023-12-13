using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4931Proj2
{
    // Abstract base class for candlestick pattern recognizers
    abstract class Recognizer
    {
        // Method to recognize patterns in a list of candlesticks
        public List<int> Recognize(List<SmartCandlestick> Lscs)
        {
            // List to store the indexes of recognized patterns
            List<int> result = new List<int>(Lscs.Count);

            // Iterate through the candlesticks
            for (int i = 0; i < Lscs.Count; i++)
            {
                // If the pattern is recognized, add the index to the result list
                if (RecognizePattern(Lscs, i))
                {
                    result.Add(i);
                }
            }

            // Return the list of recognized pattern indexes
            return result;
        }

        // Abstract method to be implemented by derived classes to recognize specific patterns
        public abstract bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex);
    }

    // Bullish pattern recognizer
    class BullishRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Bullish pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsBullish;
        }
    }

    // Bearish pattern recognizer
    class BearishRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Bearish pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsBearish;
        }
    }

    // Neutral pattern recognizer
    class NeutralRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Neutral pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsNeutral;
        }
    }

    // Marubozu pattern recognizer
    class MarubozuRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Marubozu pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsMarubozu;
        }
    }

    // Doji pattern recognizer
    class DojiRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Doji pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsDoji;
        }
    }

    // Dragonfly Doji pattern recognizer
    class DragonFlyDojiRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Dragonfly Doji pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsDragonFlyDoji;
        }
    }

    // Gravestone Doji pattern recognizer
    class GravestoneDojiRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Gravestone Doji pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsGravestoneDoji;
        }
    }

    // Hammer pattern recognizer
    class HammerRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Hammer pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            return scs.IsHammer;
        }
    }

    // Inverted Hammer pattern recognizer
    class InvertedHammerRecognizer : Recognizer
    {
        // Implementation of RecognizePattern for Inverted Hammer pattern
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            SmartCandlestick scs = Lscs[currentIndex];

            // Check for the inverted hammer pattern
            return scs.IsInvertedHammer;
        }
    }

    class BullishEngulfingRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 1 || currentIndex >= Lscs.Count)
            {
                // Engulfing pattern requires at least two candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex];
            SmartCandlestick C1 = Lscs[currentIndex - 1];

            // Check for the engulfing pattern
            if (C0.high < C1.topPrice && C0.low > C1.bottomPrice && C1.IsBullish)
            {
                return true;
            }

            return false;
        }
    }

    class BearishEngulfingRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 1 || currentIndex >= Lscs.Count)
            {
                // Engulfing pattern requires at least two candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex];
            SmartCandlestick C1 = Lscs[currentIndex - 1];

            // Check for the engulfing pattern
            if (C0.high < C1.topPrice && C0.low > C1.bottomPrice && C1.IsBearish)
            {
                return true;
            }

            return false;
        }
    }
    class BullishHaramiRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 1 || currentIndex >= Lscs.Count)
            {
                // Harami pattern requires at least two candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex];
            SmartCandlestick C1 = Lscs[currentIndex - 1];

            // Check for bullish Harami pattern
            if (C1.IsBearish && C0.IsBullish &&
                C0.high < C1.open && C0.low > C1.close)
            {
                return true;
            }

            return false;
        }
    }

    class BearishHaramiRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 1 || currentIndex >= Lscs.Count)
            {
                // Harami pattern requires at least two candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex];
            SmartCandlestick C1 = Lscs[currentIndex - 1];

            // Check for bearish Harami pattern
            if (C1.IsBullish && C0.IsBearish &&
                C0.high < C1.close && C0.low > C1.open)
            {
                return true;
            }

            return false;
        }
    }
    class PeakRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 2 || currentIndex >= Lscs.Count - 2)
            {
                // Peak pattern requires at least five candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex - 2];
            SmartCandlestick C1 = Lscs[currentIndex - 1];
            SmartCandlestick C2 = Lscs[currentIndex];
            SmartCandlestick C3 = Lscs[currentIndex + 1];
            SmartCandlestick C4 = Lscs[currentIndex + 2];

            // Check for Peak pattern
            if (C2.high > C0.high && C2.high > C1.high && C2.high > C3.high && C2.high > C4.high)
            {
                return true;
            }

            return false;
        }
    }

    class ValleyRecognizer : Recognizer
    {
        public override bool RecognizePattern(List<SmartCandlestick> Lscs, int currentIndex)
        {
            if (currentIndex < 2 || currentIndex >= Lscs.Count - 2)
            {
                // Valley pattern requires at least five candlesticks, so we can't check for it here
                return false;
            }

            SmartCandlestick C0 = Lscs[currentIndex - 2];
            SmartCandlestick C1 = Lscs[currentIndex - 1];
            SmartCandlestick C2 = Lscs[currentIndex];
            SmartCandlestick C3 = Lscs[currentIndex + 1];
            SmartCandlestick C4 = Lscs[currentIndex + 2];

            // Check for Valley pattern
            if (C2.low < C0.low && C2.low < C1.low && C2.low < C3.low && C2.low < C4.low)
            {
                return true;
            }

            return false;
        }
    }

}
