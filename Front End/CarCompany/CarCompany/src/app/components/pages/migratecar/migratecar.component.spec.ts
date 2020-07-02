import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MigratecarComponent } from './migratecar.component';

describe('MigratecarComponent', () => {
  let component: MigratecarComponent;
  let fixture: ComponentFixture<MigratecarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MigratecarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MigratecarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
