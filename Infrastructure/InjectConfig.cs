using BankManagement.Business.IService;
using BankManagement.Business.Service;
using BankManagement.DataAccess.IRepository;
using BankManagement.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagement.Infrastructure
{
    public static class InjectConfig
    {
        public static void ServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBankService, BankService>();
        }

        //public static string TestConfig(this string test)
        //{
        //    return test.ToUpper();
        //}
    }
}
