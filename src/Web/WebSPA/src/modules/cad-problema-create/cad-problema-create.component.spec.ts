import { async, ComponentFixture, TestBed } from '@angular/core/testing';

<<<<<<< HEAD
<<<<<<< HEAD:src/app/modules/cad-problema/cad-problema-create/cad-problema-create.component.spec.ts
=======
>>>>>>> 122cd7428a6e293207991981d732b3a7ee41f312
import { CadProblemaCreateComponent } from './cad-problema-create.component';

describe('CadProblemaCreateComponent', () => {
  let component: CadProblemaCreateComponent;
  let fixture: ComponentFixture<CadProblemaCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadProblemaCreateComponent ]
<<<<<<< HEAD
=======
import { CadProblemasComponent } from './cad-problemas.component';

describe('CadProblemasComponent', () => {
  let component: CadProblemasComponent;
  let fixture: ComponentFixture<CadProblemasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadProblemasComponent ]
>>>>>>> 122cd7428a6e293207991981d732b3a7ee41f312:src/app/modules/cad-problema/cad-problemas/cad-problemas.component.spec.ts
=======
>>>>>>> 122cd7428a6e293207991981d732b3a7ee41f312
    })
    .compileComponents();
  }));

  beforeEach(() => {
<<<<<<< HEAD
<<<<<<< HEAD:src/app/modules/cad-problema/cad-problema-create/cad-problema-create.component.spec.ts
    fixture = TestBed.createComponent(CadProblemaCreateComponent);
=======
    fixture = TestBed.createComponent(CadProblemasComponent);
>>>>>>> 122cd7428a6e293207991981d732b3a7ee41f312:src/app/modules/cad-problema/cad-problemas/cad-problemas.component.spec.ts
=======
    fixture = TestBed.createComponent(CadProblemaCreateComponent);
>>>>>>> 122cd7428a6e293207991981d732b3a7ee41f312
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
