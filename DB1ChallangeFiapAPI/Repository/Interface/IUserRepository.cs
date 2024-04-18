using DB1ChallangeFiapAPI.Model;

namespace DB1ChallangeFiapAPI.Repository.Interface
{
    public interface IUserRepository
    {

        public Task<int> CreateUserFirstStepAsync(User user);
        public Task<int> AuthUserAsync(User user);
    }
}
