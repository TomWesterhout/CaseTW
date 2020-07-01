import { TestBed } from '@angular/core/testing';

import { CursusInstantieService } from './cursus-instantie.service';

describe('CursusInstantieService', () => {
  let service: CursusInstantieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CursusInstantieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
