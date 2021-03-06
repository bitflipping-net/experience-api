﻿using Doctrina.ExperienceApi.Server.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Doctrina.ExperienceApi.Server
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds LRS Server capabilities.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLearningRecordStore(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ExperienceApiAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ExperienceApiAuthenticationOptions.DefaultScheme;
            })
            .AddExperienceApiAuthentication(options => { });

            // services.AddAuthorization();

            return services;
        }
    }
}
