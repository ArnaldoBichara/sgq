import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadProblemaCreateComponent } from './cad-problema-create.component';

describe('CadProblemaCreateComponent', () => {
  let component: CadProblemaCreateComponent;
  let fixture: ComponentFixture<CadProblemaCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadProblemaCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadProblemaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
