namespace DB1ChallangeFiapAPI.Model
{
    public class User
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime BornDate { get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string UserType { get; set; }
        public int InterestId { get; set; }
        public string Password { get; set; }

        public User()
        {
        }


        public User(int id, string fullname, string email, DateTime bornDate, string cellphone, string city, string state, string userType, int interestId, string password)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            BornDate = bornDate;
            Cellphone = cellphone;
            City = city;
            State = state;
            UserType = userType;
            InterestId = interestId;
            Password = password;
        }


    }
}
