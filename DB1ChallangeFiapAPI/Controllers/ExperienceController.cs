using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    [ApiController]
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }


        [HttpPost]
        [Route("CreateExperiences")]
        public async Task<IActionResult> CreateUserExperienceAsync(List<CreateUserExperience> experienceList)
        {
            try
            {
                int count = 0;

                if (experienceList.Count == 0)
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {

                    foreach (var experience in experienceList)
                    {
                        if (
                            string.IsNullOrEmpty(experience.UserId)
                            || string.IsNullOrEmpty(experience.Name)
                            || string.IsNullOrEmpty(experience.Description)
                            || string.IsNullOrEmpty(experience.Time)
                        )
                        {
                            return BadRequest("Informe todos os dados obrigatórios");
                        }
                        else
                        {
                            Experience tempExperience = new Experience(
                                Convert.ToInt32(experience.UserId),
                                experience.Name,
                                experience.Description,
                                Convert.ToInt32(experience.Time)
                            );

                            if (await _experienceRepository.CreateExperienceAsync(tempExperience) > 0)
                            {
                                count++;
                            }
                        }
                    }

                    return Ok($"{count} Experiências criadas com sucesso");

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao tentar cadastrar experiências" + ex.Message);
                throw;
            }
        }

    }
}
