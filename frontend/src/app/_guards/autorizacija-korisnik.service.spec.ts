import { TestBed } from '@angular/core/testing';

import { AutorizacijaKorisnikService } from './autorizacija-korisnik.service';

describe('AutorizacijaKorisnikService', () => {
  let service: AutorizacijaKorisnikService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutorizacijaKorisnikService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
