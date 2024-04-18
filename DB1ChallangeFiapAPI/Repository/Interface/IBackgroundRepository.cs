using DB1ChallangeFiapAPI.Model;

namespace DB1ChallangeFiapAPI.Repository.Interface
{
    public interface IBackgroundRepository
    {

        public Task<int> CreateBackgroundAsync(Background background);
      
    }
}
