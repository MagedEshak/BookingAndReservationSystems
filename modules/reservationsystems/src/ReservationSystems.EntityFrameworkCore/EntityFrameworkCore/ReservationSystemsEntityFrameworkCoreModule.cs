using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ReservationSystems.EntityFrameworkCore;

[DependsOn(
    typeof(ReservationSystemsDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ReservationSystemsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ReservationSystemsDbContext>(options =>
        {
            options.AddDefaultRepositories<IReservationSystemsDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
