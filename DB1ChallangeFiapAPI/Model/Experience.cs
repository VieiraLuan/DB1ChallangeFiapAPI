using System.Data;

namespace DB1ChallangeFiapAPI.Model
{
    public class Experience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }

        public Experience(int userId, string name, string description, int time)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Time = time;
        }
    }
}

