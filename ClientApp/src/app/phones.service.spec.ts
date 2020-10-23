import { TestBed } from '@angular/core/testing';

import { PhonesService } from './phones.service';

describe('PhonesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhonesService = TestBed.get(PhonesService);
    expect(service).toBeTruthy();
  });
});
