


using DB1ChallangeFiapAPI.Model;

namespace DB1ChallangeFiapAPI.Repository.Interface
{
    public interface IInterestRepository
    {
        public Task<int> CreateUserInterestsAsync(Interest interest);
      
    }
}
