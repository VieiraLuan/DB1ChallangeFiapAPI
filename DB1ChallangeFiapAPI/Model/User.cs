namespace DB1ChallangeFiapAPI.Model
{
    public class User
    {
        //Normal Data
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string BornDate { get; set; }
        public string Cellphone { get; set; }

        public string Country { get; set; }
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

        public User(int id, int menteeMax, string password, string imageUrl)
        {
            Id = id;
            MenteeMax = menteeMax;
            Password = password;
            ImageUrl = imageUrl;
        }


        //Create Account First Stage
        public User(string fullname, string email, string bornDate, string cellphone,string country, string city, string state, string userTypeMentee, string userTypeMentor, string userDesc)
        {

            Fullname = fullname;
            Email = email;
            BornDate = bornDate;
            Cellphone = cellphone;
            Country = country;
            City = city;
            State = state;
            UserTypeMenteeFlag = userTypeMentee;
            UserTypeMentorFlag = userTypeMentor;
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
