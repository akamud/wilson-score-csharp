using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WilsonScore.Tests
{
    public class ScoreTests
    {
        [Fact]
        void WilsonScore_Should_Be_Zero_If_There_Are_No_Ups()
        {
            Assert.True(Wilson.Score(0, 2) == 0);
        }

        [Fact]
        void WilsonScore_Should_Be_Lower_Than_Average_Score()
        {
            double expected = ((double)1 / (double)2);
            Assert.True(Wilson.Score(1, 2) < expected);
        }

        [Fact]
        void Int_Overload_Should_Be_The_Same_As_Double_Overload()
        {
            double expectedDouble = ((double)8 / (double)32);
            int expectedInt = (8 / 32);
            Assert.True(expectedInt < expectedDouble);
        }

        [Fact]
        void WilsonScore_Should_Be_Higher_For_Same_Average_But_Higher_Totals()
        {
            Assert.True(Wilson.Score(500, 1000) > Wilson.Score(1, 2));
        }
    }
}
