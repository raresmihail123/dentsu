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
        [Test]
        public void test_goal_seek_method_1()
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
            sol.GoalSeekSolution();
            Console.WriteLine(sol.GetTargetAdFee());
            sol.Reset();
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }
        [Test]
        public void test_goal_seek_method_2()
        {
            Ad ad0 = new Ad("Y0", 100, false);
            Ad ad1 = new Ad("Y1", 300.0, true);
            Ad ad2 = new Ad("Y2", 800.0, true);

            Ad[] ads = new Ad[] { ad0, ad1, ad2 };

            double totalBudget = 10000.0;
            double agencyFee = 0.15;
            double thirdPartyFee = 0.25;
            double workingHoursFee = 800;
            int targetAd = 2;

            Solution sol = new Solution(totalBudget, ads, agencyFee, thirdPartyFee, workingHoursFee, targetAd);
            sol.GoalSeekSolution();
            Console.WriteLine(sol.GetTargetAdFee());
            sol.Reset();
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }
        [Test]
        public void test_goal_seek_method_3()
        {
            Ad ad0 = new Ad("Z0", 50, false);
            Ad ad1 = new Ad("Z1", 150.0, true);
            Ad ad2 = new Ad("Z2", 400.0, false);
            Ad ad3 = new Ad("Z3", 600, true);
            Ad ad4 = new Ad("Z4", 250.0, false);
            Ad ad5 = new Ad("Z5", 500.0, true);

            Ad[] ads = new Ad[] { ad0, ad1, ad2, ad3, ad4, ad5 };

            double totalBudget = 3000.0;
            double agencyFee = 0.1;
            double thirdPartyFee = 0.2;
            double workingHoursFee = 300;
            int targetAd = 5;

            Solution sol = new Solution(totalBudget, ads, agencyFee, thirdPartyFee, workingHoursFee, targetAd);
            sol.GoalSeekSolution();
            Console.WriteLine(sol.GetTargetAdFee());
            sol.Reset();
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }
        [Test]
        public void test_goal_seek_method_4()
        {
            Ad ad0 = new Ad("A0", 75, false);
            Ad ad1 = new Ad("A1", 250.0, true);
            Ad ad2 = new Ad("A2", 450.0, false);
            Ad ad3 = new Ad("A3", 350.0, true);
            Ad ad4 = new Ad("A4", 550.0, false);

            Ad[] ads = new Ad[] { ad0, ad1, ad2, ad3, ad4 };

            double totalBudget = 7000.0;
            double agencyFee = 0.12;
            double thirdPartyFee = 0.18;
            double workingHoursFee = 400;
            int targetAd = 3;

            Solution sol = new Solution(totalBudget, ads, agencyFee, thirdPartyFee, workingHoursFee, targetAd);
            sol.GoalSeekSolution();
            Console.WriteLine(sol.GetTargetAdFee());
            sol.Reset();
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }
        [Test]
        public void test_goal_seek_method_5()
        {
            Ad ad0 = new Ad("B0", 50, true);

            Ad[] ads = new Ad[] { ad0 };

            double totalBudget = 1000.0;
            double agencyFee = 0.05;
            double thirdPartyFee = 0.1;
            double workingHoursFee = 100;
            int targetAd = 0;

            Solution sol = new Solution(totalBudget, ads, agencyFee, thirdPartyFee, workingHoursFee, targetAd);
            sol.GoalSeekSolution();
            Console.WriteLine(sol.GetTargetAdFee());
            sol.Reset();
            sol.AnalyticalSolution();
            Console.WriteLine(sol.GetTargetAdFee());
        }

    }
}