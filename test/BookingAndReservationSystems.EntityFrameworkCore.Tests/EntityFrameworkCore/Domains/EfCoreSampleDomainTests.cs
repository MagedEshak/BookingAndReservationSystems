using BookingAndReservationSystems.Samples;
using Xunit;

namespace BookingAndReservationSystems.EntityFrameworkCore.Domains;

[Collection(BookingAndReservationSystemsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BookingAndReservationSystemsEntityFrameworkCoreTestModule>
{

}
