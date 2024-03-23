namespace DB1ChallangeFiapAPI.Model
{
    public class Match
    {

        public int Id { get; set; }
        public int UserStartMatchId { get; set; }
        public int UserReceivedMatchId { get; set; }
        public string MatchStatus { get; set; }

        public Match()
        {
        }

        public Match(int id, int userStartMatchId, int userReceivedMatchId, string matchStatus)
        {
            Id = id;
            UserStartMatchId = userStartMatchId;
            UserReceivedMatchId = userReceivedMatchId;
            MatchStatus = matchStatus;
        }
    }
}
