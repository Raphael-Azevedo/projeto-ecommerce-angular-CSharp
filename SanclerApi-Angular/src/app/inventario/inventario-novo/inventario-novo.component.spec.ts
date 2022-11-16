import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventarioNovoComponent } from './inventario-novo.component';

describe('InventarioNovoComponent', () => {
  let component: InventarioNovoComponent;
  let fixture: ComponentFixture<InventarioNovoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InventarioNovoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InventarioNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
