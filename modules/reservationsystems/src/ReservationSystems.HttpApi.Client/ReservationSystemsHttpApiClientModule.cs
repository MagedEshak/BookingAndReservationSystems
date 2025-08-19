using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ReservationSystems;

[DependsOn(
    typeof(ReservationSystemsApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ReservationSystemsHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ReservationSystemsApplicationContractsModule).Assembly,
            ReservationSystemsRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ReservationSystemsHttpApiClientModule>();
        });

    }
}
