namespace Discord_Mass_Messenger.Objects
{
    public class User
    {
        public string username { get; set; }
        public string discriminator { get; set; }
        public string id { get; set; }
        public string avatar { get; set; }
    }

    public class Friend
    {
        public int type { get; set; }
        public string id { get; set; }
        public User user { get; set; }
    }
}