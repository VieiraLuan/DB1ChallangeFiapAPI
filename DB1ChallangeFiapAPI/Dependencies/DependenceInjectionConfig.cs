using DB1ChallangeFiapAPI.Repository;
using DB1ChallangeFiapAPI.Repository.Interface;
using DB1ChallangeFiapAPI.Service;
using DB1ChallangeFiapAPI.Service.Interface;

namespace DB1ChallangeFiapAPI.Dependencies
{
    public static class DependenceInjectionConfig
    {


        public static void AddResolveDependecies(this IServiceCollection services)
        {


            //Repositories
            #region 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBackgroundRepository, BackgroundRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            #endregion

            //Services
            #region
            services.AddScoped<IAzureServices, AzureServices>();
            #endregion
        }

    }
}
