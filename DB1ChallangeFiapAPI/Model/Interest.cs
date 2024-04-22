namespace DB1ChallangeFiapAPI.Model
{
    public class Interest
    {
        public int InterestId { get; set; }
        public int UserId { get; set; }
        public string InterestName { get; set; }
        public string InterestDescription { get; set; }
        public string InterestCategory { get; set; }
        public char InterestTeach { get; set; }
        public char InterestLearn { get; set; }

        public Interest(int userId, string interestName, string interestDescription, string interestCategory, char interestTeach, char interestLearn)
        {
            UserId = userId;
            InterestName = interestName;
            InterestDescription = interestDescription;
            InterestCategory = interestCategory;
            InterestTeach = interestTeach;
            InterestLearn = interestLearn;
        }
    }
}
