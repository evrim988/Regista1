using Regista1.Api.Middlewares;

namespace Regista1.Api.Extensions
{
    static public class Extension
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LogMiddleware>();
        }
    }
}
