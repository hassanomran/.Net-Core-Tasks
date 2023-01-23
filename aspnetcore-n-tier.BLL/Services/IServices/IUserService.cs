using aspnetcore_n_tier.DTO.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcore_n_tier.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> LogIn(UserDTO input);
        Task<List<UsertDetailsDTO>> GetAllUser();
         Task<UserDTO> GetUser(int userId);
        Task<UserDTO> AddUser(UserToAddDTO userToAddDTO);
        Task<bool> UpdateUser(UsertDetailsUpdateDTO userToUpdateDTO);
        Task DeleteUser(int userId);
    }
}
