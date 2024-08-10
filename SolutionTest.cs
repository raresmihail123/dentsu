using System;
using dentsu;
using NUnit.Framework;

namespace dentsu
{
    [TestFixture]
    [TestOf(typeof(Solution))]
    public class SolutionTest
    {

        [Test]
        public void test_analytical_method_1()
        {
            Ad ad0 = new Ad("X0", 0, false);
            Ad ad1 = new Ad("X1", 200.0, true);
            Ad ad2 = new Ad("X2", 700.0, true);
            Ad ad3 = new Ad("X3", 1000, true);
            Ad ad4 = new Ad("X4", true);

            Ad[] ads = new Ad[] {ad0, ad1, ad2, ad3, ad4};

            double totalBudget = 5000.0;
            double agencyFee = 0.1;
            double thirdPartyFee = 0.2;
            double workingHoursFee = 500;
            int targetAd = 4;

            Solution sol = new Solution(totalBudget, ads, agencyFee, thirdPartyFee, workingHoursFee, targetAd);
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }
    }
}