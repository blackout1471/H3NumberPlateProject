import { TestBed } from '@angular/core/testing';

import { NumberPlateLocationApiService } from './number-plate-location-api.service';

describe('NumberPlateLocationApiService', () => {
  let service: NumberPlateLocationApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NumberPlateLocationApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
