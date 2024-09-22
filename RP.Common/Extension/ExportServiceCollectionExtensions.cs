using RP.Common.Handlers;
using RP.Common.Models.Responses;
using RP.Common.Queries;
using RP.Common.Services.Implements.ExportCommon;
using RP.Common.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using static RP.Common.Services.DelegateService;

namespace RP.Common.Extension
{
    public static class ExportServiceCollectionExtensions
    {
        public static void AddExportRequestHandler<TQuery>(this IServiceCollection services)
            where TQuery : class
        {
            services.AddTransient<IRequestHandler<ExportCommonQuery<TQuery>, ExportCommonQueryResponse>, ExportCommonHandler<TQuery>>();
        }

        public static void AddExportCommonService<TQuery>(this IServiceCollection services)
           where TQuery : class
        {
            services.AddScoped<IExportCommonService<TQuery>, ExportCommonService<TQuery>>();
        }

        public static void AddDynamicExportDataMapperResolver<T>(this IServiceCollection services, Dictionary<string, Type> serviceMappings) where T : class
        {
            services.AddScoped<ExportDataMapperResolver<IDataMapperExportService<T>>> (serviceProvider =>
            {
                return key =>
                {
                    if (serviceMappings.TryGetValue(key, out var serviceType))
                    {
                        var dataType = typeof(T);
                        var dataMapperType = typeof(IDataMapperExportService<>).MakeGenericType(dataType);
                        return serviceProvider.GetService(serviceType) as IDataMapperExportService<T>;
                    }

                    throw new KeyNotFoundException();
                };
            });
        }
    }
}
