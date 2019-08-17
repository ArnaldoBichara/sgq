import { TestBed } from '@angular/core/testing';

import { CadAtivService } from './cad-ativ.service';

describe('CadAtivService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CadAtivService = TestBed.get(CadAtivService);
    expect(service).toBeTruthy();
  });
});
