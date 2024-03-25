import { TestBed } from '@angular/core/testing';

import { AutorizacijaUposlenikService } from './autorizacija-uposlenik.service';

describe('AutorizacijaUposlenikService', () => {
  let service: AutorizacijaUposlenikService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutorizacijaUposlenikService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
