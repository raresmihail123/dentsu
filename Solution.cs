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
        /// Computes whether the budget is exceeded.
        /// </summary>
        /// <returns>true for budget exceeded, false otherwise</returns>
        public bool ExceedsBudget()
        {
            double totalAdFees = this._ads.Sum(ad => ad.Fee);
            double totalThirdPartyFees = this._ads.Where(ad => ad.Enhanced).Sum(ad => ad.Fee);
            double expendedBudgetSoFar = totalAdFees + _agencyFee * totalAdFees + _thirdPartyFee * totalThirdPartyFees + _workingHoursFee;
            return expendedBudgetSoFar > this._totalBudget;
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
        
        /// <summary>
        /// getters and setters for all attributes
        /// </summary>
        public double TotalBudget
        {
            get { return _totalBudget; }
            set { _totalBudget = value; }
        }

        public double AgencyFee
        {
            get { return _agencyFee; }
            set { _agencyFee = value; }
        }

        public double ThirdPartyFee
        {
            get { return _thirdPartyFee; }
            set { _thirdPartyFee = value; }
        }

        public double WorkingHoursFee
        {
            get { return _workingHoursFee; }
            set { _workingHoursFee = value; }
        }

        public int TargetAd
        {
            get { return _targetAd; }
            set { _targetAd = value; }
        }
    }
}