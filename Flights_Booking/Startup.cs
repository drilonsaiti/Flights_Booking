using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flights_Booking.Startup))]
namespace Flights_Booking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
