namespace dentsu
{
    /// <summary>
    /// This is a class used to represent an advertisement in the Solution class.
    /// </summary>
    public class Ad
    {
        private string name; //name of the ad
        private double fee; // individual ad spend(allocated budget)
        private bool enhanced; // whether the ad is enhanced using third party tools or not

        /// <summary>
        /// constructor for advertisement for which we know all information
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fee"></param>
        /// <param name="enhanced"></param>
        public Ad(string name, double fee, bool enhanced)
        {
            this.name = name;
            this.fee = fee;
            this.enhanced = enhanced;
        }
        /// <summary>
        /// constructor for target advertisement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="enhanced"></param>
        public Ad(string name, bool enhanced)
        {
            this.name = name;
            this.fee = 0.0;
            this.enhanced = enhanced;
        }
        /// <summary>
        /// getters and setters for all attributes
        /// </summary>
        public double Fee
        {
            get { return fee; }
            set { fee = value; }
        }

        public bool Enhanced
        {
            get { return enhanced; }
            set { enhanced = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}