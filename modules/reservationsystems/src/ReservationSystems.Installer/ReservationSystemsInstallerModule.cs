using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ReservationSystems;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ReservationSystemsInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ReservationSystemsInstallerModule>();
        });
    }
}
