using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRestaurant.Startup))]
namespace MyRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
