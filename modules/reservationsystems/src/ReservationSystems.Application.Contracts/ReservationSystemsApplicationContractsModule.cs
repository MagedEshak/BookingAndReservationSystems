using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ReservationSystems;

[DependsOn(
    typeof(ReservationSystemsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ReservationSystemsApplicationContractsModule : AbpModule
{

}
