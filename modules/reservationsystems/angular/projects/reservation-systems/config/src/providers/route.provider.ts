import { eLayoutType, RoutesService } from '@abp/ng.core';
import {
  EnvironmentProviders,
  inject,
  makeEnvironmentProviders,
  provideAppInitializer,
} from '@angular/core';
import { eReservationSystemsRouteNames } from '../enums/route-names';

export const RESERVATION_SYSTEMS_ROUTE_PROVIDERS = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

export function configureRoutes() {
  const routesService = inject(RoutesService);
  routesService.add([
    {
      path: '/reservation-systems',
      name: eReservationSystemsRouteNames.ReservationSystems,
      iconClass: 'fas fa-book',
      layout: eLayoutType.application,
      order: 3,
    },
  ]);
}

const RESERVATION_SYSTEMS_PROVIDERS: EnvironmentProviders[] = [...RESERVATION_SYSTEMS_ROUTE_PROVIDERS];

export function provideReservationSystems() {
  return makeEnvironmentProviders(RESERVATION_SYSTEMS_PROVIDERS);
}
