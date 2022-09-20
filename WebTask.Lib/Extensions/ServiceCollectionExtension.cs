using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebTask.Lib.Service;

namespace WebTask.Lib.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void UseTaskServices(this IServiceCollection services, DbContextOptions options)
        {
            services.AddTransient<IMyFileService, MyFileService>(x => new MyFileService(options));
            services.AddTransient<IMyTaskService, MyTaskService>(x => new MyTaskService(options, x.GetRequiredService<IMyFileService>()));
        }
    }
}
