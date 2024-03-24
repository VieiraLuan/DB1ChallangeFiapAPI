namespace DB1ChallangeFiapAPI.Model
{
    public class User
    {
        //Normal Data
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string BornDate { get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string UserDescription { get; set; }

        //Business Data
        public string UserType { get; set; }
        public int MenteeMax { get; set; }
        public int MenteeeNumber { get; set; }


        //Fk
        public int InterestId { get; set; }
        public int SkillId { get; set; }
        public int ExperienceId { get; set; }
        public int BackgroundId { get; set; }


        //Security

        public string Password { get; set; }

        public User()
        {
        }


        public User(string fullname, string email, string bornDate, string cellphone, string city, string state, string userType, string password, string userDesc)
        {

            Fullname = fullname;
            Email = email;
            BornDate = bornDate;
            Cellphone = cellphone;
            City = city;
            State = state;
            UserType = userType;
            Password = password;
            UserDescription = userDesc;
        }

        // Mentee
        public User(int userid, int interestid)
        {
            Id = userid;
            InterestId = interestid;

        }

        //Mentor
        public User(int userid, int interestid, int skillid, int experienceid, int backgroundid, int menteeMaxNumber)
        {
            Id = userid;
            InterestId = interestid;
            SkillId = skillid;
            ExperienceId = experienceid;
            BackgroundId = backgroundid;
            MenteeeNumber = 0;
            MenteeMax = menteeMaxNumber;
        }


    }
}
