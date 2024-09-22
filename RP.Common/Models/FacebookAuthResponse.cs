namespace GoSell.Common.Models
{

    public class FacebookAuthResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Languages { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public Picture Picture { get; set; }
    }

    public class Data
    {
        public string Url { get; set; }
    }

    public class Picture
    {
        public Data Data { get; set; }
    }
}
