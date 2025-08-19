using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ReservationSystems;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ReservationSystemsDomainSharedModule)
)]
public class ReservationSystemsDomainModule : AbpModule
{

}
