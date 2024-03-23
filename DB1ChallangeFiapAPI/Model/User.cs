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

        //Business Data
        public string UserType { get; set; }
        public string MenteeMax { get; set; }
        public string MenteeeNumber { get; set; }


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


        public User(string fullname, string email, string bornDate, string cellphone, string city, string state, string userType, string password)
        {

            Fullname = fullname;
            Email = email;
            BornDate = bornDate;
            Cellphone = cellphone;
            City = city;
            State = state;
            UserType = userType;
            Password = password;
        }


    }
}
