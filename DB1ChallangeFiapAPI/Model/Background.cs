namespace DB1ChallangeFiapAPI.Model
{
    public class Background
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string UniversityName { get; set; }

        //Insert
        public Background(int userId, string name, string description, string universityName)
        {
            UserId = userId;
            Name = name;
            Description = description;
            UniversityName = universityName;
        }


    }
}
