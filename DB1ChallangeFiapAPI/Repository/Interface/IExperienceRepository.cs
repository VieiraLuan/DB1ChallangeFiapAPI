using DB1ChallangeFiapAPI.Model;

namespace DB1ChallangeFiapAPI.Repository.Interface
{
    public interface IExperienceRepository
    {
        public Task<int> CreateExperienceAsync(Experience background);

    }
}