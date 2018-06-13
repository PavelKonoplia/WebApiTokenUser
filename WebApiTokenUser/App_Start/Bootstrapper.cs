using AutoFacWithWebAPI.App_Start;
using System.Web.Http;

namespace WebApiTokenUser.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}