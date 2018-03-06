using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InformationEncodingAssignment.Startup))]
namespace InformationEncodingAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
