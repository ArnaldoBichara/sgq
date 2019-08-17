import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadProblemasComponent } from './cad-problemas.component';

describe('CadProblemasComponent', () => {
  let component: CadProblemasComponent;
  let fixture: ComponentFixture<CadProblemasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadProblemasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadProblemasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
