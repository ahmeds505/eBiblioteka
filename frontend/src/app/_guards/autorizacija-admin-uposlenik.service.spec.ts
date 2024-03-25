import { TestBed } from '@angular/core/testing';

import { AutorizacijaAdminUposlenikService } from './autorizacija-admin-uposlenik.service';

describe('AutorizacijaAdminUposlenikService', () => {
  let service: AutorizacijaAdminUposlenikService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutorizacijaAdminUposlenikService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
