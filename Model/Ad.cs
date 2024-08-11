namespace dentsu
{
    /// <summary>
    /// This is a class used to represent an advertisement in the Solution class.
    /// </summary>
    public class Ad
    {
        private string _name; //name of the ad
        private double _fee; // individual ad spend(allocated budget)
        private bool _enhanced; // whether the ad is enhanced using third party tools or not

        /// <summary>
        /// constructor for advertisement for which we know all information
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fee"></param>
        /// <param name="enhanced"></param>
        public Ad(string name, double fee, bool enhanced)
        {
            this._name = name;
            this._fee = fee;
            this._enhanced = enhanced;
        }
        /// <summary>
        /// constructor for target advertisement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="enhanced"></param>
        public Ad(string name, bool enhanced)
        {
            this._name = name;
            this._fee = 0.0;
            this._enhanced = enhanced;
        }
        /// <summary>
        /// getters and setters for all attributes
        /// </summary>
        public double Fee
        {
            get { return _fee; }
            set
            {
                if (value is double && value >= 0.0)
                    _fee = value;
                else
                    throw new ArgumentOutOfRangeException("Fee must be a rational number greater than 0.");
            }
        }

        public bool Enhanced
        {
            get { return _enhanced; }
            set { _enhanced = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}