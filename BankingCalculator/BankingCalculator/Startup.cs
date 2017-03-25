using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankingCalculator.Startup))]
namespace BankingCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
