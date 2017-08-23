using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySQLConnectionDemo.Startup))]
namespace MySQLConnectionDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
