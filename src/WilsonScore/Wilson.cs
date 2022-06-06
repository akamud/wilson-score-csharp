using System;
using System.Collections.Generic;
using System.Text;

namespace WilsonScore
{
    public static class Wilson
    {
        /// <summary>
        /// Calculates the Wilson Score based on the total votes and upvotes
        /// </summary>
        /// <param name="up">Number of upvotes</param>
        /// <param name="total">Total number of votes</param>
        /// <param name="confidence">Confidence used in calculation, default 1.644853 (90%)</param>
        public static double Score(double up, double total, double confidence = 1.644853)
        {
            /** Based on http://www.evanmiller.org/how-not-to-sort-by-average-rating.html **/
            if (total <= 0 || total < up)
                return 0;

            double phat = up / total;
            double z2 = confidence * confidence;

            return (phat + z2 / (2 * total) - confidence * Math.Sqrt((phat * (1 - phat) + z2 / (4 * total)) / total)) / (1 + z2 / total);
        }

        /// <summary>
        /// Calculates the Wilson Score based on the total votes and upvotes
        /// </summary>
        /// <param name="up">Number of upvotes</param>
        /// <param name="total">Total number of votes</param>
        /// <param name="confidence">Confidence used in calculation, default 1.644853 (90%)</param>
        public static double Score(int up, int total, double confidence = 1.644853)
        {
            return Score((double) up, (double) total, confidence);
        }
    }
}
