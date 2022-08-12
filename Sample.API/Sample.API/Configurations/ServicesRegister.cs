using Sample.BusinnesLayer;
using Sample.BusinnesLayer.Contracts;
using Sample.Repository;
using Sample.Repository.Contracts;

namespace Sample.API.Configurations
{
    public static class ServicesRegister
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IMeetingEventBLL, MeetingEventBLL>();
            services.AddSingleton<IMeetingEventRepository, MeetingEventRepository>();
        }
    }
}