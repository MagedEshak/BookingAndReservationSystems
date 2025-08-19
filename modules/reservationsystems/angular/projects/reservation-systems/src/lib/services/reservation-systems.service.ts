import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ReservationSystemsService {
  apiName = 'ReservationSystems';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/reservation-systems/sample' },
      { apiName: this.apiName }
    );
  }
}
