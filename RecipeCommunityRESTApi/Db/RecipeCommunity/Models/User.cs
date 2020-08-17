namespace RecipeCommunityRESTApi.Db.RecipeCommunity.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
    }
}
