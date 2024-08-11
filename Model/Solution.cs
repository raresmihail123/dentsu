using System.Drawing;
using System.Linq;

namespace dentsu
{
    /// <summary>
    /// This is a class that contains all the data and the business logic needed to solve the problem.
    /// </summary>
    public class Solution
    {
        private double _totalBudget; //Z
        private readonly Ad[] _ads; //X
        private double _agencyFee; //Y1
        private double _thirdPartyFee; //Y2
        private double _workingHoursFee; //HOURS
        private int _targetAd; //ad whose budget must be maximized
        private int _numberOfAds;

        /// <summary>
        /// constructor for a solution.
        /// </summary>
        /// <param name="totalBudget"></param>
        /// <param name="ads"></param>
        /// <param name="agencyFee"></param>
        /// <param name="thirdPartyFee"></param>
        /// <param name="workingHoursFee"></param>
        /// <param name="targetAd"></param>
        public Solution(double totalBudget, Ad[] ads, double agencyFee, double thirdPartyFee, double workingHoursFee, int targetAd)
        {
            this._totalBudget = totalBudget;
            this._ads = ads;
            this._agencyFee = agencyFee;
            this._thirdPartyFee = thirdPartyFee;
            this._workingHoursFee = workingHoursFee;
            this._targetAd = targetAd;
            this._numberOfAds = _ads.Length;
        }
        
        //TODO: create getters/setters for all properties
        /// <summary>
        /// Returns the allocated fee for the target ad.
        /// </summary>
        /// <returns> (double) value of target ad fee</returns>
        public double GetTargetAdFee()
        {
            return this._ads[_targetAd].Fee;
        }

        /// <summary>
        /// Computes the total budget that has been spent so far.
        /// </summary>
        /// <returns></returns>
        public double ExpendedBudgetSoFar()
        {
            double totalAdFees = this._ads.Sum(ad => ad.Fee);
            double totalThirdPartyFees = this._ads.Where(ad => ad.Enhanced).Sum(ad => ad.Fee);
            double expendedBudgetSoFar = totalAdFees + _agencyFee * totalAdFees + _thirdPartyFee * totalThirdPartyFees + _workingHoursFee;
            return expendedBudgetSoFar;
        }
        /// <summary>
        /// Computes whether the total budget is exceeded.
        /// </summary>
        /// <returns>true for budget exceeded, false otherwise</returns>
        public bool ExceedsBudget()
        {
            return this.ExpendedBudgetSoFar() > this._totalBudget;
        }

        public bool IsWithinThreshold(double expendedBudgetSoFar, double threshold)
        {
            return this._totalBudget - expendedBudgetSoFar <= threshold;
        }
        
        /// <summary>
        /// Using the idea behind a goal seek algorithm, this method finds the maximum budget that can be allotted to the target ad.
        /// Uses a threshold for when the algorithm should stop, as well as a multiplier that affects the size of the steps taken towards convergence.
        /// </summary>
        public void GoalSeekSolution()
        {
            double threshold = 5.0;
            double multiplier = 0.7;
            double expendedBudgetSoFar = this.ExpendedBudgetSoFar();
            Ad targetAd = this._ads[this._targetAd];
            while (!IsWithinThreshold(expendedBudgetSoFar, threshold) && multiplier > 0.0)
            {
                expendedBudgetSoFar = this.ExpendedBudgetSoFar();
                if (expendedBudgetSoFar < this._totalBudget)
                    targetAd.Fee += (this._totalBudget - expendedBudgetSoFar) * multiplier;
                else
                    targetAd.Fee -= (this._totalBudget - expendedBudgetSoFar) * multiplier;
                multiplier -= 0.02;
            }
            Console.WriteLine("done!");
        }
        /// <summary>
        /// Computes the exact maximum fee that can be allocated to the target ad.
        /// There are 2 distinct formulas, which take into account whether the target ad will be enhanced or not.
        /// This method is used exclusively for testing purposes, and has no bearing on the actual algorithm.
        /// </summary>
        public void AnalyticalSolution()
        {
            double result = 0.0;
            double feeSum = this._ads.Sum(ad => ad.Fee); // sum of the fees of all the ads except the target ad
            double enhancedSum = this._ads.Where(ad => ad.Enhanced).Sum(ad => ad.Fee); //sum of the fees for the enhanced ads
            if (!this._ads[this._targetAd].Enhanced)
            {
                //TODO: throw exception if totalBudget is exceeded
                result = (_totalBudget - feeSum - _agencyFee * feeSum - _thirdPartyFee * enhancedSum - _workingHoursFee) / (1.0 + _agencyFee);
            }
            else
            {
                //TODO: throw exception if totalBudget is exceeded
                result = (_totalBudget - feeSum - _agencyFee * feeSum - _thirdPartyFee * enhancedSum - _workingHoursFee) / (1.0 + _agencyFee + _thirdPartyFee);
            }
            this._ads[_targetAd].Fee = result;
        }

        public void Reset()
        {
            this._ads[this._targetAd].Fee = 0.0;
        }
        
        /// <summary>
        /// getters and setters for all attributes
        /// </summary>
        public double TotalBudget
        {
            get { return _totalBudget; }
            set
            {
                if (value is double && value >= 0.0)
                    _totalBudget = value;
                else
                    throw new ArgumentOutOfRangeException("Total budget must be a rational number greater than 0.");
            }
        }

        public double AgencyFee
        {
            get { return _agencyFee; }
            set
            {
                if (value is double && value >= 0.0 && value <= 1.0)
                    _agencyFee = value;
                else
                    throw new ArgumentOutOfRangeException("Agency fee must be a fraction between 0 and 1.");
            }
        }

        public double ThirdPartyFee
        {
            get { return _thirdPartyFee; }
            set       
            {
                if (value is double && value >= 0.0 && value <= 1.0)
                    _thirdPartyFee = value;
                else
                    throw new ArgumentOutOfRangeException("Third party fee must be a fraction between 0 and 1.");
            }
        }

        public double WorkingHoursFee
        {
            get { return _workingHoursFee; }
            set
            {
                if (value is double && value >= 0.0 && value <= _totalBudget)
                    _workingHoursFee = value;
                else
                    throw new ArgumentOutOfRangeException("Working hours fee must be a rational number greater than 0 and smaller than the total budget.");
            }
        }

        public int TargetAd
        {
            get { return _targetAd; }
            set
            {
                if (value is double && value >= 0 && value <= _numberOfAds)
                    _totalBudget = value;
                else
                    throw new ArgumentOutOfRangeException("The index of the target ad must be an integer between 1 and the number of total advertisements.");
            }
        }

        public int NumberOfAds
        {
            get { return _numberOfAds; }
        }
    }
}