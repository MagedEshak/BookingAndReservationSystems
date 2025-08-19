import { RouterOutletComponent } from '@abp/ng.core';
import { Routes } from '@angular/router';

export const RESERVATION_SYSTEMS_ROUTES: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RouterOutletComponent,
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./components/reservation-systems.component').then(c => c.ReservationSystemsComponent),
      },
    ],
  },
];
