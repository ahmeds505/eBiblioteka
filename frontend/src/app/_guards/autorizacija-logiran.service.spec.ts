import { TestBed } from '@angular/core/testing';

import { AutorizacijaLogiranService } from './autorizacija-logiran.service';

describe('AutorizacijaLogiranService', () => {
  let service: AutorizacijaLogiranService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutorizacijaLogiranService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
