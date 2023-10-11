namespace VebTech.Model.Response
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<RoleResponseModel> Roles { get; set; }
    }
}
