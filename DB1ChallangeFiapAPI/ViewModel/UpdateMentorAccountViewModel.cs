using DB1ChallangeFiapAPI.Model;
using System.Reflection;

namespace DB1ChallangeFiapAPI.ViewModel
{
    public class UpdateMentorAccountViewModel
    {
        public int Id { get; set; }
        public int InterestId { get; set; }
        public int SkillId { get; set; }
        public int ExperienceId { get; set; }
        public int BackgroundId { get; set; }
        public int MenteeMax { get; set; }

    }
}
