namespace VebTech.Model.Request
{
    public class SignUpRequestModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Guid> RoleIds { get; set; }
    }
}
