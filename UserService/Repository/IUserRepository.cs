using UserService.DTO;
using UserService.DTO.Request;
using UserService.Models;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<ResDTO<IEnumerable<User>>> GetUsers(int page = 1, int limit = 10, string? keyword = null);
        Task<ResDTO<User>> GetUser(string id);
        Task<ResDTO<string>> AddUser(CreateUserDTO userDto);
        Task<ResDTO<string>> UpdateUser(UserDTO userDto);
        Task<ResDTO<string>> DeleteUser(string id);
        Task<ResDTO<object>> Login(string email, string password);
        Task<ResDTO<object>> LoginByPinCode(string pinCode);
    }
}
