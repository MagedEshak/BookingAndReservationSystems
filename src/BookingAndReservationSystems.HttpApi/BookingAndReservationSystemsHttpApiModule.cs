﻿using Localization.Resources.AbpUi;
using BookingAndReservationSystems.Localization;
using Volo.Abp.Account;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.Localization;
using Volo.Abp.TenantManagement;
using ReservationSystems.Permissions;
using ReservationSystems;

namespace BookingAndReservationSystems;

 [DependsOn(
    typeof(BookingAndReservationSystemsApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(ReservationSystemsHttpApiModule)
    )]
public class BookingAndReservationSystemsHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BookingAndReservationSystemsResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
