using DB1ChallangeFiapAPI.Model;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DB1ChallangeFiapAPI.Controllers
{
    [ApiController]
    public class InterestsController : Controller
    {

        private readonly IInterestRepository _interestsRepository;
        public InterestsController(IInterestRepository interestsRepository)
        {
            _interestsRepository = interestsRepository;
        }


        [HttpPost]
        [Route("createInterests")]
        public async Task<IActionResult> CreateUserInterests(List<CreateUserInterestViewModel> interestList)
        {
            try
            {

                int count = 0;

                if (interestList.Count == 0)
                {
                    return BadRequest("Envie ao menos 1 item na lista");
                }
                else
                {
                    foreach (var interest in interestList)
                    {
                        if (
                               string.IsNullOrEmpty(interest.UserId)
                            || string.IsNullOrEmpty(interest.Name)
                            || string.IsNullOrEmpty(interest.Description)
                            || string.IsNullOrEmpty(interest.Category)
                            || string.IsNullOrEmpty(interest.Teach)
                            || string.IsNullOrEmpty(interest.Learn)
                                                                                                                                    )
                        {
                            return BadRequest("Informe todos os dados obrigatórios");
                        }
                        else
                        {
                            Interest tempInterest = new Interest(Convert.ToInt32(interest.UserId), interest.Name, interest.Description, interest.Category, Convert.ToChar(interest.Teach), Convert.ToChar(interest.Learn));

                            if (await _interestsRepository.CreateUserInterestsAsync(tempInterest) > 0)
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
                return BadRequest(ex.Message);
            }
        }
    }
}
