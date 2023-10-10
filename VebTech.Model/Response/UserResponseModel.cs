using VebTech.Data.Entities;

namespace VebTech.Model.Response
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
