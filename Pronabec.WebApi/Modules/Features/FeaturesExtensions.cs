using System.Text.Json.Serialization;

namespace Pronabec.WebApi.Modules.Features
{
    public static class FeaturesExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return services;
        }
    }
}