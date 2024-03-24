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
                        return Created("Usuário criado com sucesso.", userId);
                    }
                    else
                    {
                        return StatusCode(500, "Erro ao criar usuário.");
                    }

                }

            }
            catch (Exception ex)
            {

                return StatusCode(500,"Erro ao tentar cadastrar o usuário: " + ex.Message);

            }
        }

        [HttpPut]
        [Route("updateMenteeAccount")]
        public async Task<IActionResult> UpdateMenteeAccount(User model)
        {
            try
            {
                if (model.Id != null && model.InterestId != null)
                {
                    User user = new User(model.Id, model.InterestId);

                    if (await _userRepository.UpdateMenteeAsync(user) > 0)
                    {
                        return Ok("Usuário atualizado com sucesso.");

                    }
                    else
                    {
                        return StatusCode(500, "Erro ao atualizar os dados do usuário." +
                            " O usuário não foi encontrado ou o interesse informado não existe.");
                    }


                }
                else
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao tentar atualizar os dados do usuário: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("updateMentorAccount")]
        public async Task<IActionResult> UpdateMentorAccount(User model)
        {
            try
            {
                if (model.Id != null && model.InterestId != null && model.SkillId != null && model.ExperienceId != null && model.BackgroundId != null && model.MenteeMax != null)
                {
                    User user = new User(model.Id, model.InterestId, model.SkillId, model.ExperienceId, model.BackgroundId, model.MenteeMax);

                    if (await _userRepository.UpdateMentorAsync(user) > 0)
                    {
                        return Ok("Usuário atualizado com sucesso.");

                    }
                    else
                    {
                        return StatusCode(500, "Erro ao atualizar os dados do usuário." +
                                                       " O usuário não foi encontrado ou os dados informados não são válidos.");
                    }
                }
                else
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao tentar atualizar os dados do usuário: " + ex.Message);
            }
        }
    }
}
