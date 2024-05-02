using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.Service;
using DB1ChallangeFiapAPI.Service.Interface;
using DB1ChallangeFiapAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IAzureServices _azureServices;
        private readonly string imageContainer = "db1-user-images";


        public UserController(IUserRepository userRepository, IAzureServices azureServices)
        {
            _userRepository = userRepository;
            _azureServices = azureServices;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.Email)
                    || string.IsNullOrEmpty(vm.Password)
                    || (string.IsNullOrEmpty(vm.UserTypeMenteeFlag) & string.IsNullOrEmpty(vm.UserTypeMentorFlag)))
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {
                    User findUser = new User(vm.Email, vm.Password, vm.UserTypeMenteeFlag, vm.UserTypeMentorFlag);


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

        [HttpPost]
        [Route("createAccountFirstStage")]
        public async Task<IActionResult> CreateAccountFirstStage(CreateUserAccountFirstStageViewModel vm)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(vm.Fullname)
                    || string.IsNullOrEmpty(vm.Email)
                    || string.IsNullOrEmpty(vm.BornDate)
                    || string.IsNullOrEmpty(vm.Cellphone)
                    || string.IsNullOrEmpty(vm.Country)
                    || string.IsNullOrEmpty(vm.City)
                    || string.IsNullOrEmpty(vm.State)
                    || string.IsNullOrEmpty(vm.UserTypeMenteeFlag)
                    || string.IsNullOrEmpty(vm.UserTypeMentorFlag)
                    || string.IsNullOrEmpty(vm.UserDescription)
                    )
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {

                    User user = new User(

                        vm.Fullname,
                        vm.Email,
                        vm.BornDate,
                        vm.Cellphone,
                        vm.Country,
                        vm.City,
                        vm.State,
                        vm.UserTypeMenteeFlag,
                        vm.UserTypeMentorFlag,
                        vm.UserDescription

                    );


                    int userId = await _userRepository.CreateUserFirstStepAsync(user);

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

        [HttpPut]
        [Route("setUserDetails")]
        public async Task<IActionResult> SetUserDetails(UserDetailsViewModel vm)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(vm.UserId)
                    || string.IsNullOrEmpty(vm.Password)
                    || string.IsNullOrEmpty(vm.MenteeMax)
                    || string.IsNullOrEmpty(vm.UserImage)
                    )
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {
                    //Manipulation for Azure Service to upload image - Start
                    var imageBytes = Convert.FromBase64String(vm.UserImage);

                    var imageUrl = await _azureServices.UploadFileToAzure(imageBytes, imageContainer);

                    User temp = new User(Convert.ToInt32(vm.UserId), Convert.ToInt32(vm.MenteeMax), vm.Password,imageUrl);

                    var lines = await _userRepository.SetUserDetails(temp);

                    if (lines > 0)
                    {
                        return Ok($"Dados do usuário atualizados com sucesso, {lines} linha(s) alterada(S)");
                    }
                    else
                    {
                        return StatusCode(500, "Erro ao atualizar os dados do usuário.");
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao atualizar o cadastro do usuário: " + ex.Message);
                throw;
            }

        }





    }
}
