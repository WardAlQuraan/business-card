import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertBulkFormComponent } from './insert-bulk-form.component';

describe('InsertBulkFormComponent', () => {
  let component: InsertBulkFormComponent;
  let fixture: ComponentFixture<InsertBulkFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsertBulkFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertBulkFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
