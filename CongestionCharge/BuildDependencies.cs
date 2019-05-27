using Microsoft.Extensions.DependencyInjection;

namespace CongestionCharge
{
    public static class BuildDependencies
    {
        public static ServiceProvider Build()
        {
            var services = new ServiceCollection()
                .AddTransient<ICalculateCharges, CalculateCharges>()
                .BuildServiceProvider();

            return services;
        }
    }
}
