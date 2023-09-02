using Raju_VillaAPI.Data;
using Raju_VillaAPI.Models;
using Raju_VillaAPI.Models.DTO;

namespace Raju_VillaAPI.Repository.IRepository
{
    public interface IUserRespository
    {
      
        bool IsUniqueUser(string username);
        
        Task<LoginResponseDTO> Login(LoginRequestDT0 loginRequestDTO);
        Task<LocalUser>Register(RegisterationRequestDTO registerationRequestDTO);

    }
}
