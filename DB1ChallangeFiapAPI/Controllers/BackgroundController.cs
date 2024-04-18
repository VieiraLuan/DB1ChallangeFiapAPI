using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    [ApiController]
    public class BackgroundController : ControllerBase
    {
        private readonly IBackgroundRepository _backgroundRepository;


        public BackgroundController(IBackgroundRepository backgroundRepository)
        {
            _backgroundRepository = backgroundRepository;
        }

        [HttpPost]
        [Route("createBackgrounds")]
        public async Task<IActionResult> CreateUserBackground(List<CreateUserBackgroundViewModel> backgroundList)
        {
            try
            {

                int count = 0;

                if (backgroundList.Count == 0)
                {
                    return BadRequest("Informe todos os dados obrigatórios");
                }
                else
                {

                    foreach (var background in backgroundList)
                    {
                        if (
                            string.IsNullOrEmpty(background.UserId)
                            || string.IsNullOrEmpty(background.Name)
                            || string.IsNullOrEmpty(background.Description)
                            || string.IsNullOrEmpty(background.UniversityName)
                        )
                        {
                            return BadRequest("Informe todos os dados obrigatórios");
                        }
                        else
                        {
                            Background tempBackground = new Background(
                                Convert.ToInt32(background.UserId),
                                background.Name,
                                background.Description,
                                background.UniversityName
                            );

                            if (await _backgroundRepository.CreateBackgroundAsync(tempBackground) > 0)
                            {
                                count++;
                            }
                        }
                    }

                    return Ok($"{count} backgrounds criados com sucesso");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao tentar cadastrar background" + ex.Message);
                throw;
            }
        }

    }
}
