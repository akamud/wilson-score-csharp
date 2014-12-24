using System;
using System.Collections.Generic;
using System.Text;

namespace WilsonScore
{
    public static class Wilson
    {
        public static double Score(double up, double total, double confidence = 1.644853)
        {
            /** Based on http://www.evanmiller.org/how-not-to-sort-by-average-rating.html **/
            if (total <= 0 || total < up)
                return 0;

            double phat = up / total;
            double z2 = confidence * confidence;

            return (phat + z2 / (2 * total) - confidence * Math.Sqrt((phat * (1 - phat) + z2 / (4 * total)) / total)) / (1 + z2 / total);
        }
    }
}
