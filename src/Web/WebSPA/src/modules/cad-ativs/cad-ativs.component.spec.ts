import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadAtivComponent } from './cad-ativs.component';

describe('CadAtivComponent', () => {
  let component: CadAtivComponent;
  let fixture: ComponentFixture<CadAtivComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadAtivComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadAtivComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
