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
        public string UserTypeMenteeFlag { get; set; }
        public string UserTypeMentorFlag { get; set; }
        public int MenteeMax { get; set; }
        public int MenteeeNumber { get; set; }


        //Security

        public string Password { get; set; }

        public User()
        {

        }

        //Create Account
        public User(string fullname, string email, string bornDate, string cellphone, string city, string state, string userTypeMentee, string userTypeMentor, string password, string userDesc)
        {

            Fullname = fullname;
            Email = email;
            BornDate = bornDate;
            Cellphone = cellphone;
            City = city;
            State = state;
            UserTypeMenteeFlag = userTypeMentee;
            UserTypeMentorFlag = userTypeMentor;
            Password = password;
            UserDescription = userDesc;
        }

     

        //Login
        public User(string email, string password, string userMenteeFlag, string userMentorFlag)
        {
            Email = email;
            Password = password;
            UserTypeMenteeFlag = userMenteeFlag;
            UserTypeMentorFlag = userMentorFlag;
        }


    }
}
