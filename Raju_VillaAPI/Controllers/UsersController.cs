using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Raju_VillaAPI.Models.DTO;
using Raju_VillaAPI.Repository.IRepository;
using System.Net;
using Raju_VillaAPI.Models;

namespace Raju_VillaAPI.Controllers
{
    

    [Route("api/UsersAuth")]
    [ApiController]
    [ApiVersionNeutral]

    public class UsersController : Controller
        {
            private readonly IUserRespository _userRepo;
        protected APIResponse _response;
        public UsersController(IUserRespository userRepo)
            {
                _userRepo = userRepo;
            _response = new();
        }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequestDT0 model)
            {
                var loginResponse = await _userRepo.Login(model);
                if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Username or password is incorrect");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = loginResponse;
                return Ok(_response);
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
            {
                bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
                if (!ifUserNameUnique)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Username already exists");
                    return BadRequest(_response);
                }

                var user = await _userRepo.Register(model);
                if (user == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Error while registering");
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
        }
    }


