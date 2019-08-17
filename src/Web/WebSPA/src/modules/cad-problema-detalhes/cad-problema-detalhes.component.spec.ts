import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadProblemaDetalhesComponent } from './cad-problema-detalhes.component';

describe('CadProblemaDetalhesComponent', () => {
  let component: CadProblemaDetalhesComponent;
  let fixture: ComponentFixture<CadProblemaDetalhesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadProblemaDetalhesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadProblemaDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
