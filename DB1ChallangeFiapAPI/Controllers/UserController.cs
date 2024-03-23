using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("createAccount")]
        public async Task<IActionResult> CreateAccount(User model)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(model.Fullname)
                    || string.IsNullOrEmpty(model.Email)
                    || string.IsNullOrEmpty(model.BornDate)
                    || string.IsNullOrEmpty(model.Cellphone)
                    || string.IsNullOrEmpty(model.City)
                    || string.IsNullOrEmpty(model.State)
                    || string.IsNullOrEmpty(model.UserType)
                    || string.IsNullOrEmpty(model.Password)
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
                        model.City,
                        model.State,
                        model.UserType,
                        model.Password


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

                return BadRequest("Erro ao tentar cadastrar o usuário: " + ex.Message);

            }
        }


    }
}
