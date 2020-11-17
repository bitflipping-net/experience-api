using Microsoft.AspNetCore.Authentication;

namespace Doctrina.ExperienceApi.Server.Authentication
{
    public class ExperienceApiAuthenticationOptions : AuthenticationSchemeOptions
    {
        public static string DefaultScheme { get; } = "Authority Scheme";

        public ExperienceApiAuthenticationOptions()
        {
        }

    }
}