namespace DB1ChallangeFiapAPI.Domain
{
    public class Interest
    {

        public int InterestId { get; set; }
        public string InterestName { get; set; }
        public string InterestType { get; set; }

        public Interest()
        {
        }



        public Interest(int interestId, string interestName, string interestType)
        {
            InterestId = interestId;
            InterestName = interestName;
            InterestType = interestType;
        }


    }
}
