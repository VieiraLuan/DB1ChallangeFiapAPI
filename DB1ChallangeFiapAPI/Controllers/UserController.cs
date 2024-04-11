using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("createAccount")]
        public async Task<IActionResult> CreateAccount(CreateUserAccountViewModel model)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(model.Fullname)
                    || string.IsNullOrEmpty(model.Email)
                    || string.IsNullOrEmpty(model.BornDate)
                    || string.IsNullOrEmpty(model.Cellphone)
                    || string.IsNullOrEmpty(model.Country)
                    || string.IsNullOrEmpty(model.City)
                    || string.IsNullOrEmpty(model.State)
                    || string.IsNullOrEmpty(model.UserTypeMenteeFlag)
                    || string.IsNullOrEmpty(model.UserTypeMentorFlag)
                    || string.IsNullOrEmpty(model.Password)
                    || string.IsNullOrEmpty(model.UserDescription)
                    )
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {

                    User user = new User(

                        model.Fullname,
                        model.Email,
                        model.BornDate,
                        model.Cellphone,
                        model.Country,
                        model.City,
                        model.State,
                        model.UserTypeMenteeFlag,
                        model.UserTypeMentorFlag,
                        model.Password,
                        model.UserDescription

                    );


                    int userId = await _userRepository.CreateUserAsync(user);

                    if (userId > 0)
                    {
                        return Ok($"Usuário criado com sucesso.{userId}");
                    }
                    else
                    {
                        return StatusCode(500, "Erro ao criar usuário.");
                    }

                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Erro ao tentar cadastrar o usuário: " + ex.Message);

            }
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) 
                    || string.IsNullOrEmpty(model.Password)
                    || (string.IsNullOrEmpty(model.UserTypeMenteeFlag) & string.IsNullOrEmpty(model.UserTypeMentorFlag)))
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {
                    User findUser = new User(model.Email, model.Password, model.UserTypeMenteeFlag, model.UserTypeMentorFlag);


                    if (await _userRepository.AuthUserAsync(findUser) > 0)
                    {
                        return Ok("Usuário autenticado com sucesso");
                    }
                    else
                    {
                        return NotFound("Usuário não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao tentar logar: " + ex.Message);
            }
        }
    }
}
