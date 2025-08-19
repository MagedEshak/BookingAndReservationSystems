import { Component, inject } from '@angular/core';
import { ReservationSystemsService } from '../services/reservation-systems.service';

@Component({
  selector: 'lib-reservation-systems',
  template: ` <p>reservation-systems works!</p> `,
})
export class ReservationSystemsComponent {
  protected readonly service = inject(ReservationSystemsService);

  constructor() {
    this.service.sample().subscribe(console.log);
  }
}
