using User.Models.DTO;

namespace User.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
