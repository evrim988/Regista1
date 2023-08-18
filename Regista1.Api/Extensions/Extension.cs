using Regista.Api.Middlewares;

namespace Regista.Api.Extensions
{
    static public class Extension
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LogMiddleware>();
        }
    }
}
